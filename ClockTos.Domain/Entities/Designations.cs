using System.ComponentModel.DataAnnotations.Schema;

namespace ClockTos.Domain.Entities
{
    public class Designations:BaseEntity
    {
        public string  Acronym { get; set; }=string.Empty;

        public string  Name { get; set; }=string.Empty;

        public string StaffType { get; set; } = string.Empty;

        public int? Priority { get; set; }

        public string RolesAndResponsibilities { get; set; }= string.Empty;

        public Guid CollegeId { get; set; }

        #region Navigation properties

        [ForeignKey(nameof(CollegeId))]
        public Colleges college { get; set; } = null!;

        #endregion
    }
}
