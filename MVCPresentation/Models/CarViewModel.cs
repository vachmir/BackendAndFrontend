using DbDomain;

namespace MVCPresentation.Models
{
    public class CarViewModel
    {
       public int Id { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }

        public List<Car> Cars { get; set; } = null!;

    }
}
