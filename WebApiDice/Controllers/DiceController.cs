using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DiceRollHistory;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace WebApiDice.Controllers
{
	[ServiceRequestActionFilter]
	public class DiceController : ApiController
	{
		private static readonly Random DiceGenerator = new Random();
		const int DiceMin = 1;
		const int DiceMax = 30;
		// GET api/dice
		public async Task<IEnumerable<string>> Get()
		{
			var rollHistoryService = ServiceProxy.Create<IRollHistoryService>(new Uri("fabric:/FabricDemo/DiceRollHistory"));
			var rollValue = DiceGenerator.Next(DiceMin, DiceMax);
			await rollHistoryService.HistoryAdd(rollValue, DateTime.UtcNow);
			var rollHistory = await rollHistoryService.HistoryShow();
			
			var mainResult = new string[]
			{
				rollValue.ToString(),
				$"Dice{DiceMax} rolled",
			};
			return mainResult.Concat(rollHistory);

		}


	}
}
