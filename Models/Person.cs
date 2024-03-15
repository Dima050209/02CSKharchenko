using _02Kharchenko.Models;
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

        public void Proceed()
        {
            if(_name == null)
            {
                throw new ArgumentNullException(nameof(_name));
            }
            if (_surname == null)
            {
                throw new ArgumentNullException(nameof(_surname));
            }
            if (_email == null)
            {
                throw new ArgumentNullException(nameof(_email));
            }
            if (_birthdate == DateTime.MinValue)
            {
                throw new ArgumentNullException(nameof(_birthdate));
            }

            _goroscope.checkBirthday(_birthdate);

            Thread thread1 = new Thread(() => {
                _isAdult = _goroscope.calculateAge(_birthdate) >= 18;
            });

            Thread thread2 = new Thread(() =>
            {
                _chineeseSign = _goroscope.calculateChineseZodiac(_birthdate);
            });

            Thread thread3 = new Thread(() => {
                _sunSign = _goroscope.calculateWesternZodiac(_birthdate);
            });

            Thread thread4 = new Thread(() => {
                _isBirthday = _goroscope.isBirthday(_birthdate.Month, _birthdate.Day);
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
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
