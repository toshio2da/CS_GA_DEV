using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals
{
	public abstract class AbstractIndividualModel : IIndividualModel
	{
		public AbstractIndividualModel(int genoSize)
		{
			this.GenoSize = genoSize;
		}

		/// <summary>
		/// 自己遺伝子の遺伝子長を取得します
		/// </summary>
		public int GenoSize{ get;private set; }

		/// <summary>
		/// 遺伝子の塩基タイプがこの個体モデルにおいて正しいかどうかをチェックします
		/// </summary>
		/// <remarks>
		///　渡された遺伝子が整数型の塩基タイプを持つかチェックします。<br>
		///　整数型塩基タイプでなければfalseを返します。
		/// </remarks>
		/// <param name="gene">チェックしたい遺伝子です</param>
		/// <returns>正しければtrue, 不正であればfalseを返します</returns>
		public abstract bool IsLegalGenoType(IGene gene);


		public abstract IGene CreateNewGene();
	}
}
