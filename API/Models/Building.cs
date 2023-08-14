using System.ComponentModel.DataAnnotations;

namespace H5_CASE_2023_API.Models
{
    public class Building
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ServerRoom> ServerRooms { get; set; }

    }
}
