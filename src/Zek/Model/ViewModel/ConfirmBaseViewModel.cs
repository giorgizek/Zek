﻿using System;

namespace Zek.Model.ViewModel
{
    public class ConfirmBaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public string ConfirmUrl { get; set; }
        public string Code { get; set; }
        public int? ExpireMinutes { get; set; }
        public DateTime ValidTo { get; set; }
        public string Ip { get; set; }
    }
}