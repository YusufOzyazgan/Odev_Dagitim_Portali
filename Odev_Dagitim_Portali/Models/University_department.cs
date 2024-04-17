using System.ComponentModel.DataAnnotations;

namespace Odev_Dagitim_Portali.Models
{
    public class University_department
    {
        [Key]
        public int Department_id { get; set; }  

        public string Department_name { get; set; }
        public List<Lesson> Lessons { get; set; }
        
        public List<AppUser> AppUsers { get; set; }    
    }
}
