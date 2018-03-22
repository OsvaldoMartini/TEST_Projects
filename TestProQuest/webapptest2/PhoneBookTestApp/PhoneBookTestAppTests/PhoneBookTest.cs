using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookTestApp.DataLayer;

namespace PhoneBookTestAppTests
{
    [TestClass]
    public class PhoneBookTest
    {
        //Inicialização dentro dos Testes	
        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            
        }

        [TestMethod]
        public void Create_Person_Objects_Pass()
        {
            //TODO: create person objects 
            var person = new Person();
            person.FirstName = "Martin";
            person.LastName = "Scosses";
            person.PhoneNumber = "(205) 503-3460";
            person.Address = "1850 Polvadero Ln, Orlando, FL";

            Assert.IsNotNull(person != null, "Person Created");//passes

        }

        [TestMethod]
        public void Create_List_Person_Objects_Fail()
        {
            //TODO: put them in the PhoneBook and database
            var personBook = new Person();
            personBook.PhoneBook.Add(new Person { FirstName = "John", LastName = "Smith", PhoneNumber = "(248) 123-4567", Address = "1234 Sand Hill Dr, Royal Oak, MI" });
            personBook.PhoneBook.Add(new Person { FirstName = "Cynthia", LastName = "Smith", PhoneNumber = "(824) 128-8758", Address = "875 Main St, Ann Arbor, MI" });
            personBook.PhoneBook.Add(new Person { FirstName = "Anna", LastName = "Trenti", PhoneNumber = "(432) 502-4342", Address = "112 Mexica Road, Font Fuego, CO" });

            Assert.AreEqual(personBook.PhoneBook.GetType(), typeof(ICollection<Person>));   //fails
        }

        [TestMethod]
        public void Create_List_Person_Objects_Pass()
        {
            //TODO: put them in the PhoneBook and database
            var personBook = new Person();
            personBook.PhoneBook.Add(new Person { FirstName = "John", LastName = "Smith", PhoneNumber = "(248) 123-4567", Address = "1234 Sand Hill Dr, Royal Oak, MI" });
            personBook.PhoneBook.Add(new Person { FirstName = "Cynthia", LastName = "Smith", PhoneNumber = "(824) 128-8758", Address = "875 Main St, Ann Arbor, MI" });
            personBook.PhoneBook.Add(new Person { FirstName = "Anna", LastName = "Trenti", PhoneNumber = "(432) 502-4342", Address = "112 Mexica Road, Font Fuego, CO" });

            Assert.IsInstanceOfType(personBook.PhoneBook, typeof(ICollection<Person>));     //passes
        }


        [TestMethod]
        public void findPerson()
        {
            //Controlling the behavior
            //var myMock = MockRepository.GenerateMock<IPhoneBook>();
            //PhoneBook myClass = new PhoneBook(myMock);

            //myMock.Expect(m => m.FindPerson("Cynthia", "Scort"));

            //myClass.FindPerson("Cynthia", "Scort");

            //myMock.VerifyAllExpectations();
        }
    }
}
