using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenData.Application.Interface.MED;
using OpenData.Domain.ViewModels.Medicine;

namespace OpenData.Application.Services.MED
{
    public class AnimalMedService : IMedicineService
    {

        public AnimalMedViewModel GetMedicine(Func<AnimalMedViewModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<AnimalMedViewModel> GetMedicines()
        {
            throw new NotImplementedException();
        }

        public List<AnimalMedViewModel> GetMedicines(Func<AnimalMedViewModel, bool> filter)
        {
            throw new NotImplementedException();
        }
    }
}
