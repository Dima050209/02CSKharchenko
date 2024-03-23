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
    class PersonViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private Person _person;
        private RelayCommand _proceedCommand;
        private bool _processInExecution;

        public PersonViewModel()
        {
            _person = new Person(null, null, null, null);
            _processInExecution = false;
        }

        public RelayCommand ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand(Proceed, CanExecute);
            }
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname)
                && !String.IsNullOrWhiteSpace(Email) && (Birthdate != null) && !_processInExecution;
        }
        private void Proceed()
        {
            if (_processInExecution)
                return;
            _processInExecution = true;

            SunSign = "";
            ChineseSign = "";
            IsAdult = null;
            IsBirthday = null;
            OnPropertyChanged(nameof(SunSign));
            OnPropertyChanged(nameof(ChineseSign));
            OnPropertyChanged(nameof(IsAdult));
            OnPropertyChanged(nameof(IsBirthday));

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
            });

            Thread thread2 = new Thread(() =>
            {
                SunSign = Goroscope.calculateWesternZodiac((DateTime)_person.Birthdate);
            });

            Thread thread3 = new Thread(() =>
            {
                ChineseSign = Goroscope.calculateChineseZodiac((DateTime)_person.Birthdate);
            });

            Thread thread4 = new Thread(() =>
            {
                IsBirthday = Goroscope.isBirthday(((DateTime)_person.Birthdate).Month, ((DateTime)_person.Birthdate).Day);
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Birthdate));

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            OnPropertyChanged(nameof(IsAdult));
            OnPropertyChanged(nameof(SunSign));
            OnPropertyChanged(nameof(ChineseSign));
            OnPropertyChanged(nameof(IsBirthday));

            _processInExecution = false;
          
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
