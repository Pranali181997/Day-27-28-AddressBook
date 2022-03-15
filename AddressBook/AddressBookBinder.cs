using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
        class AddressBookBinder
        {
            //creates a dictionary to store binder class details
            public Dictionary<string, HashSet<Contact>> Binder = new Dictionary<string, HashSet<Contact>>();
            //creates a list 
            public List<Contact> City = new List<Contact>();
            //create a dictionary to store details of city
            public Dictionary<string, List<Contact>> CityDictionary = new Dictionary<string, List<Contact>>();

            /// <summary>
            /// Adds the addr book.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="set">The set.</param>
            /// <returns></returns>
            public HashSet<Contact> AddAddrBook(string key, HashSet<Contact> set)
            {
                if (this.Binder.ContainsKey(key))
                {
                    Console.WriteLine("Address book already exists");
                    return Binder[key];
                }
                else
                {
                    Console.WriteLine("New address book created");
                    Binder.Add(key, set);
                    return Binder[key];
                }
            }
            public List<Contact> SortByCity(string cityname)
            {
                //traversing in binder class
                foreach (var key in Binder.Keys)
                {
                    //traversing for a contact by creating an object c 
                    foreach (Contact c in Binder[key])
                    {
                        if (c.City == cityname)
                            City.Add(c);
                    }
                }
                return City;
            }
            public List<Contact> SearchContactsByCity(string city)
            {
                CityDictionary[city] = SortByCity(city);
                return CityDictionary[city];
            }
        }   
}