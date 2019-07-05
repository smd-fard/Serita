using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Domain
{
    public abstract class BaseEntity
    {
        [Column(Order = 1)]
        [Required]
        public int Id { get; set; }

        //[NotMapped]
        //public ObjectState State { get; set; }
    }
}
