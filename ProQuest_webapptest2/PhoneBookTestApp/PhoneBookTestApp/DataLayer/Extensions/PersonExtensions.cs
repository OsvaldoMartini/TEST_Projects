using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace PhoneBookTestApp.DataLayer.Utils
{
    public static class PersonExtensions
    {
        
        public static void SaveAsNewUser(this Person person, SQLiteConnection connection)
        {
            if (!ExistsInDb(person, connection))
            {
                connection.Execute(@"
            INSERT INTO PHONEBOOK (FirstName,LastName, PhoneNumber, Address)
            VALUES (@FirstName, @LastName, @PhoneNumber, @Address)",
                    person);
            }
        }

        public static bool ExistsInDb(this Person person, SQLiteConnection connection)
        {
            var rows = connection.Query(string.Format("SELECT COUNT(1) as 'Count' FROM PHONEBOOK WHERE FirstName = '{0}' and LastName = '{1}' ",
                person.FirstName, person.LastName));

            return (int)rows.First().Count > 0;
        }

        public static Person GetUserByName(this Person person, string name, string lastName, SQLiteConnection connection)
        {
            var personCollection = connection.Query<Person>(
                "SELECT * FROM PHONEBOOK WHERE Name = @firstName || @lastName",
                new { FirstName = name ,LastName = lastName});

            return personCollection.FirstOrDefault();
        }
    }
}
