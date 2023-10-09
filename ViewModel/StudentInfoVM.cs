using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppMvcProject.ViewModel
{
   
    public class StudentInfoVM
    {
        public int Id { get; set; }

        [StringLength(100)]
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [StringLength(15)]
        [DisplayName("Phone")]
        [Required]
        public string Phone { get; set; }

        [StringLength(150)]
        [DisplayName("Address")]
        [Required]
        public string Address { get; set; }
        [DisplayName("Age")]
        [Required]
        public int? Age { get; set; }
    }
}