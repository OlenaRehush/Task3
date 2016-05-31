using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Timers;
using SecondTask.AddressBook;
using SecondTask.Logger;

namespace SecondTask
{
    static class Program
    {
        static ILogger log = new ConsoleLogger();

        static void Main(string[] args)
        {
            AddressBook.AddressBook addressBook = new AddressBook.AddressBook();

            addressBook.UserAdded += OnAddedUser;
            addressBook.UserRemoved += OnUserRemoved;

            List<User> peoplelist = new List<User>()
            {
                new User()
                {
                    FirstName = "Ivan",
                    LastName = "Dmytriv",
                    Address = "Gorodocka, 75/34",
                    Birthdate = new DateTime(1996, 10, 20),
                    TimeAdded = new DateTime(2016, 5, 27, 0, 0, 0),
                    City = "Kyiv",
                    Email = "somethingemail@gmail.com",
                    PhoneNumber = "+380630000000",
                    Gender = User.GenderType.male
                },
                new User()
                {
                    FirstName = "Olga",
                    LastName = "Yariv",
                    Address = "Antonovycha",
                    Birthdate = new DateTime(1997, 5, 27),
                    TimeAdded = new DateTime(2016, 5, 27, 0, 0, 0),
                    City = "Lviv",
                    Email = "somethingemail@ukr.net",
                    PhoneNumber = "+380630000000",
                    Gender = User.GenderType.female
                },
                 new User()
                {
                    FirstName = "Maryna",
                    LastName = "Donchenko",
                    Address = "Antonovycha",
                    Birthdate = new DateTime(1995, 1, 27),
                    TimeAdded = new DateTime(2016, 5, 29, 0, 0, 0),
                    City = "Lviv",
                    Email = "somethingemail@ukr.net",
                    PhoneNumber = "+380630000000",
                    Gender = User.GenderType.female
                },
                new User()
                {
                    FirstName = "Oleg",
                    LastName = "Prociv",
                    Address = "Shyroka",
                    Birthdate = new DateTime(1992, 1, 15),
                    TimeAdded = new DateTime(2016, 2, 29, 0, 0, 0),
                    City = "Lviv",
                    Email = "somethingemail@ukr.net",
                    PhoneNumber = "+380630000000",
                    Gender = User.GenderType.male
                },
                new User()
                {
                    FirstName = "Sofia",
                    LastName = "Prociv",
                    Address = "Shyroka",
                    Birthdate = new DateTime(1992, 5, 31),
                    TimeAdded = new DateTime(2016, 2, 29, 0, 0, 0),
                    City = "Kyiv",
                    Email = "somethingemail@ukr.net",
                    PhoneNumber = "+380630000000",
                    Gender = User.GenderType.male
                }
            };

            foreach (var x in peoplelist)
            {
                addressBook.AddUser(x);
            }
            

            Console.WriteLine("================================================================");
            //has domen gmail.com
            var domenGmail = addressBook.FindDomen("@gmail.com");
            Print(" People, which have domain gmail.com : ",
                  "There aren't people within this domain", domenGmail);

            Console.WriteLine("================================================================");
            //is a female and was added for the last 10 days
            var listOfFemailes = addressBook.FindGender(User.GenderType.female, 10);
            Print("Femailes, which was added for the last 10 days",
                  "There aren't this people", listOfFemailes);

            Console.WriteLine("================================================================");
            //born in January and fields "Address" and "PhoneNumber" are not empty
            var bornInJanuary = addressBook.BornInJanuary();
            bornInJanuary.Sort((a,b)=>a.LastName.CompareTo(b.LastName));
            bornInJanuary.Reverse();
            Print("People, which born in January",
                  "There aren't this people", bornInJanuary);

            Console.WriteLine("================================================================");
            //mans and women
            var dict = addressBook.MansAndWomen();
            foreach (var x in dict)
            {
                if (x.Key == "man")
                {
                    Console.WriteLine(" Mans: ");
                    Print("", "There aren't mens", x.Value);
                }
                else if (x.Key == "woman")
                {
                    Console.WriteLine(" Woman: ");
                    Print("", "There aren't women", x.Value);
                }
            }
            Console.WriteLine("================================================================");

            var list = addressBook.RandomConditional((u, i) => u.FirstName == "Ivan", 20, 10);
            Print("People, which have name Ivan", "There aren't this people", list);
           
            Console.WriteLine("================================================================");

            //count of people, who has birthsday today and live in something city
            Console.WriteLine("Count of people, who has birthsday today and live in Kyiv: ");
            Console.WriteLine(addressBook.CountOfPeople("Kyiv"));

            Console.ReadKey();
        }

        private static void OnUserRemoved(User user)
        {
            log.Info("User " + user.FirstName + " " + user.LastName + " was removed");
        }

        private static void OnAddedUser(User user)
        {
            log.Info("User " + user.FirstName + " " + user.LastName + " was added");
        }

        static void Print(string str1, string str2, List<User> list)
        {
            Console.WriteLine(str1);
            if (list.Count != 0)
                foreach (var a in list)
                {
                    Console.WriteLine(a);
                    Console.WriteLine();
                }
            else
                Console.WriteLine(str2);
        }
      
        static void Print(string str1, string str2, IEnumerable<User> list)
        {
            Console.WriteLine(str1);
            if (list.Count() != 0)
                foreach (var a in list)
                {
                    Console.WriteLine(a);
                    Console.WriteLine();
                }
            else
                Console.WriteLine(str2);
        }
    }
}
