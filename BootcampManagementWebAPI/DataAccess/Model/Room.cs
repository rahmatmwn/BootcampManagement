﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}