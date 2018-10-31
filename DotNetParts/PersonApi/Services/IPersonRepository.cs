using Shared;

namespace PersonApi.Services
{
    public interface IPersonRepository
    {
        Person Add(Person person);
        Person Get(int id);
        Person[] GetAll();
        bool Remove(int id);
        Person Update(Person person);
    }
}