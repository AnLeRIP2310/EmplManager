﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MessageJoinUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime AtCreate { get; set; }
        public int status { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
    }
}