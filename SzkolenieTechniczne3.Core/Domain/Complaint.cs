namespace SzkolenieTechniczne3.Core.Domain
{
    public class Complaint : EntityBase
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string InfoFromService { get; set; }
        public int StatusId { get; set; }
    }
}