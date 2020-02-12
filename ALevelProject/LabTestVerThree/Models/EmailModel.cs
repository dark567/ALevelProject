﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestVerThree.Models
{
    public class EmailModel
    {
        public string Subject { get; set; }

        public string From { get; set; } = "admins@mail.com";

        public string To { get; set; }

        public string Body { get; set; }
    }
}