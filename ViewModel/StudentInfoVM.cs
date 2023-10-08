using System.ComponentModel.DataAnnotations;

namespace WebAppMvcProject.ViewModel
{
   
    public class StudentInfoVM
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public int? Age { get; set; }
    }
}