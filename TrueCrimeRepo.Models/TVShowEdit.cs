﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrimeRepo.Models
{
    public class TVShowEdit
    {
        public int TVShowID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Channel_OnlineStream { get; set; }
    }
}
