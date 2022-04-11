using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Server.Model
{
    internal class TableUsers
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public bool isPrenium { get; set; }
    }
}