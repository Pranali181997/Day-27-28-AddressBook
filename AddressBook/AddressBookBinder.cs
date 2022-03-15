using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBookBinder
    {
        //dictionary to store details of binder class
        public Dictionary<string, HashSet<Contact>> Binder = new Dictionary<string, HashSet<Contact>>();
        //dictinary to store city
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

        /// <summary>
        /// Distincts the cities.
        /// </summary>
        /// <returns></returns>
        public List<string> DistinctCities()
        {
            List<string> City = new List<string>();
            foreach (var key in Binder.Keys)
            {
                foreach (Contact c in Binder[key])
                {
                    if (City.Contains(c.City))
                        continue;
                    else
                        City.Add(c.City);
                }
            }
            return City;
        }

        /// <summary>
        /// Creates the dictionary.
        /// </summary>
        public void CreateDictionary()
        {
            //creates a list
            List<string> City1 = DistinctCities();
            //traverse through city
            foreach (string city in City1)
            {
                //creates a list
                List<Contact> CityContact = new List<Contact>();
                foreach (var key in Binder.Keys)
                {
                    //traverse through contact in binder
                    //if city matches
                    //then that city will be added
                    foreach (Contact c in Binder[key])
                    {
                        if (c.City == city)
                            CityContact.Add(c);
                    }
                }
                //determines whether dictionary contains specified key value
                //returns true if that dictionary key value matches with the specified key
                //and adds that contact
                //In else part if that key value is not found
                //then the keyvalue will be added i.e the city is added to dictionary
                if (this.CityDictionary.ContainsKey(city))
                    CityDictionary[city] = CityContact;
                else
                    CityDictionary.Add(city, CityContact);
            }
        }
    }
}