using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev_Dagitim_Portali.Models
{
    public class AppUser : IdentityUser
    {
        public string Full_name { get; set; }
        public string? Student_number { get; set; }
        

        [ForeignKey("Classes")]
        public int Class_id { get; set; }

        public List<Class> Classes { get; set; }

        public List<Homework> Homeworks { get; set; }
        public List<HomeworkSubmission> HomeworkSubmissions { get; set; }
    }
}

