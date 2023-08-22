using H5_CASE_2023_API.Context;
using H5_CASE_2023_API.Models;
using H5_CASE_2023_API.Models.Packages;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace H5_CASE_2023_API.Repositories
{

    public interface IV1
    {
        public bool? Access_Keycard_Request(KeycardRequest accessRequest);
        public bool? Access_Code_Request(CodeRequest accessRequest);
        public SetupResponse? Setup_Request(SetupRequest setupRequest);
        public bool? Conditions_Post(ConditionsPost conditionsPost);
        public bool? Alarm_Post(AlarmPost alarmPost);
    }

    public class V1 : IV1
    {
        private readonly DatabaseContext _context;
        public V1(DatabaseContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }


        public bool? Access_Code_Request(CodeRequest accessRequest)
        {
            var _employee = _context.Employee.Include(x=>x.Keycard).Include(x=>x.AccessLevels).FirstOrDefault(x=>x.Keycard.KeycardGuid == accessRequest.KeycardId);

            if(_employee == null)
                return false;

            if(accessRequest.Code != _employee.PersonalCode)
                return false;

            _context.ServerRoomEntryActivity.Add(new ServerRoomEntryActivity{
                EmployeeId = _employee.Id,
                ServerRoomId = accessRequest.ServerRoomId,
                DateTime = DateTime.Now,
                Image = Convert.FromBase64String(accessRequest.ImageByteArray)
            });
            _context.SaveChanges();

            return true;
        }


        public bool? Access_Keycard_Request(KeycardRequest accessRequest)
        {
            var _employee = _context.Employee.Include(x=>x.Keycard).Include(x=>x.AccessLevels).FirstOrDefault(x=>x.Keycard.KeycardGuid == accessRequest.KeycardId);
            var _serverRoom = _context.ServerRoom.FirstOrDefault(x => x.Id == accessRequest.ServerRoomId);

            // SECURITY CHECK

            if (_employee == null || _serverRoom == null)
                return false;

            if (_employee.Keycard.Active == false)
                return false;

            if (_context.AccessLevel.FirstOrDefault(x => x.EmployeeId == _employee.Id && x.ServerRoomId == _serverRoom.Id) == null)
                return false;

            return true;
        }


        public SetupResponse? Setup_Request(SetupRequest setupRequest)
        {
            var _serverRoom = _context.ServerRoom.FirstOrDefault(x => x.Id == setupRequest.ServerRoomId);
            if (_serverRoom == null)
                return null;

            return new SetupResponse{
                HighHumidity = _serverRoom.HighHumidity,
                LowHumidity = _serverRoom.LowHumidity,

                HighTemperture = _serverRoom.HighTemperture,
                LowTemperture = _serverRoom.LowTemperture,

                HourlyTempertureMaxChange = _serverRoom.HourlyTempertureMaxChange,

                OperatingAllowedTimeStampStart = _serverRoom.OperatingAllowedTimeStampStart,
                OperatingAllowedTimeStampEnd = _serverRoom.OperatingAllowedTimeStampEnd
            };
        }


        public bool? Conditions_Post(ConditionsPost conditionsPost)
        {
            if (conditionsPost == null)
                return false;

            _context.ServerRoomConditions.Add(new ServerRoomConditions{
                ServerRoomId = conditionsPost.ServerRoomId,
                DateTime = conditionsPost.DateTime,
                Temperture = conditionsPost.Temperture,
                Humidtity = conditionsPost.Humidtity
            });

            _context.SaveChanges();

            return true;
        }

        public bool? Alarm_Post(AlarmPost alarmPost)
        {
            if (alarmPost == null)
                return false;

            foreach (int AlarmTypeId in alarmPost.AlarmTypes){
                _context.ServerRoomAlarms.Add(new ServerRoomAlarms{
                    ServerRoomId = alarmPost.ServerRoomId,
                    DateTime = alarmPost.DateTime,
                    Temperture = alarmPost.Temperture,
                    Humidtity = alarmPost.Humidtity,
                    AlarmTypeId = AlarmTypeId
                });
            }


            _context.SaveChanges();

            return true;
        }

    }
}
