﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_CASE_2023_API.Models
{
    public class ServerRoom
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        public TimeSpan OperatingAllowedTimeStampStart { get; set; }
        public TimeSpan OperatingAllowedTimeStampEnd { get; set; }

        public ICollection<AccessLevel> AccessLevels { get; set; }
        public ICollection<ServerRoomConditions> ServerRoomConditions { get; set; }
        public ICollection<ServerRoomEntryActivity> ServerRoomEntryActivities { get; set; }
        public ICollection<ServerRoomEntryAlarms> ServerRoomEntryAlarms { get; set; }

    }
}
