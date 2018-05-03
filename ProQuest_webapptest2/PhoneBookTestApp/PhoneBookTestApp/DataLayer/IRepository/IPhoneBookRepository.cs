using System.Collections.Generic;
using PhoneBookTestApp.DataLayer.Model;
using PhoneBookTestApp.DataLayer.Utils;

namespace PhoneBookTestApp.DataLayer.IRepository
{
    public interface IPhoneBookRepository : IGenericRepository<Person>
    {

        Person FindPerson(string firstName, string lastName);
        new void Insert(Person newPerson);
        new IEnumerable<Person> GetAll();

        void SaveAsList(IEnumerable<Person> lstPerson);

    }
}
