using System;
using System.Collections.Generic;

namespace ATM_Application.Data
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Amount { get; set; }
        public DateTime? DataCreated { get; set; }
    }
}
