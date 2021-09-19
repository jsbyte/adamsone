using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Adamsone.Models;
using Adamsone.Services;
using Caliburn.Micro;
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

            var friendlyMessage = new StringBuilder("\r\n")
                .AppendLine("If the credentials you entered is correct, try right click on AdU/Blackboard or reboot Adamsone to experience Automatic Login feature.")
                .AppendLine("\r\n")
                .AppendLine("This message will automatically close in 5 seconds.");
            var dialogSettings = new MetroDialogSettings
            {
                OwnerCanCloseWithDialog = true
            };
            controller = await metroWindow.ShowProgressAsync("Configuration Saved!", friendlyMessage.ToString(), false, dialogSettings);
            controller.Maximum = 3000;

            for (int i = 0; i <= 3000; i += 20)
            {
                controller.SetProgress(i);
                await Task.Delay(20);
            }

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
                        streamWriter.WriteLine($"ID: {note.Id}\r\nCreated: {note.Updated}\r\n{note.Content}\r\n");
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
