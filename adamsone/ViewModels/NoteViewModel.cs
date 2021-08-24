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
using Adamsone.Views;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class NoteViewModel : MenuPageViewModelBase
    {
        public NoteViewModel() : base("Note", new PackIconBoxIcons { Kind = PackIconBoxIconsKind.SolidNote })
        {
            ConfigManager = IoC.Get<ConfigManager>();
            NoteCollection = new ObservableCollection<Note>();
        }

        private ObservableCollection<Note> _noteCollection;

        public ObservableCollection<Note> NoteCollection
        {
            get => _noteCollection;
            set
            {
                _noteCollection = value;
                NotifyOfPropertyChange(nameof(NoteCollection));
            }
        }

        public ConfigManager ConfigManager { get; }

        public async void EditNote(Note note)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var userInputDialog = new UserInputDialog();
            var dialogViewModel = new UserInputDialogViewModel(async instance =>
            {
                if (instance.Cancel)
                {

                }
                else if (instance.Delete)
                {
                    NoteCollection.Remove(note);
                    ConfigManager.Config.NoteCollection.Remove(note);
                    ConfigManager.Save();
                }
                else
                {
                    note.Content = instance.UserInput;
                    ConfigManager.Config.NoteCollection.Clear();
                    ConfigManager.Config.NoteCollection.AddRange(NoteCollection);
                    ConfigManager.Save();
                }

                await metroWindow.HideMetroDialogAsync(userInputDialog);
            }, "Save", "Delete", "Discard");

            dialogViewModel.MessageText = "One Note";
            dialogViewModel.UserInput = note.Content;
            userInputDialog.DataContext = dialogViewModel;
            await metroWindow.ShowMetroDialogAsync(userInputDialog);
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            NoteCollection.Clear();
            foreach (var note in ConfigManager.Config.NoteCollection)
            {
                NoteCollection.Add(note);
            }
            return base.OnActivateAsync(cancellationToken);
        }
    }
}
