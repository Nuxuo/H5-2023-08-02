using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_CASE_2023_API.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public int PersonalCode { get; set; }

        public int KeycardId { get; set; }
        [ForeignKey("KeycardId")]
        public Keycard Keycard { get; set; }

        public ICollection<AccessLevel> AccessLevels { get; set; }
        public ICollection<ServerRoomEntryActivity> ServerRoomEntryActivities { get; set; }

    }
}
