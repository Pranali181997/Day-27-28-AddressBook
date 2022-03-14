using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBookBinder
    {
        //creating a dictionary by passing string and list as arguements
        public Dictionary<string, List<Contact>> Binder = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// Adds the addr book.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public List<Contact> AddAddrBook(string key, List<Contact> list)
        {
            //checks whether key is present in binder class
            if (this.Binder.ContainsKey(key))
            {
                Console.WriteLine("Address book already exists");
                return Binder[key];
            }
            else
            {
                Console.WriteLine("New address book created");
                Binder.Add(key, list);
                return Binder[key];
            }
        }
    }
}