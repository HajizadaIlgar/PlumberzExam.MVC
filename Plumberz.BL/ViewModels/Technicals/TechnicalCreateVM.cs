using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Plumberz.BL.ViewModels.Technicals
{
    public class TechnicalCreateVM
    {
        [Required, MaxLength(64)]
        public string FullName { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
    }
}
