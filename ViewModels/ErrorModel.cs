﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Others
{
    public class ErrorModel
    {
        public int HttpStatusCode { get; set; }
        public Exception Exception { get; set; }
    }
}