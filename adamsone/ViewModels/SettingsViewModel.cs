using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adamsone.Models;
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

        public void ButtonSave()
        {
            MainViewModel.ConfigManager.Save();
        }
    }
}
