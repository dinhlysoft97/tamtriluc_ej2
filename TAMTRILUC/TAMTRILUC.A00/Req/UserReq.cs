using System;
using System.Collections.Generic;

namespace TAMTRILUC.A00.Req
{
    public partial class UserReq
    {
        public Guid? Apk { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte Disabled { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }

        public string Key {  get; set; }
        public int PageSize {  get; set; }
        public int PageNumber {  get; set; }
    }
}
