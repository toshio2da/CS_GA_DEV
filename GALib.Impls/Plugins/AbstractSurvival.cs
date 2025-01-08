using GALib.Core.Models;
using GALib.Core.Plugins;

namespace GALib.Impls.Plugins
{

	/**
	 * <p>親集団の生き残りを記述するSurvivalAlgorithmインタフェースのうち、
	 * 世代間ギャップに関するメソッドのみを記述した抽象クラスです。</p>
	 * 本クラスを派生することにより、生き残り法の本質のみを記述するだけで簡単に生き残り記述クラスを作成することができます。<br>
	 * <br>
	 * <br>
	 * <br>
	 * <p>タイトル: Genetic Algorithm Library</p>
	 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	 * <p>著作権: Copyright (c) 2002  森本寛</p>
	 * <p>会社名: 株式会社東京マイクロデータ</p>
	 * @author 森本寛
	 * @version 1.0 (2002/10/30)
	 */

	public abstract class AbstractSurvival : ISurvivalAlgorithm
	{



		//====================================================//
		//-------------------- メンバ変数 --------------------//
		//====================================================//

		/** 世代間ギャップ。範囲は[0.0-1.0] */
		protected double generationGap;




		//================================================//
		//-------------------- 構築子 --------------------//
		//================================================//

		/**
		 * <p>構築子です。</p>
		 * 特に何も行いません。<br>
		 * 世代間ギャップはデフォルトの1.0が適応されます。
		 */
		public AbstractSurvival()
		{
			generationGap = 1.0;
		}



		/**
		 * <p>世代間ギャップを指定する構築子です。</p>
		 *
		 * 世代間ギャップは 0.0\uFF5E1.0で示されます。<br>
		 * G = 1.0 の場合、世代が変わる毎に全ての個体は死滅し、次世代が誕生します。<br>
		 * つまり、親集団は生き残りません。<br>
		 * G = 0.0 の場合は世代が変わっても全ての親が存続するので遺伝的アルゴリズムは昨日しなくなってしまいます。<br>
		 * 一般的には世代間ギャップ[G]はかなり高めに設定されます。0.95\uFF5E1.0が多いようです。<br>
		 *
		 * @param generationGap 指定する世代間ギャップ
		 * @throws OutOfRangeException 指定した世代間ギャップが範囲[0.0\uFF5E1.0]を越えています
		 */
		public AbstractSurvival(double generationGap)  //throws OutOfRangeException
		{

			//------ 世代間ギャップを設定 ------//
			this.generationGap = generationGap;
		}





		//===================================================================================//
		//-------------------- SurvivalAlgorithmインタフェースメソッドの実装 --------------------//
		//===================================================================================//

		/// <summary>
		/// 世代間ギャップ[G]を取得または設定します。
		/// </summary>
		/// <remarks>
		/// 世代間ギャップは 0.0\uFF5E1.0で示されます。<br>
		/// G = 1.0 の場合、世代が変わる毎に全ての個体は死滅し、次世代が誕生します。<br>
		/// つまり、親集団は生き残りません。<br>
		///  G = 0.0 の場合は世代が変わっても全ての親が存続するので遺伝的アルゴリズムは昨日しなくなってしまいます。<br>
		/// 一般的には世代間ギャップ[G] はかなり高めに設定されます。0.95\uFF5E1.0が多いようです。<br>
		/// </remarks>
		public double GenerationGap { get => generationGap; set => generationGap = value; }

		public abstract List<Individual> Survive(List<Individual> survivors);
	}
}