using System;

namespace SzkolenieTechniczne3.Core.Domain
{
    public class News : EntityBase
    {
        public DateTime DateFromView { get; set; }
        public DateTime DateToView { get; set; }
        public string Contents { get; set; }
        public int UserId { get; set; }
    }
}