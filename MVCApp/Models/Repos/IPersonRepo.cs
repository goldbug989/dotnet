using MVCApp.Models.ViewModels;
using System.Collections.Generic;

namespace MVCApp.Models.Repos
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetPeople();
        Person GetPersonById(int id);

        void AddPerson(Person person);

        void Remove(int id);

        void Edit(Person person);
    }
}
