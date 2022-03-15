using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        //declaration
        public List<Contact> People;

        public AddressBook()
        {
            People = new List<Contact>();
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

        /// <summary>
        /// Sorts the by pincode.
        /// </summary>
        public void SortByPincode()
        {
            //Comparision method is used to compare two objects of same type
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
            //traversing through contact class
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }

        /// <summary>
        /// Sorts the by city.
        /// </summary>
        public void SortByCity()
        {
            //Comparision method is used to compare two objects of same type
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
            //traversing through contact class
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }

        /// <summary>
        /// Sorts the state 
        /// </summary>
        public void SortByState()
        {
            //Comparision method is used to compare two objects of same type
            People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.State, y.State)));
            //traverse through contact class
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }

        }
    }
}