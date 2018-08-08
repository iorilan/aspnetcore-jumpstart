using System;
using System.Collections.Generic;

namespace WebApiCRUD.DbModels
{
    public partial class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public DateTime? JoinDate { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
