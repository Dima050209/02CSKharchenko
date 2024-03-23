using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02Kharchenko
{
    class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birthdate = null;
        private bool? _isAdult = null;
        private string _sunSign;
        private string _chineeseSign;
        private bool? _isBirthday = null;

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

        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
            }
        }

        public bool? IsAdult
        {
            get { return _isAdult; }
            set
            {
                _isAdult = value;
            }
        }

        public string SunSign
        {
            get { return _sunSign; }
            set
            {
                _sunSign = value;
            }
        }

        public string ChineseSign
        {
            get { return _chineeseSign; }
            set
            {
                _chineeseSign = value;
            }
        }

        public bool? IsBirthday
        {
            get { return _isBirthday; }
            set
            {
                _isBirthday = value;
            }
        }
    }
}
