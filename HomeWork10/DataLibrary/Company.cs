using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public virtual List<Department> Departments { get; set; }
    }
}
