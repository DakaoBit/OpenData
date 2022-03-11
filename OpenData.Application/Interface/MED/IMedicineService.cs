using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpenData.Domain.ViewModels.Medicine;

namespace OpenData.Application.Interface.MED
{
    public interface IMedicineService
    {
        AnimalMedViewModel GetMedicine(Func<AnimalMedViewModel, bool> filter);
        List<AnimalMedViewModel> GetMedicines();
        List<AnimalMedViewModel> GetMedicines(Func<AnimalMedViewModel, bool> filter);

        // List<object> GetMedicines(Expression<Func<object, bool>> filter);
    }
}
