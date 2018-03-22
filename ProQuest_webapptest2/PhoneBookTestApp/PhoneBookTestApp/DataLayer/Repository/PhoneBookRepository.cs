using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using PhoneBookTestApp.DataLayer.IRepository;
using PhoneBookTestApp.DataLayer.Utils;

namespace PhoneBookTestApp.DataLayer.Repository
{
    public class PhoneBookRepository : GenericRepository<Person>, IPhoneBookRepository
    {
        private readonly SQLiteConnection _connection;

        public PhoneBookRepository(SQLiteConnection connection)
            : base()
        {
            _connection = connection;
        }


        public Person FindPerson(string firstName, string lastName)
        {
            var personCollection = _connection.Query<Person>(
                "SELECT * FROM PHONEBOOK WHERE FirstName = @FirstName and LastName = @LastName",
                new {FirstName = firstName, LastName = lastName});

            return personCollection.FirstOrDefault();
        }

        public override void Insert(Person newPerson)
        {
            newPerson.SaveAsNewUser(_connection);
        }

        public override IEnumerable<Person> GetAll()
        {
            var personCollection = _connection.Query<Person>(
                "SELECT * FROM PHONEBOOK");

            return personCollection.ToList();
        }

        public void SaveAsList(IEnumerable<Person> lstPerson)
        {
            _connection.Execute(@"
            INSERT INTO PHONEBOOK (FirstName,LastName, PhoneNumber, Address)
            VALUES (@FirstName, @LastName, @PhoneNumber, @Address)",
                lstPerson);

        }
    }
}
