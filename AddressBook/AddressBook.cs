using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
namespace AddressBook
{
    class AddressBook
    {
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
          
            Contact result = FindContact(FirstName);

            if (result == null)
            {
                People.Add(contact);
                return true;
            }
            else
                return false;
        }


        public void sortingmethod()
        {
            Console.WriteLine("Select sorting for : 1.City 2.State 3.Pincode");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
                    break;

                case 2:
                    People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.State, y.State)));
                    break;

                 case 3:
                    People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
                    break;
                default:
                    break;
             
            }
            foreach (Contact c in People)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
            }
        }
        public bool RemoveContact(string name)
        {

            Contact c = FindContact(name);
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
        public void AlphabeticallyArrange()
        {
            //creation of list
            List<string> alphabeticalList = new List<string>();
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
        //public void SortByPincode()
        //{
          
        //    People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
            
        //    foreach (Contact c in People)
        //    {
        //        Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
        //    }

        //}
        //public void SortByCity()
        //{
           
        //    People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
            
        //    foreach (Contact c in People)
        //    {
        //        Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
        //    }

        //}
        //public void SortByState()
        //{
           
        //    People.Sort(new Comparison<Contact>((x, y) => string.Compare(x.State, y.State)));
          
        //    foreach (Contact c in People)
        //    {
        //        Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.PhoneNumber + "\t" + c.Email);
        //    }

        //}

        public void WriteUsingStreamWriter()
        {
            string FilePath = @"C:\Users\Admin\source\repos\BATCH 111\Day-27-AddressBook\AddressBook\Sample.txt";

            using (StreamWriter sw = File.CreateText(FilePath))
            {
                foreach (var con in People)
                {
                    Console.WriteLine("Added record in file");
                    sw.WriteLine("****************Peoples In address book********************");
                    sw.WriteLine("First Name:" + con.FirstName);
                    sw.WriteLine("Last Name:" + con.LastName);
                    sw.WriteLine("Address:" + con.Address);
                    sw.WriteLine("City:" + con.City);
                    sw.WriteLine("Email:" + con.Email);
                    sw.WriteLine("PhoneNumber:" + con.PhoneNumber);
                    sw.WriteLine("ZipCode:" + con.ZipCode);
                    sw.WriteLine("State:" + con.State);
                }
            }
        }
        public void WriteUsingCSV()
        {
            string Filepath = @"C:\Users\Admin\source\repos\BATCH 111\Day-27-AddressBook\AddressBook\TextFile1.csv";
            using (CsvWriter sw = new CsvWriter(new StreamWriter(Filepath), CultureInfo.InvariantCulture))
            {
               sw.WriteHeader<Contact>();
                sw.WriteRecords("\n");
                sw.WriteRecords(People);
            }
        }
        //Write A JSON file
        public void WriteToJsonFile()
        {
            string filePath = @"C:\Users\Admin\source\repos\BATCH 111\Day-27-AddressBook\AddressBook\TextFile1.json";
            if (File.Exists(filePath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    using (JsonWriter writer = new JsonTextWriter(streamWriter))
                    {
                        jsonSerializer.Serialize(writer, People);
                    }
                }
               
            }
            else
            {
                Console.WriteLine("File not exists!");
            }
        }
      
    }   
}