using System;

namespace SzkolenieTechniczne3.Core.Domain
{
    public class Orders : EntityBase
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
    }
}