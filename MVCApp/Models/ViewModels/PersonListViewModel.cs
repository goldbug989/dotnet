using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models.ViewModels
{
    public class PersonListViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}
