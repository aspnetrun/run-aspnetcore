using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
