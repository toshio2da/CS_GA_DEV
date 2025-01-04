using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.geneticalgorithm
{
	public enum GeneticSearchMethod
	{
		/// <summary>
		/// 検索の種類。指定世代数まで世代交代を行います。デフォルト値です。
		/// </summary>
		LIMIT_NUMBER = 200,

		/// <summary>
		/// 検索の種類。指定時間まで延々と世代交代を行います。
		/// </summary>
		LIMIT_TIME = 201,

		/// <summary>
		/// 検索の種類.指定世代数の検索を指定時間まで繰り返します。広範囲に渡る検索が可能です。
		/// </summary>
		LIMIT_NUMBER_UNTIL_TIME = 202,
	}
}
