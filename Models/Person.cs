using _02Kharchenko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kharchenko
{
    class Person
    {
        private Goroscope _goroscope;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdate;
        private bool _isAdult;
        private string _sunSign;
        private string _chineeseSign;
        private bool _isBirthday;

        public Person(string name, string surname, string email, DateTime birthdate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthdate = birthdate;
            _goroscope = new Goroscope();
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _goroscope = new Goroscope();
        }

        public Person(string name, string surname, DateTime birthdate)
        {
            _name = name;
            _surname = surname;
            _birthdate = birthdate;
            _goroscope = new Goroscope();
        }

        public void Process()
        {
            if(_name == null)
            {
                throw new ArgumentNullException(nameof(_name));
            }
            if (_surname == null)
            {
                throw new ArgumentNullException(nameof(_name));
            }
            if (_email == null)
            {
                throw new ArgumentNullException(nameof(_name));
            }
            if (_birthdate == DateTime.MinValue)
            {
                throw new ArgumentNullException(nameof(_name));
            }
            _isAdult = _goroscope.calculateAge(_birthdate) >= 18;
            _sunSign = _goroscope.calculateWesternZodiac(_birthdate);
            _chineeseSign = _goroscope.calculateChineseZodiac(_birthdate);
            _isBirthday = _goroscope.isBirthday(_birthdate.Month, _birthdate.Day);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }

        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }

        }

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
            }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            private set
            {
                _isAdult = value;
            }
        }

        public string SunSign
        {
            get { return _sunSign; }
            private set
            {
                _sunSign = value;
            }
        }

        public string ChineseSign
        {
            get { return _chineeseSign; }
            private set
            {
                _chineeseSign = value;
            }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            private set
            {
                _isBirthday = value;
            }
        }
    }
}
