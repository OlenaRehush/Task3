using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondTask.AddressBook
{
    public class User
    {
        public enum GenderType
        {
            male = 0,
            female = 1
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime TimeAdded { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            string aboutUser = " " + FirstName + " " + LastName + ", " + Gender + ", " + Birthdate.ToString() +", "+ "\n" +
                                 City + ", " + Address + ", " + "\n" + PhoneNumber + ", " + Email + "\n" + " was added " +
                               TimeAdded.ToString();
            return aboutUser;
        }
    }
}
