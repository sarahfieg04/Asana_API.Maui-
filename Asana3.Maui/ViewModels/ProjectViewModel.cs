using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Asana3.Library.Models;
using Asana3.Library.Services;

namespace Asana3.Maui.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public Project? Model { get; set; }

        public ObservableCollection<ToDoDetailViewModel> ToDos
        {
            get
            {
                if (Model == null || Model.ToDos == null)
                {
                    return new ObservableCollection<ToDoDetailViewModel>();
                }

                return new ObservableCollection<ToDoDetailViewModel>(
                    Model.ToDos.Select(t => new ToDoDetailViewModel(t)));
            }
        }
        public ICommand? ToggleToDoVisibility { get; set; }

        private Visibility toDoVisibility;
        public Visibility ToDoVisibility
        {
            get
            {
                return toDoVisibility;
            }
            set
            {
                if (toDoVisibility != value)
                {
                    toDoVisibility = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void DoToggleToDoVisibility()
        {
            if (ToDoVisibility == Visibility.Collapsed)
            {
                ToDoVisibility = Visibility.Visible;
            }
            else
            {
                ToDoVisibility = Visibility.Collapsed;
            }
            NotifyPropertyChanged(nameof(ToDoVisibility));
        }


        public ProjectViewModel()
        {
            Model = new Project();
            ToDoVisibility = Visibility.Visible;
            ToggleToDoVisibility = new Command(DoToggleToDoVisibility);
        }
        public ProjectViewModel(Project? model)
        {
            Model = model;
            ToDoVisibility = Visibility.Visible;
            ToggleToDoVisibility = new Command(DoToggleToDoVisibility); 
        }

        public override string ToString()
        {
            return $"{Model?.Id ?? -1}. {Model?.Name}";
        }
    }
}
