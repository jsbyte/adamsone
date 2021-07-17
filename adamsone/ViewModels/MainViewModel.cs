using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnViewLoaded(object view)
        {
            AppMenu = new ObservableCollection<MenuPageViewModelBase>
            {
                new BrowserViewModel("AdU", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.SolidSchool}),
                new BrowserViewModel("Blackboard", new PackIconBoxIcons {Kind = PackIconBoxIconsKind.SolidChalkboard}),
                new BrowserViewModel("Gmail", new PackIconBoxIcons{Kind = PackIconBoxIconsKind.LogosGoogle})
            };

            ActivateItemAsync(AppMenu.First());

            base.OnViewLoaded(view);
        }
    }
}
