﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LockdownSms.Models
{
    public class User
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
