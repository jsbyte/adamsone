using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;

namespace Adamsone.Views
{
    /// <summary>
    /// UserInputDialog.xaml 的交互逻辑
    /// </summary>
    public partial class UserInputDialog : CustomDialog
    {
        public UserInputDialog()
        {
            InitializeComponent();
            MinHeight = 500;
            MaxHeight = 600;
            MinWidth = 300;

            Loaded += Dialog_Loaded;
        }

        private void Dialog_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Focus();
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (this.DataContext != null) ((dynamic)DataContext).ButtonOk();
                    break;

                case Key.Escape:
                    if (this.DataContext != null) ((dynamic)DataContext).ButtonCancel();
                    break;
            }
        }
    }
}
