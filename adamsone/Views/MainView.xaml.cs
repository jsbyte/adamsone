using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Adamsone.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ProfileDataGrid_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ProfileScrollViewer.ScrollToVerticalOffset(ProfileScrollViewer.VerticalOffset - e.Delta / 3);
        }
    }
}
