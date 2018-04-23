namespace SzkolenieTechniczne3.Core.Domain
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Pesel { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}