using System.ComponentModel.DataAnnotations;

namespace H5_CASE_2023_API.Models
{
    public class Keycard
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string KeycardGuid { get; set; }

        public bool Active { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
