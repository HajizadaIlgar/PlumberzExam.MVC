using Microsoft.AspNetCore.Http;
using Plumberz.Core.Entities.Departments;
using System.ComponentModel.DataAnnotations;

namespace Plumberz.BL.ViewModels.Technicals
{
    public class TechnicalUpdateVM
    {
        [Required, MaxLength(64)]
        public string FullName { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
