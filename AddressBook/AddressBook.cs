using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        //creates a list
        public List<Contact> People;

        public AddressBook()
        {
            People = new List<Contact>();
        }


        public Contact FindContact(string fname)
        {
            //finding the person's contact by first name
            Contact contact = People.Find((person) => person.FirstName == fname);
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
    }
}