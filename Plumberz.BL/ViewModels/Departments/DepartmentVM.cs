using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plumberz.BL.ViewModels.Departments
{
    public class DepartmentVM
    {
        [Required,MaxLength(64,ErrorMessage ="Maksimum 64 Karakter daxil edile biler")]
        public string DepartmentName { get; set; }
    }
}
