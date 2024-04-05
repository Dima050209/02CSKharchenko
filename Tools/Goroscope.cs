using _02Kharchenko.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02Kharchenko.Tools
{
    class Goroscope
    {
        public static bool isBirthday(int month, int day)
        {
           
            return month == DateTime.Today.Month && day == DateTime.Today.Day;
        }
        public static string calculateChineseZodiac(DateTime birthday)
        {
            checkBirthday(birthday);
           
            int year = birthday.Year;
            if (year < 1924)
            {
                return "Could not calculate chinese zodiac sign.";
            }
            int startYear = 1924;
            int offset = (year - startYear) % 12;

            string[] chineseZodiacSigns = { "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака", "Свиня" };

            return chineseZodiacSigns[offset];
        }
        public static string calculateWesternZodiac(DateTime birthday)
        {
            checkBirthday(birthday);
           
            int day = birthday.Day;
            int month = birthday.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
                return "Овен";
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
                return "Телець";
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
                return "Близнюки";
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
                return "Рак";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
                return "Лев";
            else if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
                return "Діва";
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
                return "Терези";
            else if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
                return "Скорпіон";
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
                return "Стрілець";
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
                return "Козеріг";
            else if ((month == 1 && day >= 21) || (month == 2 && day <= 20))
                return "Водолій";
            else if ((month == 2 && day >= 21) || (month == 3 && day <= 20))
                return "Риби";
            else
                return "";
        }
        public static int calculateAge(DateTime birthday)
        {
           
            int age = DateTime.Today.Year - birthday.Year;
            if (birthday.Month > DateTime.Today.Month)
            {
                age--;
            }
            else if (birthday.Month == DateTime.Today.Month && birthday.Day > DateTime.Today.Day)
            {
                age--;
            }
            return age;
        }
        public static void checkBirthday(DateTime birthday)
        {
            if (birthday > DateTime.UtcNow)
            {
                throw new NonExistingBirthdateException(birthday);
            }
            if (calculateAge(birthday) > 135)
            {
                throw new ExpiredBirthdateException(birthday);
            }
        }
    }
}
