using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Adamsone.Contracts;
using Adamsone.Models;
using AngleSharp;
using Caliburn.Micro;
using CefSharp;
using Flurl.Http;

namespace Adamsone.Services
{
    public class ProfileService : PropertyChangedBase, IHandle<UpdateStudentProfileMessage>
    {
        public WebSessionManager SessionManager { get; }

        private Student _student;

        public Student Student
        {
            get => _student;
            set
            {
                _student = value;
                NotifyOfPropertyChange(nameof(Student));
            }
        }

        public List<Cookie> Cookies { get; private set; }


        private readonly IEventAggregator _eventAggregator;
        public ProfileService(WebSessionManager webSessionManager, IEventAggregator eventAggregator)
        {
            Student = new Student();
            SessionManager = webSessionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.SubscribeOnBackgroundThread(this);
        }

        public async Task UpdateStudentProfile()
        {
            Cookies = await SessionManager.RetrieveCookiesAsync(WebsiteCode.Adamson);

            try
            {
                var studentInformationTask = GetStudentInformation();
                var paymentHistoryTask = GetPaymentHistory();
                var gradesTask = GetGrades(await GetSemesterCode());
                var assessmentFeesTask = GetAssessmentFees(await GetSemesterCode(true));

                await Task.WhenAll(studentInformationTask, paymentHistoryTask, gradesTask, assessmentFeesTask);

                Student.StudentNumber = studentInformationTask.Result.StudentNumber;
                Student.FullName = studentInformationTask.Result.FullName;
                Student.Program = studentInformationTask.Result.Program;
                Student.Semester = studentInformationTask.Result.Semester;

                Student.Grades = gradesTask.Result;
                Student.Payments = paymentHistoryTask.Result;
                Student.AssessmentFees = assessmentFeesTask.Result;

                Student.UpdatedTime = DateTime.Now;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private async Task<dynamic> GetStudentInformation()
        {
            var context = BrowsingContext.New(Configuration.Default);

            var content = await "https://learn.adamson.edu.ph/V4/?page=enroll"
                .WithCookies(Cookies)
                .GetStringAsync();

            var document = await context.OpenAsync(req =>
                req.Content(content));

            var columns = document.QuerySelectorAll("div.studinfo");

            return new
            {
                FullName = columns[1].TextContent.Trim(),
                StudentNumber = columns[2].TextContent.Trim(),
                Program = columns[3].TextContent.Trim(),
                Semester = columns[4].TextContent.Trim()
            };
        }

        private async Task<dynamic> GetSemesterCode(bool forAssessmentFees = false)
        {
            var content = await (forAssessmentFees
                    ? "https://learn.adamson.edu.ph/V4/?page=assessment"
                    : "https://learn.adamson.edu.ph/V4/?page=mygrades")
                .WithCookies(Cookies)
                .GetStringAsync();

            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req =>
                req.Content(content));

            var options = forAssessmentFees
                ? document.QuerySelectorAll("#cboassesssyt option")
                : document.QuerySelectorAll("#jumpMenu option");


            return options.Select(x => KeyValuePair.Create(x.TextContent, x.Attributes["value"]?.Value));
        }

        private async Task<List<Grade>> GetGrades(IEnumerable<KeyValuePair<string, string>> semesterCodes)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var grades = new List<Grade>();

            foreach (var code in semesterCodes)
            {
                var content = await "https://learn.adamson.edu.ph/V4/modules/mygrades.php"
                    .WithCookies(Cookies)
                    .PostUrlEncodedAsync(new { TXTSYT = code.Value })
                    .ReceiveString();

                var document = await context.OpenAsync(req =>
                    req.Content(content));

                grades.AddRange(document.QuerySelectorAll("table tr").Skip(1).SkipLast(1).Select(x =>
                {
                    var columns = x.QuerySelectorAll("td");
                    return new Grade
                    {
                        Semester = code.Key,
                        SubjectCode = columns[0].TextContent.Trim(),
                        SubjectDescription = columns[1].TextContent.Trim(),
                        Units = columns[2].TextContent.Trim(),
                        Prelim = columns[3].TextContent.Trim(),
                        Midterm = columns[4].TextContent.Trim(),
                        Final = columns[5].TextContent.Trim()
                    };
                }));
            }

            return grades;
        }

        private async Task<List<Payment>> GetPaymentHistory()
        {
            var context = BrowsingContext.New(Configuration.Default);
            var content = await "https://learn.adamson.edu.ph/V4/?page=payhistory"
                .WithCookies(Cookies)
                .GetStringAsync();

            var document = await context.OpenAsync(req =>
                req.Content(content));

            return document.QuerySelectorAll(".tblpayhistory tr").Skip(1).Select(x =>
            {
                var columns = x.QuerySelectorAll("td");
                return new Payment
                {
                    OrderNumber = columns[0].TextContent,
                    OrderDate = columns[1].TextContent,
                    SchoolYear = columns[2].TextContent,
                    Term = columns[3].TextContent,
                    Type = columns[4].TextContent,
                    Amount = decimal.Parse(columns[5].TextContent)
                };
            }).ToList();
        }

        private async Task<List<AssessmentFee>> GetAssessmentFees(IEnumerable<KeyValuePair<string, string>> semesterCodes)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var assesmentFees = new List<AssessmentFee>();

            foreach (var code in semesterCodes)
            {
                var content = await "https://learn.adamson.edu.ph/V4/modules/assessment/assess_genassess_col.php"
                    .WithCookies(Cookies)
                    .PostUrlEncodedAsync(new { cboassesssyt = code.Value })
                    .ReceiveString();

                var document = await context.OpenAsync(req =>
                    req.Content(content));

                assesmentFees.AddRange(document.QuerySelectorAll("table tr")
                    .Select(x => new AssessmentFee
                    {
                        Semester = code.Key,
                        Transaction = x.Children[0].TextContent,
                        Amount = x.Children[1].TextContent

                    }));
            }

            return assesmentFees;
        }

        public Task HandleAsync(UpdateStudentProfileMessage message, System.Threading.CancellationToken cancellationToken)
        {
            Task.Delay(message.Delay, cancellationToken).Wait();
            return Task.Factory.StartNew(UpdateStudentProfile, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}