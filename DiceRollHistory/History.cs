using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace DiceRollHistory
{
	public interface IRollHistoryService : IService
	{
		Task<List<String>> HistoryShow();

		Task<bool> HistoryAdd(int rollValue, DateTime rollDate);
	}
}
