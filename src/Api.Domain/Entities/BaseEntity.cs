using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        private DateTime? _createAt;
        public DateTime? UpdateAt { get; set; }

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.Now : value); }
        }

    }
}