﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    [Serializable]
    public class SearchingMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime AtCreate { get; set; }

        public DateTime AtUpdate { get; set; }

        public string Uploaded_Files { get; set; }
    }
}
    