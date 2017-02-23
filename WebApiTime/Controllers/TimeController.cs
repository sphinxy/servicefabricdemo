using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;

namespace WebApiTime.Controllers
{
	[ServiceRequestActionFilter]
	public class TimeController : ApiController
	{
		// GET api/time
		public IEnumerable<string> Get()
		{
			return new string[]
			{
				//DateTime.UtcNow.ToShortDateString()
				DateTime.UtcNow.ToLongDateString()
			};
		}

		
	}
}
