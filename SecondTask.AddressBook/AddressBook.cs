using System;
using System.Collections.Generic;
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
    }
}
