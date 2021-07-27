using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Adamsone.Models
{
    public class Config : PropertyChangedBase
    {
        private bool _isAdamsonEnable;
        public bool IsAdamsonEnable
        {
            get => _isAdamsonEnable;
            set
            {
                _isAdamsonEnable = value;
                NotifyOfPropertyChange(nameof(IsAdamsonEnable));
            }
        }

        private string _studentId;
        public string StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
                NotifyOfPropertyChange(nameof(StudentId));
            }
        }

        private string _adamsonCredential;
        public string AdamsonCredential
        {
            get => _adamsonCredential;
            set
            {
                _adamsonCredential = value;
                NotifyOfPropertyChange(nameof(AdamsonCredential));
            }
        }

        private bool _isBlackboardEnable;
        public bool IsBlackboardEnable
        {
            get => _isBlackboardEnable;
            set
            {
                _isBlackboardEnable = value;
                NotifyOfPropertyChange(nameof(IsBlackboardEnable));
            }
        }

        private string _blackboardCredential;
        public string BlackboardCredential
        {
            get => _blackboardCredential;
            set
            {
                _blackboardCredential = value;
                NotifyOfPropertyChange(nameof(BlackboardCredential));
            }
        }

        private bool _isEmailEnable;
        public bool IsEmailEnable
        {
            get => _isEmailEnable;
            set
            {
                _isEmailEnable = value;
                NotifyOfPropertyChange(nameof(IsEmailEnable));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                NotifyOfPropertyChange(nameof(Email));
            }
        }

        private string _emailCredential;
        public string EmailCredential
        {
            get => _emailCredential;
            set
            {
                _emailCredential = value;
                NotifyOfPropertyChange(nameof(EmailCredential));
            }
        }

        private List<Note> _noteCollection;
        public List<Note> NoteCollection
        {
            get => _noteCollection;
            set
            {
                _noteCollection = value;
                NotifyOfPropertyChange(nameof(NoteCollection));
            }
        }

        public Config()
        {
            NoteCollection = new List<Note>();
        }
    }
}
