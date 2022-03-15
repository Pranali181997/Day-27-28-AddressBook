using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        //declaration
        public HashSet<Contact> People;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// </summary>
        public AddressBook()
        {
            People = new HashSet<Contact>();
        }

        /// <summary>
        /// Finds the contact.
        /// </summary>
        /// <param name="fname">The fname.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="FirstName">The first name.</param>
        /// <param name="LastName">The last name.</param>
        /// <param name="Address">The address.</param>
        /// <param name="City">The city.</param>
        /// <param name="State">The state.</param>
        /// <param name="ZipCode">The zip code.</param>
        /// <param name="PhoneNumber">The phone number.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
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
            //otherwise returns fals
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
    }
}
