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

namespace _02Kharchenko
{
    public class Person : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birthdate = null;
        private bool? _isAdult = null;
        private string _sunSign;
        private string _chineeseSign;
        private bool? _isBirthday = null;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Person(string name, string surname, string email, DateTime? birthdate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthdate = birthdate;
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime? birthdate)
        {
            _name = name;
            _surname = surname;
            _birthdate = birthdate;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    System.Windows.MessageBox.Show("Name can't be empty.");
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    System.Windows.MessageBox.Show("Surname can't be empty.");
                _surname = value;
            }

        }

        public string Email
        {
            get { return _email; }
            set
            {
                try
                {
                    checkEmail(value);
                    _email = value;
                }
                catch(ArgumentNullException e)
                {
                    System.Windows.MessageBox.Show("Email can't be empty.");
                }
                catch(IncorrectEmailException e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            }

        }

        private void checkEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(Email));

            string[] parts = email.Split('@');
            if (parts.Length != 2)
                throw new IncorrectEmailException(email, " Email must stick to format 'joeschmoe@mydomain.com' .");

            string[] middleEnd = parts[1].Split('.');
            if (middleEnd.Length != 2)
                throw new IncorrectEmailException(email, " Email must stick to format 'joeschmoe@mydomain.com' .");
        }
        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set
            {
                try
                {
                    checkBirthdate(value);
                    _birthdate = value;
                    this.Proceed();

                    OnPropertyChanged(nameof(IsAdult));
                    OnPropertyChanged(nameof(SunSign));
                    OnPropertyChanged(nameof(ChineseSign));
                    OnPropertyChanged(nameof(IsBirthday));
                }
                catch (ArgumentNullException e)
                {
                    System.Windows.MessageBox.Show("Birthday can't be empty.");
                }
                catch(NonExistingBirthdateException e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
                catch (ExpiredBirthdateException e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            }
        }

        public void checkBirthdate(DateTime? date)
        {
            if(date == null)
            {
                throw new ArgumentNullException(nameof(Birthdate));
            }
            if (date > DateTime.UtcNow)
            {
                throw new NonExistingBirthdateException((DateTime)date);
            }
            if (Goroscope.calculateAge((DateTime)date) > 135)
            {
                throw new ExpiredBirthdateException((DateTime)date);
            }
        }

        public bool? IsAdult
        {
            get {
                if(_isAdult == null)
                {
                    this.Proceed();
                }
                return _isAdult; 
            }
            set
            {
                _isAdult = value;
            }
        }

        public string SunSign
        {
            get {
                if (_sunSign == null)
                {
                    this.Proceed();
                }
                return _sunSign; 
            }
            set
            {
                _sunSign = value;
            }
        }

        public string ChineseSign
        {
            get {
                if (_chineeseSign == null)
                {
                    this.Proceed();
                }
                return _chineeseSign; 
            }
            set
            {
                _chineeseSign = value;
            }
        }

        public bool? IsBirthday
        {
            get {
                if (_isBirthday == null)
                {
                    this.Proceed();
                }
                return _isBirthday;
            }
            set
            {
                _isBirthday = value;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
