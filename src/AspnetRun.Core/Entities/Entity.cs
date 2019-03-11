using AspnetRun.Core.Interfaces;

namespace AspnetRun.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
