using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace H5_CASE_2023_API.Models
{
    public class AlarmTypes
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string ReasonText {get; set;}

        public ICollection<ServerRoomAlarms> ServerRoomAlarms { get; set; }

    }
}
