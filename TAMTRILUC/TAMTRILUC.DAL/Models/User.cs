﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TAMTRILUC.DAL.Models
{
    public partial class User
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
    }
}
