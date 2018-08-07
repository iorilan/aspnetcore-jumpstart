using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DbModels
{
    public partial class Person
    {
        public long Id { get; set; }

	    [Display(Name = "Employee Name")]
		public string Name { get; set; }
        public string IdNumber { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }

	    [DataType(DataType.Date)]
		public DateTime? JoinDate { get; set; }
        public byte[] Photo { get; set; }

	    [DataType(DataType.Date)]
		public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
