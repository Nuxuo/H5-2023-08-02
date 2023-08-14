using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_CASE_2023_API.Models
{
    public class ServerRoomConditions
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int ServerRoomId { get; set; }
        [ForeignKey("ServerRoomId")]
        public ServerRoom ServerRoom { get; set; }

        public DateTime DateTime { get; set; }

        public double Temperture { get; set; }
        public double Humitity { get; set; }
    }
}
