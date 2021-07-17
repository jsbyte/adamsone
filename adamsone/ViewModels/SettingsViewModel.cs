using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class SettingsViewModel : MenuPageViewModelBase
    {
        public SettingsViewModel() : base("Settings", new PackIconBoxIcons { Kind = PackIconBoxIconsKind.RegularSlider })
        {

        }
    }
}
