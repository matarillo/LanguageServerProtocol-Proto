﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    public class Location
    {
        public Uri Uri { get; set; }
        public Range range { get; set; }
    }
}
