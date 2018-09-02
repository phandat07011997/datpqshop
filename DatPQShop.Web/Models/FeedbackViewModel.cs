﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatPQShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { set; get; }
        
        public string Name { set; get; }

        public string Email { set; get; }

        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }

        public bool Status { set; get; }

        public ContactDetailViewModel ContactDetail { set; get; }
    }
}