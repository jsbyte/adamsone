using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Adamsone.Models;
using Adamsone.Services;
using Caliburn.Micro;
using CefSharp;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;
using Cef = CefSharp.Core.Cef;

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

        public KeepAliveService KeepAliveService { get; }

        public bool CanAdamsonEnable
        {
            get => !string.IsNullOrWhiteSpace(Config.StudentId) && !string.IsNullOrWhiteSpace(Config.AdamsonCredential);
        }

        public MainViewModel MainViewModel { get; set; }

        public SettingsViewModel(MainViewModel mainViewModel) : base("Settings", new PackIconBoxIcons { Kind = PackIconBoxIconsKind.RegularSlider })
        {
            MainViewModel = mainViewModel;
            Config = mainViewModel.ConfigManager.Config;
            KeepAliveService = IoC.Get<KeepAliveService>();
        }

        public async void ButtonClearCache()
        {
            //var metroWindow = Application.Current.MainWindow as MetroWindow;
            //var controller = await metroWindow.ShowProgressAsync("Please Wait", "Clearing all caches...");
            //controller.SetIndeterminate();

            //var cookieManager = Cef.GetGlobalCookieManager().DeleteCookies();


            //await callback.Task.ContinueWith(t =>
            //{
            //    controller.CloseAsync();
            //});
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
