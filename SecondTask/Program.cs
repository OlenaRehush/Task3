using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondTask.AddressBook;
using SecondTask.Logger;

namespace SecondTask
{

    class Program
    {
        static ILogger log = new ConsoleLogger();

        static void Main(string[] args)
        {
            AddressBook.AddressBook addressBook = new AddressBook.AddressBook();

            addressBook.UserAdded += OnAddedUser;
            addressBook.UserRemoved += OnUserRemoved;

            User somethingUser = new User()
            {
                FirstName = "SomethingFirstName",
                LastName = "SomethingLastName",
                Address = "SomethingAddress",
                Birthdate = new DateTime(2016, 5, 27),
                TimeAdded = new DateTime(2016, 5, 27, 0, 0, 0),
                City = "Lviv",
                Email = "somethingemail@gmail.com",
                PhoneNumber = "+380630000000",
                Gender = User.GenderType.female
            };

            addressBook.AddUser(somethingUser);

            addressBook.RemoveUser(somethingUser);

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
    }
}
