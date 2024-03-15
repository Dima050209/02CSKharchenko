using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kharchenko
{
    class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdate;
        private bool _isAdult;
        private string _sunSign;
        private bool _isBirthday;

        public Person(string name, string surname, string email, DateTime birthdate)
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

        public Person(string name, string surname, DateTime birthdate)
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

        public DateTime Date
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
            }

        }
    }
}
