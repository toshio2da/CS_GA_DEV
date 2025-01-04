using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.geneticalgorithm
{
	public enum GeneticSearchCommand
	{
		/// <summary>
		/// 検索続行命令。検索中は通常この命令が格納されています。
		/// </summary>
		GO_AHEAD_SEARCH = 0,
		/// <summary>
		/// 検索終了命令。検索を終了させるときに格納します。世代交代時にチェックされます。
		/// </summary>
		STOP_SEARCH = 1,
	}
}
