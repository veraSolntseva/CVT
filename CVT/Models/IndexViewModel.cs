using System.Collections.Generic;
using System.Linq;

namespace CVT.Models
{
    public class IndexViewModel
    {
        public List<PersonViewModel> PersonList { get; set; }

        public IndexViewModel() { }

        public IndexViewModel(IEnumerable<PersonViewModel> persons)
        {
            PersonList = persons.ToList();
        }
    }
}
