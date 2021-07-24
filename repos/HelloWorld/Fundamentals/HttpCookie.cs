﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class HttpCookie
    {
        //readonly so can't reinitialise
        private readonly Dictionary<string, string> _dictionary;
        public DateTime Expiry { get; set; }


        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        //INDEXER
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; } 
        }
    }
}
