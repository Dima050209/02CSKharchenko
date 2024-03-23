using _02Kharchenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02Kharchenko.ViewModels
{
    class PersonViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private Person _person;

        public PersonViewModel()
        {
            _person = new Person(null, null, null, DateTime.MinValue);
        }

        public void Proceed()
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

            Thread thread1 = new Thread(() =>
            {
                IsAdult = Goroscope.calculateAge((DateTime)_person.Birthdate) >= 18;
                OnPropertyChanged(nameof(IsAdult));
            });

            Thread thread2 = new Thread(() =>
            {
                SunSign = Goroscope.calculateWesternZodiac((DateTime)_person.Birthdate);
                OnPropertyChanged(nameof(SunSign));
            });

            Thread thread3 = new Thread(() =>
            {
                ChineseSign = Goroscope.calculateChineseZodiac((DateTime)_person.Birthdate);
                OnPropertyChanged(nameof(ChineseSign));
            });

            Thread thread4 = new Thread(() =>
            {
                IsBirthday = Goroscope.isBirthday(((DateTime)_person.Birthdate).Month, ((DateTime)_person.Birthdate).Day);
                OnPropertyChanged(nameof(IsBirthday));
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Birthdate));
        }

        public string Name
        {
            get
            { 
                return _person.Name; 
            }
            set
            {
                _person.Name = value;
            }
        }

        public string Surname
        {
            get 
            {
                return _person.Surname;
            }
            set
            {
                _person.Surname = value;
            }

        }

        public string Email
        {
            get
            {
                return _person.Email; 
            }
            set
            {
                _person.Email = value;
            }

        }

        public DateTime? Birthdate
        {
            get
            {
                return _person.Birthdate;
            }
            set
            {
                _person.Birthdate = value;
            }
        }

        public bool? IsAdult
        {
            get { 
                return _person.IsAdult;
            }
            private set
            {
                _person.IsAdult = value;
            }
        }

        public string SunSign
        {
            get
            { 
                return _person.SunSign; 
            }
            private set 
            {
                _person.SunSign = value;
            }
        }

        public string ChineseSign
        {
            get 
            { 
                return _person.ChineseSign;
            }
            private set
            {
                _person.ChineseSign = value;
            }
        }

        public bool? IsBirthday
        {
            get 
            {
                return _person.IsBirthday;
            }
            private set
            {
                _person.IsBirthday = value;
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
