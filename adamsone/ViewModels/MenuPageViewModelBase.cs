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
