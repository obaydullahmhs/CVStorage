using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.Models
{
    public class MockPersonRepo : IPersonRepo
    {
        private readonly List<Person> _personList;

        public MockPersonRepo()
        {
            _personList = new List<Person>()
            {
                new Person(){ ID="1", Name = "Arnab" , Email = "arnab@gmail.com"},
                new Person(){ ID="2", Name = "Abu" , Email = "abu@gmail.com"},
                new Person(){ ID="3", Name = "Obu" , Email = "obu@gmail.com"}
            };
        }

        public Person Add(Person person)
        {
            person.ID = _personList.Max(e => e.ID) + 1;
            _personList.Add(person);
            return person;
        }

        public Person Delete(string ID)
        {
            Person person = _personList.FirstOrDefault(e => e.ID == ID);
            if (person != null)
            {
                _personList.Remove(person);
            }
            return person;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personList;
        }

        public Person GetPerson(string ID)
        {
            return _personList.FirstOrDefault(e => e.ID == ID);
        }

        public Person Update(Person personChanges)
        {
            Person person = _personList.FirstOrDefault(e => e.ID == personChanges.ID);
            if (person != null)
            {
                person.Name = personChanges.Name;
                person.Email = personChanges.Email;
                person.Phone = personChanges.Phone;
                person.Subject = personChanges.Subject;
                person.University = personChanges.University;
                person.SSC_GPA = personChanges.SSC_GPA;
                person.HSC_GPA = personChanges.HSC_GPA;
                person.Bachelor_CGPA = personChanges.Bachelor_CGPA;
                person.Project = personChanges.Project;
                person.Skills = personChanges.Skills;
                person.PhotoPath = personChanges.PhotoPath;
                person.IsAccepted = personChanges.IsAccepted;

            }
            return person;
        }
    }
}
