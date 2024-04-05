using _02Kharchenko.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02Kharchenko.Tools
{
    public static class Extensions
    {
        public static void Proceed(this Person source)
        {
            source.SunSign = "";
            source.ChineseSign = "";
            source.IsAdult = null;
            source.IsBirthday = null;

            try
            {
                if (source.Name == null)
                {
                    throw new ArgumentNullException(nameof(source.Name));
                }
                if (source.Surname == null)
                {
                    throw new ArgumentNullException(nameof(source.Surname));
                }
                if (source.Birthdate == null)
                {
                    throw new ArgumentNullException(nameof(source.Birthdate));
                }


                Goroscope.checkBirthday((DateTime)source.Birthdate);
                if (Goroscope.isBirthday(((DateTime)source.Birthdate).Month, ((DateTime)source.Birthdate).Day))
                {
                    System.Windows.MessageBox.Show("З Днем народження!!!");
                }

                Thread thread1 = new Thread(() =>
                {
                    source.IsAdult = Goroscope.calculateAge((DateTime)source.Birthdate) >= 18;
                });

                Thread thread2 = new Thread(() =>
                {
                    source.SunSign = Goroscope.calculateWesternZodiac((DateTime)source.Birthdate);
                });

                Thread thread3 = new Thread(() =>
                {
                    source.ChineseSign = Goroscope.calculateChineseZodiac((DateTime)source.Birthdate);
                });

                Thread thread4 = new Thread(() =>
                {
                    source.IsBirthday = Goroscope.isBirthday(((DateTime)source.Birthdate).Month, ((DateTime)source.Birthdate).Day);
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
            catch (ExpiredBirthdateException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                source.Birthdate = null;
            }
            catch (NonExistingBirthdateException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                source.Birthdate = null;
            }
            catch (IncorrectEmailException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                source.Email = "";
              
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
