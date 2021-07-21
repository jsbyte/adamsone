using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Adamsone.Infrastructure;
using Caliburn.Micro;

namespace Adamsone.ViewModels
{
    public class UserInputDialogViewModel : PropertyChangedBase
    {
        private readonly ICommand _closeCommand;

        public string MessageText { get; set; }

        public string UserInput { get; set; }

        public bool Cancel { get; set; }

        public string ButtonOkContent { get; set; }

        public string ButtonCancelContent { get; set; }

        public UserInputDialogViewModel(Action<UserInputDialogViewModel> closeHandler, string buttonOkContent = "Ok", string buttonCancelContent = "Cancel")
        {
            ButtonOkContent = buttonOkContent;
            ButtonCancelContent = buttonCancelContent;
            Cancel = false;
            _closeCommand = new SimpleCommand { ExecuteDelegate = o => closeHandler(this)};
        }

        public void ButtonOk()
        {
            Cancel = false;
            _closeCommand.Execute(this);
        }

        public void ButtonCancel()
        {
            Cancel = true;
            _closeCommand.Execute(this);
        }
    }
}
