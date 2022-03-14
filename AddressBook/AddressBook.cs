using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        //creation of list
        public static List<Contact> People;
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
    }
}