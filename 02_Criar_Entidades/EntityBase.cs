using System;

namespace MWEstacionamentos.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool isAtivo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
