namespace H5_CASE_2023_API.Models.Packages
{
    public class AlarmPost
    {
        public int ServerRoomId {get; set;}
        public double Temperture {get; set;}
        public double Humidtity {get; set;}
        public DateTime DateTime {get; set;}
        public int[] AlarmTypes {get; set;}
    }
}