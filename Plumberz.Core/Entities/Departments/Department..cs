using Plumberz.Core.Entities.Commons;
using Plumberz.Core.Entities.Technicals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plumberz.Core.Entities.Departments
{
    public class Department:BaseEntity
    {
        public string DepartmentName {  get; set; }
        public ICollection<Technical> Technicals { get; set; }
    }
}
