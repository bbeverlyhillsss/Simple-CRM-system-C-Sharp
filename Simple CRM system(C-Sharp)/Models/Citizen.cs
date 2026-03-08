using System.ComponentModel.DataAnnotations;

namespace Simple_CRM_system_C_Sharp_.Models
{
    public class Citizen
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Range(1, 10)]
        [Display(Name = "Level of Despair")]
        public int DespairLevel { get; set; }


        public List<Complaint> Complaints { get; set; } = new();
    }
}
