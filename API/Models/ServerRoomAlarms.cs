using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace H5_CASE_2023_API.Models
{
    public class ServerRoomAlarms
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int ServerRoomId { get; set; }
        [ForeignKey("ServerRoomId")]
        public ServerRoom ServerRoom { get; set; }

        public DateTime DateTime { get; set; }

        public double Temperture { get; set; }
        public double Humidtity { get; set; }

        public string Reason {get; set;}

    }
}
