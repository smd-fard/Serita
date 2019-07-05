using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Domain
{
    public abstract class BaseDomain : BaseEntity
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        [Required]
        public DateTimeOffset ModifyDate { get; set; }
    }
}
