using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Server.Model
{
    internal class TableProvider
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Email {  get; set; }
        public string IDentifier { get; set; }

        public string ProviderDateTime { get; set; }
        public DateTime ProviderDetailTime { get; set; }
    }
}
