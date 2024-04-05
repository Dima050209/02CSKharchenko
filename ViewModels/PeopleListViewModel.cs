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

        public PeopleListViewModel()
        {
            _people = new List<Person>();
            // Adding 50 persons to the list
            for (int i = 0; i < 50; i++)
            {
                string name = $"Person{i + 1}";
                string surname = $"Surname{i + 1}";
                string email = $"person{i + 1}@example.com";
                DateTime? birthdate = DateTime.Now.AddYears(-20 - i);

                Person newPerson = new Person(name, surname, email, birthdate);
                _people.Add(newPerson);
            }
        }
       
        public List<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }
  
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

