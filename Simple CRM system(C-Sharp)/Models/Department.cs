using System.ComponentModel.DataAnnotations;


namespace Simple_CRM_system_C_Sharp_.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        
        public int? DepartmentHeadId { get; set; }
        public HeadOfdepartment? Head { get; set; }

        public List<Complaint> Complaints { get; set; } = new();
    }
}
