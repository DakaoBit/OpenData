using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenData.Domain.ViewModels.EPA;
using System.Web.Mvc;

namespace OpenData.Application.Interface
{
    public interface IAQIService
    {
        AQIViewModel GetSite(Func<AQIViewModel, bool> filter);
        List<AQIViewModel> GetAllSite();
        List<AQIViewModel> GetAllSite(Func<AQIViewModel, bool> filter);
        List<SelectListItem> GetCountyOption();
    }
}
