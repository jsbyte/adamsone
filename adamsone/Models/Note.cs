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

        public DateTime Created { get; set; }

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                NotifyOfPropertyChange(nameof(Content));
            }
        }

        public Note(string content)
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            Content = content;
        }
    }
}
