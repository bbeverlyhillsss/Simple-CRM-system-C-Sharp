using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;



namespace Simple_CRM_system_C_Sharp_.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CitizenId { get; set; }
        [ForeignKey("CitizenId")]
        public Citizen? Citizen { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }


        [Display(Name = "Прикріплений доказ")]
        public string? EvidenceFilePath { get; set; }


        [NotMapped]
        [Display(Name = "Завантажити документ (PDF/JPG)")]
        public IFormFile? EvidenceFile { get; set; }


    }
}
