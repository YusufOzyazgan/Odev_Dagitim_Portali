using System.ComponentModel.DataAnnotations.Schema;

namespace Odev_Dagitim_Portali.Dtos
{
    public class Homework_submissionDto
    {
        public int? Submission_id { get; set; }
        public IFormFile file { get; set; }
        public int Homework_id { get; set; }
        public string? User_id { get; set; }
        

    }
}
