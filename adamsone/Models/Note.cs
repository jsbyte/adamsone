using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamsone.Models
{
    public class Note
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public Note(string content)
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            Content = content;
        }
    }
}
