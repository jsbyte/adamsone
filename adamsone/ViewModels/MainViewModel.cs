using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Adamsone.Infrastructure;
using Adamsone.Models;
using Caliburn.Micro;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public ConfigManager ConfigManager { get; }


        public MainViewModel(ConfigManager configManager)
        {
            ConfigManager = configManager;
        }

        private ObservableCollection<MenuPageViewModelBase> _appMenu;

        public ObservableCollection<MenuPageViewModelBase> AppMenu
        {
            get => _appMenu;
            set
            {
                _appMenu = value;
                NotifyOfPropertyChange(nameof(AppMenu));
            }
        }

        private ObservableCollection<MenuPageViewModelBase> _appOptionsMenu;
        public ObservableCollection<MenuPageViewModelBase> AppOptionsMenu
        {
            get => _appOptionsMenu;
            set
            {
                _appOptionsMenu = value;
                NotifyOfPropertyChange(nameof(AppOptionsMenu));
            }
        }

        private bool _isNoteFlyoutOpen;

        public bool IsNoteFlyoutOpen
        {
            get => _isNoteFlyoutOpen;
            set
            {
                _isNoteFlyoutOpen = value;
                NotifyOfPropertyChange(nameof(IsNoteFlyoutOpen));
            }
        }

        private string _currentNote;

        public string CurrentNote
        {
            get => _currentNote;
            set
            {
                _currentNote = value;
                NotifyOfPropertyChange(nameof(CurrentNote));
            }
        }

        protected override void OnViewLoaded(object view)
        {
            AppMenu = new ObservableCollection<MenuPageViewModelBase>
            {
                new BrowserViewModel("AdU", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.SolidSchool}),
                new BrowserViewModel("Blackboard", new PackIconBoxIcons {Kind = PackIconBoxIconsKind.SolidChalkboard}),
                new BrowserViewModel("Gmail", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.LogosGoogle}),
                new BrowserViewModel("Facebook", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.LogosFacebook}),
                new BrowserViewModel("Twitter", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.LogosTwitter}),
                new NoteViewModel(),
                new SettingsViewModel(this)
            };

            PreRenderingAsync().ConfigureAwait(false);

            base.OnViewLoaded(view);
        }

        public async Task PreRenderingAsync()
        {
            foreach (var item in AppMenu)
            {
                await ActivateItemAsync(item);
                await Task.Delay(10);
            }

            await ActivateItemAsync(AppMenu.First());
        }

        protected override Task ChangeActiveItemAsync(object newItem, bool closePrevious, CancellationToken cancellationToken)
        {
            return base.ChangeActiveItemAsync(newItem, false, cancellationToken);
        }

        public void OpenNoteFlyout()
        {
            IsNoteFlyoutOpen = true;
        }

        public void CloseNoteFlyout()
        {
            IsNoteFlyoutOpen = false;
        }

        public void SaveCurrentNote()
        {
            ConfigManager.Config.NoteCollection.Add(new Note(CurrentNote));
            ConfigManager.Save();
            DiscardCurrentNote();
        }

        public void DiscardCurrentNote()
        {
            CurrentNote = string.Empty;
            CloseNoteFlyout();
        }
    }
}
