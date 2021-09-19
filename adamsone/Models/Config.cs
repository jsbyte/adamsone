using System.Collections.Generic;
using Caliburn.Micro;
using Newtonsoft.Json;

namespace Adamsone.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Config : PropertyChangedBase
    {
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

        public bool IsAdamsonCredentialValid => !string.IsNullOrWhiteSpace(StudentId) && !string.IsNullOrWhiteSpace(AdamsonCredential);

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

        public bool IsBlackboardCredentialValid => !string.IsNullOrWhiteSpace(StudentId) && !string.IsNullOrWhiteSpace(BlackboardCredential);

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

        private bool _isSaveCookiesEnable = true;

        public bool IsSaveCookiesEnable
        {
            get => _isSaveCookiesEnable;
            set
            {
                _isSaveCookiesEnable = value;
                NotifyOfPropertyChange(nameof(IsSaveCookiesEnable));
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
