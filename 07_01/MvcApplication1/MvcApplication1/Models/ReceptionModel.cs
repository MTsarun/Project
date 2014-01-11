﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MvcApplication1.Models

{
        [Table("Receptions")]
        public class Reception
        {
            public int Id { get; set; }
            public string NameReception { get; set; }
            public string DataReception { get; set; }
            public string AboutReception { get; set; }
            public int TimeReception { get; set; }
        }
    }