using AspnetRun.Core.Interfaces;
using System;

namespace AspnetRun.Core.Entities
{
    public abstract class Entity : IAggregateRoot
    {
        public Guid Id { get; set; }
    }
}
