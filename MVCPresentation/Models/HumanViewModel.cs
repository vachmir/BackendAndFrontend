namespace MVCPresentation.Models
{
    public class HumanViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? CarId { get; set; }

        //Human has FK to Car, this line contains Car  BrandModel and SerialNumber, which are used in Human.Inxex and show Human,s car
        public CarViewModel? Car {  get; set;}
    }
}
