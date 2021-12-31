using MVCPresentation.Models;
using DbDomain;
using Microsoft.EntityFrameworkCore;

namespace MVCPresentation.Services
{
    public class HumanService
    {
        private readonly DataContext _dataContext = null!;

        public HumanService()
        {
        }

        public HumanService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public  async Task<IEnumerable<HumanViewModel>> RequestForDataPresentation()
        {

            IEnumerable<HumanViewModel> model = new List<HumanViewModel>();
            model = await _dataContext.Humans.Select(h => new HumanViewModel
            {
                FirstName = h.FirstName,
                LastName = h.LastName,
                Address = h.Address,
                City = h.City,
                // CarId=h.CarId,
                Car = new CarViewModel
                {
                    Model = h.Car.Model,
                    SerialNumber = h.Car.SerialNumber,
                    Id = h.Car.Id
                },
            }).ToListAsync();

            return model;
        }
    }
}
