using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Genes
{
	public abstract class AbstractTypedGene<TBase> : ITypedGene<TBase>
	{
		private TBase[] baseData;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="size">遺伝子の長さ</param>
		protected AbstractTypedGene(int size)
		{
			baseData = new TBase[size];
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="gene">遺伝子整数値塩基配列</param>
		public AbstractTypedGene(TBase[] gene)
		{
			baseData = gene;
		}

		public abstract Type GeneType { get; }


		public int GenoSize => baseData.Length;


		public TBase[] GetBase()
		{
			return baseData;
		}

		public void CreateGene(TBase[] piecesOfGene)
		{
			if (piecesOfGene.Length != this.GenoSize)
			{
				// 遺伝子長が正しくないので例外を送出
				throw new IllegalGenoSizeException();
			}

			//------ 自己遺伝子を更新 ------//
			baseData = piecesOfGene;
		}

		public ITypedGene<TBase> GetSubGene(int firstGenoIndex, int lastGenoIndex)
		{
			TBase[] subGene = new TBase[lastGenoIndex - firstGenoIndex + 1];

			for (int index = 0; index < subGene.Length; index++)
			{
				subGene[index] = baseData[firstGenoIndex + index];
			}

			//------ 部分遺伝子断片を返す ------//
			var ret = Activator.CreateInstance(this.GeneType, [subGene]);
			if (ret == null)
			{
				throw new Exception("Geneを初期化できませんでした");
			}

			return (ITypedGene<TBase>)ret;
		}

		public void InverseSubGene(int firstGenoIndex, int lastGenoIndex)
		{
			//------ 逆位を行うために遺伝子断片を作成 ------//
			ITypedGene<TBase> subGene = this.GetSubGene(firstGenoIndex, lastGenoIndex);

			TBase[] gene = (TBase[])subGene.GetBase();

			//------ 逆順にコピー ------//
			for (int index = 0; index < gene.Length; index++)
			{
				baseData[firstGenoIndex + index] = gene[gene.Length - index - 1];
			}
		}

		public virtual void MutateOneGene(int genoIndex)
		{
			this.baseData[genoIndex] = this.GetMutateValue();
		}



		public virtual void RandumReconstruct()
		{
			for (int index = 0; index < baseData.Length; index++)
			{
				this.baseData[index] = this.GetMutateValue();
			}
		}

		protected abstract TBase GetMutateValue();


	}
}
