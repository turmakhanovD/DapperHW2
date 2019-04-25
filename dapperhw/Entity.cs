using System;

namespace NewsApp
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public DateTime DeletedDate { get; set; } 
    }
}
