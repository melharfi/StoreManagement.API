using System;

namespace StoreManagement.Domain
{
    public class Entity
    {
        public Entity()
        {
            Id = new Guid();
            Created = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
