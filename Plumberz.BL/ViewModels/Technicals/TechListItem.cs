using Plumberz.Core.Entities.Departments;

namespace Plumberz.BL.ViewModels.Technicals
{
    public class TechListItem
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
