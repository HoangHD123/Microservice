using System;

namespace CleanArchitecture.Domain.Entites
{
    public class AuditableEntity
    {
        public Guid UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
