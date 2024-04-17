using System.ComponentModel.DataAnnotations;

namespace Odev_Dagitim_Portali.Dtos
{
    public class University_departmentDto
    {
        [Key]
        public int Department_id { get; set; }

        public string Department_name { get; }
    }
}
