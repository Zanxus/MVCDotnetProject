﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDotnetProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RuntimeInMin { get; set; }
    }
}