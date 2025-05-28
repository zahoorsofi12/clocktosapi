namespace ClockTos.Application.RRModels
{
    public class DesignationRequest
    {
        public string Acronym { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string StaffType { get; set; } = string.Empty;

        public int? Priority { get; set; }

        public string RolesAndResponsibilities { get; set; } = string.Empty;

        public Guid CollegeId { get; set; }
    }
    public class DesignationResponse:DesignationRequest
    {

        public Guid Id { get; set; }

    }
}
