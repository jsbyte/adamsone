using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamsone.Models
{
    public class AssessmentFee
    {
        private string _semester;

        public string Semester
        {
            get => _semester;
            set => _semester = value;
        }

        private string _transaction;

        public string Transaction
        {
            get => _transaction;
            set => _transaction = value;
        }

        private string _amount;

        public string Amount
        {
            get => _amount;
            set => _amount = value;
        }
    }
}
