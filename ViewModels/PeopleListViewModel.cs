using _02Kharchenko.CustomExceptions;
using _02Kharchenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _02Kharchenko.ViewModels
{
    class PeopleListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private List<Person> _people;
        private RelayCommand _deletePersonCommand;
        private bool _deletionInExecution;
        private Person _selectedPerson;

        public PeopleListViewModel()
        {
            _people = new List<Person>();
            _deletionInExecution = false;
            _selectedPerson = null;

            Random random = new Random();
            // Adding 50 persons to the list
            for (int i = 0; i < 50; i++)
            {
                string name = $"Person{i + 1}";
                string surname = $"Surname{i + 1}";
                string email = $"person{i + 1}@example.com";
                DateTime birthdate = new DateTime(1970 + random.Next(0, 50), random.Next(1, 13), random.Next(1, 29));
                Person newPerson = new Person(name, surname, email, birthdate);
                _people.Add(newPerson);
            }
        }

        public RelayCommand DeletePersonCommand
        {
            get
            {
                return _deletePersonCommand ??= new RelayCommand(DeletePerson, CanExecute);
            }
        }

        private bool CanExecute()
        {
            return true;
        }

        private void DeletePerson()
        {
            int index = People.IndexOf(_selectedPerson);
            if (index != -1)
            {
                People.RemoveAt(index);
            }
            _selectedPerson = null;
            OnPropertyChanged(nameof(People));
            
        }
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }

        public List<Person> People
        {
            get { return _people; }
            set { 
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }
  
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

