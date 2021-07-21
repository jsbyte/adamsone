using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            NoteCollection = new ObservableCollection<Note>()
            {
                new Note("Today note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note"),
                new Note("Next note")
            };
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

        public async void EditNote(Note note)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var userInputDialog = new UserInputDialog();
            var dialogViewModel = new UserInputDialogViewModel(async instance =>
            {
                if (instance.Cancel)
                {

                }
                await metroWindow.HideMetroDialogAsync(userInputDialog);
            }, "Save", "Discard");

            dialogViewModel.MessageText = "One Note";
            dialogViewModel.UserInput = note.Content;
            userInputDialog.DataContext = dialogViewModel;
            await metroWindow.ShowMetroDialogAsync(userInputDialog);

        }
    }
}
