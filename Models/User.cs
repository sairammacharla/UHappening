﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UHappeningServices.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public double AlbanyId { get; set; }

        public string EmailId { get; set; }

        public string  UserName { get; set; }

        public string Password { get; set; }

        public string Department { get; set; }
    }
}