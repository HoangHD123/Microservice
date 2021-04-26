using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;
using System;

namespace CleanArchitecture.Application.Models
{
    public class ProductType: AuditableEntity
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
