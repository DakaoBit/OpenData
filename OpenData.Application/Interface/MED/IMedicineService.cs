using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpenData.Domain;
using OpenData.Domain.ViewModels.Medicine;

namespace OpenData.Application.Interface.MED
{
    public interface IMedicineService
    {
        void AddMedicine(IEnumerable<ChAnimalMedViewModel> viewModel);
        AnimalMedViewModel GetMedicine(int id);
        bool GetMedicine(Func<XT_AnimalMedicine, bool> filter);
        List<AnimalMedViewModel> GetMedicines();
        List<AnimalMedViewModel> GetMedicines(Func<AnimalMedViewModel, bool> filter);
        ExecuteResultModel Update(HttpContext context, AnimalMedViewModel viewModel);
        ExecuteResultModel Delete(int id);

        ExecuteResultModel LoginAuth(HttpContext context, LoginViewModel viewModel);
        ExecuteResultModel Register(UserRegisterViewModel viewModel);
        bool IsUserID(string userid);
        // List<object> GetMedicines(Expression<Func<object, bool>> filter);
    }
}
