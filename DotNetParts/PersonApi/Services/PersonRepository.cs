using Shared;
using System.Collections.Generic;
using System.Linq;

namespace PersonApi.Services
{

    public class InMemoryPersonRepository : IPersonRepository
    {
        private readonly Dictionary<int, Person> personDictionary = new Dictionary<int, Person>() {
            { 1, new Person {Id = 1, Lastname= "Keller", Firstname = "Daniel"  } },
            { 2, new Person {Id = 2, Lastname= "Meyer", Firstname = "Manuel"  } },
            { 3, new Person {Id = 3, Lastname= "Gassmann", Firstname = "Thomas"  } },
            { 4, new Person {Id = 4, Lastname= "Huber", Firstname = "Thomas"  } },
        };

        public Person[] GetAll()
        {
            return personDictionary.Select(element => element.Value).ToArray();
        }

        public Person Get(int id)
        {
            if (!personDictionary.ContainsKey(id))
            {
                return null;
            }
            return personDictionary[id];
        }

        public Person Add(Person person)
        {
            var newId = GetNextId(); 
            person.Id = newId;
            personDictionary.Add(newId, person);
            return person;
        }

        public Person Update(Person person)
        {
            if (!personDictionary.ContainsKey(person.Id))
            {
                return null;
            }
            personDictionary[person.Id] = person;
            return person;
        }

        public bool Remove(int id)
        {
            if (!personDictionary.ContainsKey(id))
            {
                return false;
            }
            personDictionary.Remove(id);
            return true;
        } 

        private int GetNextId()
        {
            return personDictionary.Max((p) => p.Key) + 1;
        }
    }
}
