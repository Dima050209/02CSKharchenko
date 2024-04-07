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
        private RelayCommand _addPersonCommand;
        private bool _deletionInExecution;
        private Person _selectedPerson;
       
        private string _addName;
        private string _addSurame;
        private string _addEmail;
        private DateTime? _addBirthday;

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
                return _deletePersonCommand ??= new RelayCommand(DeletePerson, CanExecuteDeletion);
            }
        }

        private bool CanExecuteDeletion()
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
            updateList();

        }

        private void updateList()
        {
            List<Person> peopleCopy = new List<Person>(People);
            People = null;
            OnPropertyChanged(nameof(People));
            People = peopleCopy;
            OnPropertyChanged(nameof(People));
        }

        public RelayCommand AddPersonCommand
        {
            get
            {
                return _addPersonCommand ??= new RelayCommand(AddPerson, CanExecuteAdding);
            }
        }

        private bool CanExecuteAdding()
        {
            return !string.IsNullOrWhiteSpace(_addName)
                && !string.IsNullOrWhiteSpace(_addSurame)
                && !string.IsNullOrWhiteSpace(_addEmail)
                && _addBirthday != null;
        }

        private void AddPerson()
        {
            Person newPerson = new Person(_addName, _addSurame, _addEmail, _addBirthday);
            _people.Add(newPerson);
            updateList();
            AddName = null;
            AddSurname = null;
            AddEmail = null;
            AddBirthday = null;
            OnPropertyChanged(nameof(AddName));
            OnPropertyChanged(nameof(AddSurname));
            OnPropertyChanged(nameof(AddEmail));
            OnPropertyChanged(nameof(AddBirthday));

        }
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }

        public string AddName
        {
            get { return _addName; }
            set { _addName = value; }
        }

        public string AddSurname
        {
            get { return _addSurame; }
            set { _addSurame = value; }
        }

        public string AddEmail
        {
            get { return _addEmail; }
            set { _addEmail = value; }
        }

        public DateTime? AddBirthday
        {
            get { return _addBirthday; }
            set { _addBirthday = value; }
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

