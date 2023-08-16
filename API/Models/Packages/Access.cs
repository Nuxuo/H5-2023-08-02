using System.Buffers.Text;
using System.Text.Unicode;

namespace H5_CASE_2023_API.Models.Packages
{
    public class KeycardRequest
    {
        public string KeycardId {get; set;}
        public int ServerRoomId {get; set;}
    }

    public class CodeRequest
    {
        public int Code {get; set;}
        public string KeycardId {get; set;}
        public int ServerRoomId {get; set;}
        public string ImageByteArray {get; set;}
    }
}