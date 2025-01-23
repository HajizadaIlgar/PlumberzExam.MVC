using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plumberz.Core.Entities.Commons
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; } 
    }
}
