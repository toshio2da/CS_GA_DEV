using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
using jp.co.tmdgroup.common.Utils;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Genes
{
	public abstract class AbstractNumberGene : IGene
	{

		//==================================================//
		//------------------- メンバ変数 --------------------//
		//==================================================//

		/** 塩基表現。整数値遺伝子 */
		protected int[] baseData;


		public AbstractNumberGene(int size)
		{
			baseData = new int[size];
		}

		/**
		 * <p>コピーコンストラクタです。</p>
		 * 引数で渡した配列がそのまま使用されます。<br>
		 *
		 * @param gene  遺伝子整数値塩基配列
		 */
		public AbstractNumberGene(int[] gene)
		{
			baseData = gene;
		}

		/**
		 * <p>自己遺伝子を全てランダムなもので再構築します。</p>
		 * 個体遺伝子の初期化などに用いられます。<br>
		 * ランダムな遺伝子は mutateOneGene()メソッドを使用して生成されます。
		 */
		public void RandumReconstruct()
		{
			//------ 全塩基を再構築 ------//
			for (int index = 0; index < baseData.Length; index++)
			{
				MutateOneGene(index);
			}
		}

		public abstract void MutateOneGene(int index);


		/**
		 * <p>自己遺伝子の部分遺伝子断片を返します</p>
		 * 部分遺伝子を返すことで交叉を行うことができます。<br>
		 * 部分遺伝子は初端と終端を指定することで抜き出します。<br>
		 * 初端と終端の遺伝子も返される部分遺伝子断片に含まれます。<br>
		 * 例えば、getSubGene(0, 5) とした場合の返される遺伝子断片の長さは6となります。<br>
		 * getSubGene(1,1)とすることで1塩基を抜き出すこともできます。<br>
		 *
		 * @param firstGenoIndex  抜き出す遺伝子断片の初端を指定します
		 * @param lastGenoIndex  抜き出す遺伝子断片の終端を指定します
		 * @return  抜き出された部分遺伝子断片です
		 * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
		 */
		public IGene GetSubGene(int firstGenoIndex, int lastGenoIndex)
		{ //throws OutOfBoundsGeneException {

			try
			{

				//------ 抜き出す部分遺伝子断片を作成 ------//
				int[] subGene = new int[lastGenoIndex - firstGenoIndex + 1];


				//------ 指定箇所をコピー ------//
				for (int index = 0; index < subGene.Length; index++)
				{
					subGene[index] = baseData[firstGenoIndex + index];
				}


				//------ 部分遺伝子断片を返す ------//
				return new NumberGene(subGene);

			}
			catch (OutOfRangeException exception)
			{
				throw new OutOfBoundsGeneException(exception);                               // 遺伝子長範囲外をアクセスしたため例外を送出
			}
		}


		/**
		 * <p>指定した場所の遺伝子に逆位を行います。</p>
		 * 逆位とは指定した場所の遺伝子の順番を反転させる操作を指します。<br>
		 * あまり一般的に用いられるGAオペレーションではありません。
		 *
		 * @param firstGenoIndex  抜き出す遺伝子断片の初端を指定します
		 * @param lastGenoIndex  抜き出す遺伝子断片の終端を指定します
		 * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
		 */
		public void InverseSubGene(int firstGenoIndex, int lastGenoIndex)
		{ //throws OutOfBoundsGeneException {

			try
			{

				//------ 逆位を行うために遺伝子断片を作成 ------//
				IGene subGene = GetSubGene(firstGenoIndex, lastGenoIndex);
				int[] gene = (int[])subGene.GetBase();


				//------ 逆順にコピー ------//
				for (int index = 0; index < gene.Length; index++)
				{
					baseData[firstGenoIndex + index] = gene[gene.Length - index - 1];
				}

			}
			catch (OutOfRangeException exception)
			{
				throw new OutOfBoundsGeneException(exception);                               // 遺伝子長範囲外をアクセスしたため例外を送出
			}
		}



		/**
		  * <p>遺伝子断片から個体の遺伝子を生成します。</p>
		  * 渡された遺伝子断片をつなぎ合わせ、生成された遺伝子を自分の遺伝子として保持します。<br>
		  * 遺伝子断片の塩基タイプは遺伝子クラスの塩基タイプと一致している必要があります。<br>
		  * 遺伝子断片はVectorの順番通りに融合されます。<br>
		  * <br>
		  * NumberGeneクラスの場合、piecesOfGeneの各要素はint[]である必要があります。<br>
		  *
		  * @param piecesOfGene  融合する遺伝子断片、塩基タイプは一致していなければないけません
		  * @throws IllegalGenoSizeException  遺伝子断片の合計遺伝子長が本遺伝子の遺伝子長と一致しません(遺伝子不足又は過多)
		  * @throws IllegalGenoTypeException  遺伝子断片の塩基タイプが本遺伝子の塩基タイプと一致しません
		  */
		public void CreateGene(object[] piecesOfGene)
		{
			try
			{
				//------ 融合した遺伝子を作成 ------//
				int[] newGene = DataTools.ConvertInnerArray<int>(piecesOfGene);       // 2値バイナリ型をつなげる

				//------ 遺伝子長をチェック ------//
				if (newGene.Length != this.GenoSize)
				{
					throw new IllegalGenoSizeException();                           // 遺伝子長が正しくないので例外を送出
				}


				//------ 自己遺伝子を更新 ------//
				baseData = newGene;

			}
			catch (InvalidCastException exception)
			{

				//------ 塩基タイプが一致しないので例外を送出 ------//
				throw new IllegalGenoTypeException(exception);
			}
		}



		/**
		 * <p>遺伝子の塩基配列を返します。</p>
		 * この塩基配列を使って適応度の算出などを行います。<br>
		 *
		 * @return 遺伝子配列
		 */
		public object GetBase()
		{

			//------ 塩基配列を返す ------//
			return baseData;
		}



		/// <summary>
		/// 自己遺伝子の遺伝子長を取得します
		/// </summary>
		public int GenoSize => baseData.Length;
	}
}