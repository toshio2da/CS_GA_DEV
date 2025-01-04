using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.tmdtools
{
	public class TmdException : Exception
	{
		public TmdException(String information) : base(information) { }
		public TmdException(String information, Exception innerException) : base(information, innerException) { }

	}
}
