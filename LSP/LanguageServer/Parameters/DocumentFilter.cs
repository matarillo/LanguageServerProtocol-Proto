﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    public class DocumentFilter
    {
        public string language { get; set; }

        public string scheme { get; set; }

        public string pattern { get; set; }
    }
}
