﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding.StaticResource.AddNew.Model
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string BookTitle { get; set; }
        public bool IsMVP { get; set; }
    }
}
