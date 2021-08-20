using System;
using System.Collections.Generic;
using System.IO;
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

        public async void ButtonExportAllNote()
        {
            var fileName = $"export_all_note_{DateTime.Now.ToFileTime()}.txt";
            var outputDirectory = Path.Combine(Environment.CurrentDirectory, "exports");
            var outputPath = Path.Combine(outputDirectory, fileName);

            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var controller = await metroWindow.ShowProgressAsync("Please Wait", "Saving configuration...");
            controller.SetIndeterminate();

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            await Task.Run(() =>
            {
                using (var streamWriter = File.CreateText(outputPath))
                {
                    foreach (var note in Config.NoteCollection)
                    {
                        streamWriter.WriteLine($"ID: {note.Id}\r\nCreated: {note.Created}\r\n{note.Content}\r\n");
                    }

                    streamWriter.Close();
                }
            }).ContinueWith(task =>
            {
                controller.CloseAsync();
            });
        }
    }
}
