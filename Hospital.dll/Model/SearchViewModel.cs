using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.dll.Model
{
    public class SearchViewModel
    {
        public string SearchQuery { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<Patient> Patient { get; set; }
        public List<Department> Department { get; set; }

    }
}
