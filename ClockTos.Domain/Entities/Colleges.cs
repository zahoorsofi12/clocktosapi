using System.ComponentModel.DataAnnotations.Schema;

namespace ClockTos.Domain.Entities
{
    public class Colleges:BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Designations> Designations { get; set; } = new List<Designations>();

    }
}
