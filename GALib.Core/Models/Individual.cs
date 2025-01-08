namespace GALib.Core.Models
{
	/// <summary>
	/// <p> 個体を表現します。自己遺伝子と、その適応度を保持します。</p>
	/// 遺伝的アルゴリズムにおける個体を表現します。<br>
	/// 自己の遺伝子を持ち、その遺伝子に対する適応度を保持します。<br>
	/// 適応度はFitnessクラスによって行われ、更新されます。<br>
	/// 本個体クラスの集合によって集団を構成します。<br>
	/// 適応度によってソートを行うためにComparableインタフェースを実装しています。<br>
	/// 気をつけていただきたいのは、適応度が高いもの程小さく評価されることです。<br>
	/// つまり、適応度が高いほど個体の評価値は小さくなります。<br>
	/// これは適応度の高い順番に高速にアクセスするためです。<br>
	/// IndivisualModelによって初期化することで遺伝子型を決定します。<br>
	/// 各問題に応じて適切な遺伝子クラスを選択し、モデルクラスを実装することで動作します。<br>
	/// <br>
	/// <br>
	/// <br>
	/// <p>タイトル: Genetic Algorithm Library</p>
	/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	/// <p>著作権: Copyright (c) 2002  森本寛</p>
	/// <p>会社名: 株式会社東京マイクロデータ</p>
	/// @author 森本寛
	/// @version 1.0 (2002/10/16)
	/// </summary>
	public class Individual : IComparable
	{
		/** 自己を表現する遺伝子。様々な塩基タイプがあります。*/
		private IGene _gene = null!;


		/** 個体の遺伝子モデルを決定するモデルクラスです。*/
		private IIndividualModel _individualModel;

		/// <summary>
		/// 適応されているIndividualModeクラスを返します
		/// </summary>
		public IIndividualModel IndividualModel => _individualModel;


		/// <summary>
		/// 世代
		/// </summary>
		public int GenerationNumber { get; set; } = 0;

		/// <summary>
		/// <p>個体の適応度を取得または設定します。</p>
		/// </summary>
		/// <remarks>
		/// 適応度はFitnessクラスによって評価されます。<br>
		/// Indivisualクラスはその適応度を保持します。<br>
		/// </remarks>
		public double FitnessValue { get; set; } = 0.0;


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="individualModel">個体の設定情報を記述するモデルクラス</param>
		/// <param name="gene">遺伝子</param>
		internal Individual(IIndividualModel individualModel, IGene gene)
		{
			//------ モデルクラスを設定 ------//
			_individualModel = individualModel;                  // 遺伝子長・タイプを決定。
			_gene = gene;
		}

		/// <summary>
		/// >個体の保持する遺伝子を取得します
		/// </summary>
		public IGene Gene => _gene;

		/// <summary>
		/// ンタフェースComparableの実装メソッドです。ソートに利用されます。
		/// </summary>
		/// <param name="other"> object 比較する対象のIndivisualインスタンス</param>
		/// <returns>比較結果。自分が小さい場合には負の数。同じ場合はゼロ。大きい場合は正の数を返します</returns>
		public int CompareTo(object? other)
		{
			//T.Tsuda
			if (other == null) return 1;
			if (other is not Individual) return 1;


			//------ 適当度を用いて比較 ------//
			double targetFitnessValue = ((Individual)other).FitnessValue;
			if (FitnessValue > targetFitnessValue)
			{
				// 対象よりも適応度が高いので負の数を返す（適応度の高い個体ほど小さいと評価される)
				return -1;
			}
			else
			{
				// 対象と同じであればゼロ、自分の適応度が大きければ正の数を返す
				return FitnessValue == targetFitnessValue ? 0 : 1;
			}
		}
	}
}
