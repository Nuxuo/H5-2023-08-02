using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace H5_CASE_2023_API.Models
{
    public class ServerRoomEntryActivity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int ServerRoomId { get; set; }
        [ForeignKey("ServerRoomId")]
        public ServerRoom ServerRoom { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public DateTime DateTime { get; set; }

        public Byte[] Image { get; set; }
    }
}
