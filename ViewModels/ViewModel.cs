using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02Kharchenko.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private Person _person;

        public ViewModel()
        {
            _person = new Person(null, null, null, DateTime.MinValue);
        }

        public void Process()
        {
            if (_person.Name == null)
            {
                throw new ArgumentNullException(nameof(_person.Name));
            }
            if (_person.Surname == null)
            {
                throw new ArgumentNullException(nameof(_person.Surname));
            }
            if (_person.Email == null)
            {
                throw new ArgumentNullException(nameof(_person.Email));
            }
            if (_person.Birthdate == DateTime.MinValue)
            {
                throw new ArgumentNullException(nameof(_person.Birthdate));
            }
          
        }

        public string Name
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value;
                //OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return _person.Surname; }
            set
            {
                _person.Surname = value;
            }

        }

        public string Email
        {
            get { return _person.Email; }
            set
            {
                _person.Email = value;
            }

        }

        public DateTime Birthdate
        {
            get { return _person.Birthdate; }
            set
            {
                _person.Birthdate = value;
            }
        }

        public bool IsAdult
        {
            get { return _person.IsAdult; }
            private set { }
        }

        public string SunSign
        {
            get { return _person.SunSign; }
            private set { }
        }

        public string ChineseSign
        {
            get { return _person.ChineseSign; }
            private set { }
        }

        public bool IsBirthday
        {
            get { return _person.IsBirthday; }
            private set { }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
