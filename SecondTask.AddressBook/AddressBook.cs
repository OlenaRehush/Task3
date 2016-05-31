using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SecondTask.AddressBook
{
    public class AddressBook
    {
        private List<User> listOfUsers = new List<User>();

        public void AddUser(User user)
        {
            if (!listOfUsers.Contains(user))
            {
                listOfUsers.Add(user);
                OnAddedUser(user);
            }
        }

        public void RemoveUser(User user)
        {
            listOfUsers.Remove(user);
            OnUserRemoved(user);
        }

        public delegate void OperationsOnUsers(User user);

        public event OperationsOnUsers UserAdded;

        private void OnAddedUser(User user)
        {
            if (UserAdded != null)
            {
                UserAdded(user);
            }
        }

        public event OperationsOnUsers UserRemoved;

        private void OnUserRemoved(User user)
        {
            if (UserRemoved != null)
            {
                UserRemoved(user);
            }
        }
     
        public List<User> FindDomen(string domen)
        {
            var list = listOfUsers.Where(s => s.Email.Contains(domen)).ToList<User>();
            return list;
        }

        public IEnumerable<User> FindGender(User.GenderType genderType, int days)
        {
            var list = from s in listOfUsers
                where s.Gender == User.GenderType.female && DateTime.Now.Day - s.TimeAdded.Day <= days
                select s;
            return list;
        }

        public List<User> BornInJanuary()
        {
            var list = listOfUsers.Where(s => s.Birthdate.Month == 1 && s.Address!=String.Empty && s.PhoneNumber != String.Empty).ToList<User>();
            return list;
        }

        public Dictionary<string, IEnumerable<User>> MansAndWomen()
        {
            var dictionary=new Dictionary<string, IEnumerable<User>>();

            var listOfMens = listOfUsers.Where(s => s.Gender == User.GenderType.male);
            var listOfWomen = listOfUsers.Where(s => s.Gender == User.GenderType.female);

            dictionary.Add("man", listOfMens);
            dictionary.Add("woman", listOfWomen);

            return dictionary;
        }


        public IEnumerable<User> RandomConditional(Func<User, int, bool> pred,int skip, int take)
        {
            return listOfUsers.Where(pred).Skip(skip).Take(take);
        }

        public int CountOfPeople(string city)
        {
            var list = from s in listOfUsers
                       where s.City == city && s.Birthdate.Day == DateTime.Now.Day && s.Birthdate.Month == DateTime.Now.Month
                       select s;
            int count = list.Count();
            return count;
        }

        

    }
}
