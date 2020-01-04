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
		Air_AriportViewModel GetAirport(string IATA);
		List<Air_AriportViewModel> GetAllAirport();
		
		//List<Air_AriportViewModel> GetAllAirport(Func<Air_AriportViewModel, bool> filter);

		Air_AirlineViewModel GetAirline(string IATA);

		List<Air_ArrivalViewModel> GetAllArrival();
		List<Air_ArrivalViewModel> GetAllArrival(string IATA);
	}
}
