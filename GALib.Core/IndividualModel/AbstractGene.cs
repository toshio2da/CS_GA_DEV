using GALib.Core.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.IndividualModel
{
	public abstract class AbstractGene<TBase> : IGene<TBase>
	{
		private TBase[] baseData;

		/// <summary>
		/// 自己遺伝子の遺伝子長を返します
		/// </summary>
		public int GeneSize => baseData.Length;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="geneSize">遺伝子の長さ</param>
		protected AbstractGene(int geneSize)
		{
			baseData = new TBase[geneSize];
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="gene">遺伝子</param>
		protected AbstractGene(IGene<TBase> gene)
		{
			baseData = gene.GetBase();
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		protected AbstractGene(TBase[] baseData)
		{
			this.baseData = baseData;
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		protected AbstractGene(object[] baseData)
		{
			this.baseData = baseData.Select(e => (TBase)Convert.ChangeType(e, typeof(TBase))).ToArray();
		}


		/// <summary>
		/// Geneクラスのインスタンスを取得する為にサブクラスで実装されます
		/// </summary>
		/// <returns>Geneクラスの（サブクラス）インスタンス</returns>
		protected abstract AbstractGene<TBase> GetNewGeneInstance();


		/// <summary>
		/// 型指定された遺伝子の塩基配列を返します
		/// </summary>
		/// <returns>型指定された遺伝子配列</returns>
		public TBase[] GetBase()
		{
			return baseData;
		}

		/// <summary>
		///  型指定された遺伝子の塩基配列を設定します
		/// </summary>
		/// <param name="baseData">型指定された遺伝子配列</param>
		public void SetBase(TBase[] baseData)
		{
			this.baseData = baseData;
		}


		/// <summary>
		/// 塩基配列を一意に識別する為のハッシュ値を返します
		/// </summary>
		/// <returns>ハッシュ値</returns>
		public virtual string? GetHash()
		{
			return null;
		}


		/// <summary>
		/// 突然変異の為の値を返す為にサブクラスで実装されます
		/// </summary>
		/// <returns></returns>
		protected abstract TBase GetMutateValue();

		/// <summary>
		/// 自己遺伝子を全てランダムなもので再構築します
		/// </summary>
		/// <remarks>
		/// 個体遺伝子の初期化などに用いられます
		/// </remarks>
		public virtual void RandumReconstruct()
		{
			for (int index = 0; index < baseData.Length; index++)
			{
				baseData[index] = GetMutateValue();
			}
		}

		/// <summary>
		/// 1塩基に対して突然変異を起こします
		/// </summary>
		/// <remarks>
		/// 自己遺伝子内の指定塩基に対して突然変位を行います。<br>
		/// 突然変位は遺伝子の塩基タイプによって異なります。<br>
		/// </remarks>
		/// <param name="geneIndex">塩基インデックス</param>
		public virtual void MutateOneGene(int geneIndex)
		{
			baseData[geneIndex] = GetMutateValue();
		}

		/// <summary>
		/// 指定した場所の遺伝子に逆位を行います
		/// </summary>
		/// <remarks>
		/// 逆位とは指定した場所の遺伝子の順番を反転させる操作を指します。<br>
		/// あまり一般的に用いられるGAオペレーションではありません。
		/// </remarks>
		/// <param name="firstGeneIndex">抜き出す遺伝子断片の初端を指定します</param>
		/// <param name="lastGeneIndex">抜き出す遺伝子断片の終端を指定します</param>
		public void InverseSubGene(int firstGeneIndex, int lastGeneIndex)
		{
			//------ 逆位を行うために遺伝子断片を作成 ------//
			IGene<TBase> subGene = GetSubGene(firstGeneIndex, lastGeneIndex);

			TBase[] gene = subGene.GetBase();

			//------ 逆順にコピー ------//
			for (int index = 0; index < gene.Length; index++)
			{
				baseData[firstGeneIndex + index] = gene[gene.Length - index - 1];
			}
		}

		/// <summary>
		/// 型指定された自己遺伝子の部分遺伝子断片を返します
		/// </summary>
		/// <remarks>
		/// 部分遺伝子を返すことで交叉を行うことができます。<br>
		/// 部分遺伝子は初端と終端を指定することで抜き出します。<br>
		/// 初端と終端の遺伝子も返される部分遺伝子断片に含まれます。<br>
		/// 例えば、getSubGene(0, 5) とした場合の返される遺伝子断片の長さは6となります。<br>
		/// getSubGene(1,1)とすることで1塩基を抜き出すこともできます。<br>
		/// </remarks>
		/// <param name="firstGeneIndex">抜き出す遺伝子断片の初端を指定します</param>
		/// <param name="lastGeneIndex">抜き出す遺伝子断片の終端を指定します</param>
		/// <returns>抜き出された部分遺伝子断片です</returns>
		public IGene<TBase> GetSubGene(int firstGeneIndex, int lastGeneIndex)
		{
			TBase[] subGene = new TBase[lastGeneIndex - firstGeneIndex + 1];

			Array.Copy(baseData, firstGeneIndex, subGene, 0, subGene.Length);

			//------ 部分遺伝子断片を返す ------//
			var newGene = GetNewGeneInstance();
			newGene.baseData = subGene;
			return newGene;
		}

	}
}
