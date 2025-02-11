using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.GAModel.Json
{
	public class GAModelInfoParams
	{
		public Type ParamType { get; set; } = typeof(string);

		public string ParamName { get; set; } = string.Empty;

		public string? ParamValue { get; set; } = null;
	}
}
