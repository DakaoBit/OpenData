using NUnit.Framework;
using OpenData.Domain.ViewModels.EPA;
using OpenData.Application.Services.EPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Application.Services.EPA.Tests
{
	[TestFixture()]
	public class AQIServiceTests
	{
		#region Types
		[Test()]
		public void Type_GetAllSite()
		{
			var test = new AQIService();
			Assert.That(test.GetAllSite(), Is.TypeOf<List<AQIViewModel>>());

		}
		#endregion

		#region Conditions	
		[Test]
		public void Condition_GetAllSite()
		{
			var test = new AQIService();

			Assert.That(test.GetAllSite(), Is.Not.Empty);
			Assert.That((test.GetAllSite() != null), Is.Not.Null);
			Assert.That((test.GetAllSite() != null), Is.True);
		}
		#endregion

		#region Collections
		[Test]
		public void Collection_GetAllSite()
		{
			var test = new AQIService();

			Assert.That(test.GetAllSite() , Is.Unique );
			Assert.That(test.GetAllSite().Any(o => o.SiteName == "基隆"));
			//CollectionAssert.AreEquivalent(new[] { "林口", "土城", "新店" }, test.GetAllSite().Where(o => o.SiteName == "土城").Select(o => o.SiteName).ToList());
 
		}
		#endregion

	}
}