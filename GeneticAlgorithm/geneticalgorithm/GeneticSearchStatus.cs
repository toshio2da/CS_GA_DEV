using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.geneticalgorithm
{
	public enum GeneticSearchStatus
	{
		/// <summary>
		/// 状態変数。現在検索中であることを示します。
		/// </summary>
		SEARCHING = 100,
		/// <summary>
		/// 状態変数。検索が完了したことを示します。
		/// </summary>
		DONE_SEARCH = 101,
		/// <summary>
		/// 状態変数。検索を待っていることを示します。デフォルト値です。
		/// </summary>
		WAIT_FOR_SEARCH = 102,

	}
}
