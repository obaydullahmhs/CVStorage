using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.Models
{
    public interface IPersonRepo
    {
        Person GetPerson(string ID);
        IEnumerable<Person> GetAllPersons();
        Person Add(Person person);
        Person Update(Person personChanges);
        Person Delete(string ID);
    }
}
