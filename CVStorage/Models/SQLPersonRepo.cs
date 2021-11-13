using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.Models
{
    public class SQLPersonRepo : IPersonRepo
    {
        private readonly AppDbContext context;

        public SQLPersonRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Person Add(Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
            return person;
        }

        public Person Delete(int ID)
        {
            Person person = context.Persons.Find(ID);
            if (person != null)
            {
                context.Persons.Remove(person);
                context.SaveChanges();
            }
            return person;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return context.Persons;
        }

        public Person GetPerson(int ID)
        {
            return context.Persons.Find(ID);
        }

        public Person Update(Person personChanges)
        {
            var person = context.Persons.Attach(personChanges);
            person.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return personChanges;
        }
    }
}
