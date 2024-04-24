using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev_Dagitim_Portali.Models
{
    public class AppUser : IdentityUser
    {
        public string Full_name { get; set; }
        public string? Student_number { get; set; }
        

        [ForeignKey("University_departments")]
        public int Department_id { get; set; }

        public List<University_department> University_departments { get; set; }

        public List<Homework> Homeworks { get; set; }
        public List<Homework_submission> Homework_submissions { get; set; }
    }
}

