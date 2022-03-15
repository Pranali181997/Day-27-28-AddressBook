using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBook
{
    public class ReadWrite
    {
        public static void ReadFromStreamReader()
        {
            string path = @"C:\Users\Admin\source\repos\BATCH 111\Day-27-AddressBook\AddressBook\Sample.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String fileData = "";
                    while ((fileData = sr.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
    
    }
}

