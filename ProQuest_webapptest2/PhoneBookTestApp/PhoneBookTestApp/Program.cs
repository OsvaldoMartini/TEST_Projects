using System;
using PhoneBookTestApp.DataLayer.Extensions;
using PhoneBookTestApp.DataLayer.IRepository;
using PhoneBookTestApp.DataLayer.Model;
using PhoneBookTestApp.DataLayer.Repository;
using PhoneBookTestApp.DataLayer.Utils;

namespace PhoneBookTestApp
{
    class Program
    {
        private static IPhoneBookRepository _phonebook = new PhoneBookRepository(DatabaseUtil.GetConnection());
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.InitializeDatabase();

                 //TODO: create person objects and put them in the PhoneBook and database
                CreateAndAddPersonyList();
               
                
                // TODO: print the phone book out to System.out
                PrintPhoneBook(_phonebook);
                
                // TODO: find Cynthia Smith and print out just her entry
                FindPerson(_phonebook, "Cynthia", "Smith");
                
                InsertPerson(_phonebook);
                InsertPerson(_phonebook);

                // TODO: insert the new person objects into the database
                InsertNewPersonIntoDataBase();

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
            Console.Write("Press 'Enter' to continue");
            Console.ReadLine();
        }

        private static void InsertNewPersonIntoDataBase()
        {
            new Person { FirstName = "Constantin", LastName = "Mathias", PhoneNumber = "(235) 502-4567", Address = "342 Mont Everest St, Sea Side, NY" }.SaveAsNewUser(DatabaseUtil.GetConnection());
            new Person { FirstName = "Mathew", LastName = "Fasolo", PhoneNumber = "(221) 502-4535", Address = "185 Curon St, Los Angeles, CA" }.SaveAsNewUser(DatabaseUtil.GetConnection());
            new Person { FirstName = "Robert", LastName = "Antony", PhoneNumber = "(321) 502-2324", Address = "220 Mellon St, Sant Augustin, AL" }.SaveAsNewUser(DatabaseUtil.GetConnection());
        }

        private static void CreateAndAddPersonyList()
        {
            var personBook = new Person();
            //Creating Persons First Way
            personBook.PhoneBook.Add(new Person { FirstName = "John", LastName = "Smith", PhoneNumber = "(248) 123-4567", Address = "1234 Sand Hill Dr, Royal Oak, MI" });
            personBook.PhoneBook.Add(new Person { FirstName = "Cynthia", LastName = "Smith", PhoneNumber = "(824) 128-8758", Address = "875 Main St, Ann Arbor, MI" });
            personBook.PhoneBook.Add(new Person { FirstName = "Anna", LastName = "Trenti", PhoneNumber = "(432) 502-4342", Address = "112 Mexica Road, Font Fuego, CO" });
            //Creating Person Second Way
            var person = new Person();
            person.FirstName = "Martin";
            person.LastName = "Scosses";
            person.PhoneNumber = "(205) 503-3460";
            person.Address = "1850 Polvadero Ln, Orlando, FL";

            personBook.PhoneBook.Add(person);

            //Insert into Database (via Dapper)
            _phonebook.SaveAsList(personBook.PhoneBook);
        }

        private static void FindPerson(IPhoneBookRepository phoneBook, string firstName, string lastName)
        {
            var person = phoneBook.FindPerson(firstName, lastName);
            if (person != null)
            {
                Console.WriteLine("Result Person Found:");
                Console.WriteLine(String.Format("Name: {0} Phone: {1}, Address: {2}",
                    person.FirstName +" " + person.LastName, person.PhoneNumber, person.Address));
            }
        }

        private static void PrintPhoneBook(IPhoneBookRepository phoneBook)
        {
            var lstPhoneBook = phoneBook.GetAll();
            Console.WriteLine("List Phone Book");

            foreach (Person person in lstPhoneBook)
            {
                Console.WriteLine(String.Format("Name: {0} Phone: {1}, Address: {2}",person.FirstName+" "+person.LastName,person.PhoneNumber,person.Address));
                
            }
        }

        private static void InsertPerson(IPhoneBookRepository phoneBook)
        {
            phoneBook.Insert(new Person { FirstName = "John", LastName = "Smith", PhoneNumber = "(248) 123-4567", Address = "1234 Sand Hill Dr, Royal Oak, MI" });
            phoneBook.Insert(new Person
                {FirstName = "Cynthia", LastName = "Smith",PhoneNumber = "(824) 128-8758", Address = "875 Main St, Ann Arbor, MI"});
        }
    }
}
