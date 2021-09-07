using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Newtonsoft.Json;

namespace Adamsone.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Note : PropertyChangedBase
    {
        public Guid Id { get; set; }

        private DateTime _updated;

        public DateTime Updated
        {
            get => _updated;
            set
            {
                _updated = value;
                NotifyOfPropertyChange(nameof(Updated));
            }
        }

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                Updated = DateTime.Now;
                NotifyOfPropertyChange(nameof(Content));
            }
        }

        public Note(string content)
        {
            Id = Guid.NewGuid();
            Updated = DateTime.Now;
            Content = content;
        }
    }
}
