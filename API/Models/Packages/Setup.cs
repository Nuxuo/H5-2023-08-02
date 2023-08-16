namespace H5_CASE_2023_API.Models.Packages
{
    public class SetupRequest
    {
        public int ServerRoomId {get; set;}
    }

    public class SetupResponse
    {   
        public double HighHumidity {get; set;}
        public double LowHumidity {get; set;}
        public double HighTemperture {get; set;}
        public double LowTemperture {get; set;}
        public double HourlyTempertureMaxChange {get; set;}
        public TimeSpan OperatingAllowedTimeStampStart {get; set;}
        public TimeSpan OperatingAllowedTimeStampEnd {get; set;}
    }
}