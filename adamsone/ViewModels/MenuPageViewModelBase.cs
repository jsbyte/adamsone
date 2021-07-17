using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class MenuPageViewModelBase : Screen
    {
        public virtual string Label { get; }
        public virtual PackIconControlBase Icon { get; }
        
        public MenuPageViewModelBase(string label, PackIconControlBase icon)
        {
            Label = label;
            Icon = icon;
        }
    }
}
