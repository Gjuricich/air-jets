﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class UrlImage
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string Url { get; set; }
        public override string ToString()
        {
            return Url;
        }
    }
}
