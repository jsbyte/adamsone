using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Adamsone.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class SettingsViewModel : MenuPageViewModelBase
    {
        private Config _config;

        public Config Config
        {
            get => _config;
            set
            {
                _config = value;
                NotifyOfPropertyChange(nameof(Config));
            }
        }

        public MainViewModel MainViewModel { get; set; }

        public SettingsViewModel(MainViewModel mainViewModel) : base("Settings", new PackIconBoxIcons { Kind = PackIconBoxIconsKind.RegularSlider })
        {
            MainViewModel = mainViewModel;
            Config = mainViewModel.ConfigManager.Config;
        }

        public async void ButtonSave()
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var controller = await metroWindow.ShowProgressAsync("Please Wait", "Saving configuration...");
            controller.SetIndeterminate();
            MainViewModel.ConfigManager.Save();

            await Task.Delay(500);
            await controller.CloseAsync();
        }
    }
}
