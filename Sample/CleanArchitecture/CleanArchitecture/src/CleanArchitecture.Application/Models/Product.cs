using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUri { get; set; }
        public Guid ProductTypeID { get; set; }
        public Int16 RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedUser { get; set; }
    }
}
