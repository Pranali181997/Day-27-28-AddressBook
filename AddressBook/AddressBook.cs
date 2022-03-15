using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {

        public HashSet<Contact> People;

        public AddressBook()
        {
            People = new HashSet<Contact>();
        }
        public Contact FindContact(string fname)
        {
            Contact contact = null;
            foreach (var person in People)
            {
                if (person.FirstName.Equals(fname))
                {
                    contact = person;
                    break;
                }
            }
            return contact;
        }

        public bool AddContact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            Contact contact = new Contact(FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email);
            //finds contact and stores into result
            Contact result = FindContact(FirstName);
            //checks if result is empty
            //then adds the contact and returns true
            //else returns false
            if (result == null)
            {
                People.Add(contact);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Removes the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool RemoveContact(string name)
        {
            //creation of object for contact
            Contact c = FindContact(name);
            //checks in c for the contact
            //if it is true then contact will be removed
            //otherwise returns false
            if (c != null)
            {
                People.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Alphabeticallies the arrange.
        /// </summary>
        public void AlphabeticallyArrange()
        {
            //creation of list
            List<string> alphabeticalList = new List<string>();
            //traverses through contact class
            //and returns the string after sorting that represents the current object
            //and then adds that object which is sorted to the end of list
            foreach (Contact c in People)
            {
                string sort = c.ToString();
                alphabeticalList.Add(sort);
            }
            alphabeticalList.Sort();
            foreach (string s in alphabeticalList)
            {
                Console.WriteLine(s);
            }
        }
    }
}
