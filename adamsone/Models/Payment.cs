using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamsone.Models
{
    public class Payment
    {
        private string _orderNumber;

        public string OrderNumber
        {
            get => _orderNumber;
            set => _orderNumber = value;
        }

        private string _orderDate;

        public string OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }

        private string _schoolYear;

        public string SchoolYear
        {
            get => _schoolYear;
            set => _schoolYear = value;
        }

        private string _term;

        public string Term
        {
            get => _term;
            set => _term = value;
        }

        private string _type;

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set => _amount = value;
        }
    }
}
