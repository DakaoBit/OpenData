using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenData.Domain.ViewModels.PTX;

namespace OpenData.Application.Interface.PTX
{
	public interface IAirArrivalService
	{
		List<Air_AriportViewModel> GetAllAirport();
		//List<Air_AriportViewModel> GetAllAirport(Func<Air_AriportViewModel, bool> filter);
		
		List<Air_ArrivalViewModel> GetAllArrival();
		List<Air_ArrivalViewModel> GetAllArrival(string IATA);
	}
}
