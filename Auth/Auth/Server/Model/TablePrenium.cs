using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Server.Model
{
    internal class TablePrenium
    {
        public string NewsText { get; set; }
        public string NewsDateTime { get; set; }
        public DateTime NewsDetailTime { get; set; }

        public string Email {  get; set; }
        public string IDentifier { get; set; }
    }
}