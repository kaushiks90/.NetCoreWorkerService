﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class UrlStatusHistory 
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public DateTime RequestDateUtc { get; } = DateTime.UtcNow;
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
    }
}