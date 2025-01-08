using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Algo
{
	public enum GASearchStatus
	{
		/// <summary>
		/// GA検索中
		/// </summary>
		SEARCHING = 100,
		/// <summary>
		/// GA検索完了
		/// </summary>
		DONE_SEARCH = 101,
		/// <summary>
		/// GA検索待
		/// </summary>
		WAIT_FOR_SEARCH = 102,
	}
}
