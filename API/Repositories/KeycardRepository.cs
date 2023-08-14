using H5_CASE_2023_API.Context;
using H5_CASE_2023_API.Models;
using Microsoft.EntityFrameworkCore;

namespace H5_CASE_2023_API.Repositories
{

    public interface IKeycardRepository
    {
        public int? Access_Keycard_Request(string keycard_guid, int serverRoomId);
    }

    public class KeycardRepository : IKeycardRepository
    {
        private readonly DatabaseContext _context;
        public KeycardRepository(DatabaseContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }



        public int? Access_Keycard_Request(string keycard_guid, int serverRoomId)
        {
            var _employee = _context.Employee.Include(x=>x.Keycard).Include(x=>x.AccessLevels).FirstOrDefault(x=>x.Keycard.KeycardGuid == keycard_guid);
            var _serverRoom = _context.ServerRoom.FirstOrDefault(x => x.Id == serverRoomId);

            if (_employee == null || _serverRoom == null)
                return null;

            if (_employee.Keycard.Active == false)
                return null;

            if (!check_access_keycard (_employee, _serverRoom) )
                return null;

            return _employee.PersonalCode;

        }

        public bool check_access_keycard(Employee employee, ServerRoom serverRoom )
        {
            AccessLevel _access = _context.AccessLevel.FirstOrDefault(x => x.EmployeeId == employee.Id && x.ServerRoomId == serverRoom.Id);
            return _access == null ? false : true;
        }
    }
}
