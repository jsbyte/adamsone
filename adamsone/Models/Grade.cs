namespace Adamsone.Models
{
    public class Grade
    {
        private string _semester;

        public string Semester
        {
            get => _semester;
            set => _semester = value;
        }

        private string _subjectCode;
        public string SubjectCode
        {
            get => _subjectCode;
            set => _subjectCode = value;
        }

        private string _subjectDescription;
        public string SubjectDescription
        {
            get => _subjectDescription;
            set => _subjectDescription = value;
        }

        private string _units;

        public string Units
        {
            get => _units;
            set => _units = value;
        }

        private string _prelim;

        public string Prelim
        {
            get => _prelim;
            set => _prelim = value;
        }

        private string _midterm;

        public string Midterm
        {
            get => _midterm;
            set => _midterm = value;
        }

        private string _final;

        public string Final
        {
            get => _final;
            set => _final = value;
        }
    }
}
