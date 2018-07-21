using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base
{
    public abstract class DomainBase : IDomainBase
    {
        [Key]
        public Guid Id { get; private set; }

        [NotMapped]
        public bool IsPost { get; set; }

        [NotMapped]
        public bool Sync { get; set; }

        public abstract IDtoBase GetDto();

        public void SetId(Guid id)
        {
            Id = id;
            Sync = true;
            IsPost = true;
        }
    }
}