﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vy.Models
{
    public class Passenger
    {
        public int PassengerID { get; set; }

        public string PassengerType { get; set; }
    }
}