using System.ComponentModel.DataAnnotations;

namespace Simple_CRM_system_C_Sharp_.Models
{
    public class HeadOfdepartment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Chief Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Bureaucratic Rank")]
        public BureaucraticRank Rank { get; set; } = BureaucraticRank.JuniorPaperPusher;

        // Связи
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
