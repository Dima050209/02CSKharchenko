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

        private RelayCommand _sortByName;
        private RelayCommand _sortBySurname;
        private RelayCommand _sortByEmail;
        private RelayCommand _sortByBirthdate;
        private RelayCommand _sortByIsAdult;
        private RelayCommand _sortBySunSign;
        private RelayCommand _sortByChineseSign;
        private RelayCommand _sortByIsBirthday;

        private bool _deletionInExecution;
        private Person _selectedPerson;
       
        private string _addName;
        private string _addSurame;
        private string _addEmail;
        private DateTime? _addBirthday;

        public enum SortMethod
        {
            ByName,
            BySurname,
            ByEmail,
            ByBirthdate,
            ByIsAdult,
            BySunSign, 
            ByChineseSign,
            ByIsBirthday
        }

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

        public RelayCommand SortByNameCommand
        {
            get
            {
                return _sortByName ??= new RelayCommand(SortByName, CanExecuteSort);
            }
        }

        public RelayCommand SortBySurnameCommand
        {
            get
            {
                return _sortBySurname ??= new RelayCommand(SortBySurname, CanExecuteSort);
            }
        }

        public RelayCommand SortByEmailCommand
        {
            get
            {
                return _sortByEmail ??= new RelayCommand(SortByEmail, CanExecuteSort);
            }
        }

        public RelayCommand SortByBirthdateCommand
        {
            get
            {
                return _sortByBirthdate ??= new RelayCommand(SortByBirthdate, CanExecuteSort);
            }
        }

        public RelayCommand SortByIsAdultCommand
        {
            get
            {
                return _sortByIsAdult ??= new RelayCommand(SortByIsAdult, CanExecuteSort);
            }
        }

        public RelayCommand SortBySunSignCommand
        {
            get
            {
                return _sortBySunSign ??= new RelayCommand(SortBySunSign, CanExecuteSort);
            }
        }

        public RelayCommand SortByChineseSignCommand
        {
            get
            {
                return _sortByChineseSign ??= new RelayCommand(SortByChineseSign, CanExecuteSort);
            }
        }

        public RelayCommand SortByIsBirthdayCommand
        {
            get
            {
                return _sortByIsBirthday ??= new RelayCommand(SortByIsBirthday, CanExecuteSort);
            }
        }

        private bool CanExecuteSort()
        {
            return true;
        }

        private void SortByName()
        {
            // Логіка сортування за іменем
            var sortedPeople = from person in _people
                               orderby person.Name ascending
                               select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortBySurname()
        {
            // Логіка сортування за прізвищем
            var sortedPeople = from person in _people
                           orderby person.Surname ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByEmail()
        {
            // Логіка сортування за електронною поштою
            var sortedPeople = from person in _people
                               orderby person.Email ascending
                               select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByBirthdate()
        {
            // Логіка сортування за датою народження
            var sortedPeople = from person in _people
                               orderby person.Birthdate ascending
                               select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByIsAdult()
        {
            // Логіка сортування за визначенням "дорослий"
            var sortedPeople = from person in _people
                           orderby person.IsAdult ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortBySunSign()
        {
            // Логіка сортування за знаком зодіаку
            var sortedPeople = from person in _people
                           orderby person.SunSign ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByChineseSign()
        {
            // Логіка сортування за китайським знаком зодіаку
            var sortedPeople = from person in _people
                           orderby person.ChineseSign ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByIsBirthday()
        {
            // Логіка сортування за позначенням "день народження"
            var sortedPeople = from person in _people 
                               orderby person.IsBirthday ascending 
                               select person;
            _people = sortedPeople.ToList();
            updateList();
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

