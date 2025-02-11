using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.GAModel.Json
{
	public class GAModelInfo
	{
		public string AssemblyName { get; set; } = string.Empty;
		public string ClassName { get; set; } = string.Empty;

		public List<GAModelInfoParams>? InitParams { get; set; } = null;
	}
}
