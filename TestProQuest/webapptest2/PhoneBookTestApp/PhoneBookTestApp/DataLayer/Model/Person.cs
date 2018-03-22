using System.Collections.Generic;

namespace PhoneBookTestApp.DataLayer
{
    public partial class Person
    {
        public Person()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            PhoneBook = new HashSet<Person>();
        }
        public string Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Person> PhoneBook { get; set; }

    }
}
