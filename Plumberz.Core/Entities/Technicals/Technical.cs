using Plumberz.Core.Entities.Commons;
using Plumberz.Core.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plumberz.Core.Entities.Technicals
{
    public class Technical : BaseEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
