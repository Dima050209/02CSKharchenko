﻿using _02Kharchenko.CustomExceptions;
using _02Kharchenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _02Kharchenko.ViewModels
{
    [Serializable]
    class PeopleListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        // list to save, contains all people
        private List<Person> _peopleList;
        // list to show
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

        private RelayCommand _saveCommand;

        //private bool _deletionInExecution;
        private Person _selectedPerson;
       
        private string _addName;
        private string _addSurame;
        private string _addEmail;
        private DateTime? _addBirthday;

        private string _filterByName;
        private string _filterBySurname;
        private string _filterByEmail;
        private DateTime? _filterByBirthdate;
        private bool _filterByIsAdult;
        private string _filterBySunSign;
        private string _filterByChineseSign;
        private bool _filterByIsBirthday;

        public void filterWithParameters()
        {
            List<Person> result = new List<Person>(_peopleList);
            if (!string.IsNullOrWhiteSpace(_filterByName))
            {
                result = result.Where(p => p.Name.Contains(_filterByName)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(_filterBySurname))
            {
                result = result.Where(p => p.Surname.Contains(_filterBySurname)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(_filterByEmail))
            {
                result = result.Where(p => p.Email.Contains(_filterByEmail)).ToList();
            }
            if (_filterByBirthdate != null)
            {
                result = result.Where(p => p.Birthdate == _filterByBirthdate).ToList();
            }
            if (_filterByIsAdult)
            {
                result = result.Where(p => (bool)p.IsAdult).ToList();
            }
            if (!string.IsNullOrWhiteSpace(_filterBySunSign))
            {
                result = result.Where(p => p.SunSign.Contains(_filterBySunSign)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(_filterByChineseSign))
            {
                result = result.Where(p => p.ChineseSign.Contains(_filterByChineseSign)).ToList();
            }
            if (_filterByIsBirthday)
            {
                result = result.Where(p => (bool)p.IsBirthday).ToList();
            }
            _people = result;
            updateList();
        }
        public string FilterByName
        {
            get { return _filterByName; }
            set { 
                _filterByName = value;
                filterWithParameters();
            }
        }
       
        public string FilterBySurname
        {
            get { return _filterBySurname; }
            set { 
                _filterBySurname = value;
                filterWithParameters();
            }
        }

        public string FilterByEmail
        {
            get { return _filterByEmail; }
            set {
                _filterByEmail = value;
                filterWithParameters();
            }
        }

        public DateTime? FilterByBirthdate
        {
            get { return _filterByBirthdate; }
            set { 
                _filterByBirthdate = value;
                filterWithParameters();
            }
        }

        public bool FilterByIsAdult
        {
            get { return _filterByIsAdult; }
            set { 
                _filterByIsAdult = value;
                filterWithParameters();

            }
        }

        public string FilterBySunSign
        {
            get { return _filterBySunSign; }
            set {
                _filterBySunSign = value;
                filterWithParameters();
            }
        }

        public string FilterByChineseSign
        {
            get { return _filterByChineseSign; }
            set {
                _filterByChineseSign = value;
                filterWithParameters();
            }
        }

        public bool FilterByIsBirthday
        {
            get { return _filterByIsBirthday; }
            set { 
                _filterByIsBirthday = value;
                filterWithParameters();
            }
        }


        public PeopleListViewModel()
        {
            _people = new List<Person>();
            //_deletionInExecution = false;
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
            _peopleList = new List<Person>(_people);
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand(Save, CanExecuteSave);
            }
        }
        private bool CanExecuteSave()
        {
            return true;
        }

        private void Save()
        {
            string serialized = JsonSerializer.Serialize(_peopleList);
            File.WriteAllText("people.json", serialized);
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
            var sortedPeople = from person in _people
                               orderby person.Name ascending
                               select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortBySurname()
        {
            var sortedPeople = from person in _people
                           orderby person.Surname ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByEmail()
        {
            var sortedPeople = from person in _people
                               orderby person.Email ascending
                               select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByBirthdate()
        {
            var sortedPeople = from person in _people
                               orderby person.Birthdate ascending
                               select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByIsAdult()
        {
            var sortedPeople = from person in _people
                           orderby person.IsAdult ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortBySunSign()
        {
            var sortedPeople = from person in _people
                           orderby person.SunSign ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByChineseSign()
        {
            var sortedPeople = from person in _people
                           orderby person.ChineseSign ascending
                           select person;
            _people = sortedPeople.ToList();
            updateList();
        }

        private void SortByIsBirthday()
        {
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
            int index = _peopleList.IndexOf(_selectedPerson);
            if (index != -1)
            {
                _peopleList.RemoveAt(index);
            }
            _selectedPerson = null;
            filterWithParameters();
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
            _peopleList.Add(newPerson);
            filterWithParameters();
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

