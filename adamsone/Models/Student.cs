using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Adamsone.Models
{
    public class Student : PropertyChangedBase
    {
        private string _studentNumber;

        public string StudentNumber
        {
            get => _studentNumber;
            set
            {
                _studentNumber = value;
                NotifyOfPropertyChange(nameof(StudentNumber));
            }
        }

        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                NotifyOfPropertyChange(nameof(FullName));
            }
        }

        private string _program;
        public string Program
        {
            get => _program;
            set
            {
                _program = value;
                NotifyOfPropertyChange(nameof(Program));
            }
        }

        private string _semester;
        public string Semester
        {
            get => _semester;
            set
            {
                _semester = value;
                NotifyOfPropertyChange(nameof(Semester));
            }
        }

        private List<Grade> _grades;

        public List<Grade> Grades
        {
            get => _grades;
            set
            {
                _grades = value;
                NotifyOfPropertyChange(nameof(Grades));
            }
        }

        private List<Payment> _payments;

        public List<Payment> Payments
        {
            get => _payments;
            set
            {
                _payments = value;
                NotifyOfPropertyChange(nameof(Payments));
            }
        }

        private List<AssessmentFee> _assessmentFees;

        public List<AssessmentFee> AssessmentFees
        {
            get => _assessmentFees;
            set
            {
                _assessmentFees = value;
                NotifyOfPropertyChange(nameof(AssessmentFees));
            }
        }

        private DateTime _updatedTime;

        public DateTime UpdatedTime
        {
            get => _updatedTime;
            set
            {
                _updatedTime = value;
                NotifyOfPropertyChange(nameof(UpdatedTime));
            }
        }

        public Student()
        {
            Grades = new List<Grade>();
            Payments = new List<Payment>();
            AssessmentFees = new List<AssessmentFee>();
        }
    }
}
