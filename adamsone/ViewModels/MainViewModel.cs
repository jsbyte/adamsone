using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {

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

        protected override void OnViewLoaded(object view)
        {
            AppMenu = new ObservableCollection<MenuPageViewModelBase>
            {
                new BrowserViewModel("AdU", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.SolidSchool}),
                new BrowserViewModel("Blackboard", new PackIconBoxIcons {Kind = PackIconBoxIconsKind.SolidChalkboard}),
                new BrowserViewModel("Gmail", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.LogosGoogle}),
                new BrowserViewModel("Notes", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.SolidNote}),
                new SettingsViewModel()
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
    }
}
