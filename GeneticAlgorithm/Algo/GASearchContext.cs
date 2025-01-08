using GALib.Core;
using GALib.Core.Models;

namespace GALib.Algo
{

	///遺伝的アルゴリズムによる検索の状態を保持します。
	///遺伝的アルゴリズムによる最適解の検索は一般的に長い時間を必要とします。<br>
	///GeneticAlgorithmクラスによる検索は本クラスにその状態を保持させることができます。<br>
	///GeneticAlgorithmはその検索の際、自己スレッドを立て、その中で処理を行います。<br>
	///その途中経過と最終結果のデータの受け渡しクラスが本クラスとなります。<br>
	///本クラスに適切な値をセットさせることで検索を中断するなどの操作を行うことが出来ます。<br>
	///また、途中結果や最終結果が本クラスに格納されるのでそれらをユーザーに表示させることもできます。<br>
	///データは自動的に同期が取られます。処理速度のためにも不要なアクセスはしないことをお奨めします。<br>
	///<br>
	///<br>
	///<br>
	///<p>タイトル: Genetic Algorithm Library</p>
	///<p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	///<p>著作権: Copyright (c) 2001  森本寛</p>
	///<p>会社名: 株式会社東京マイクロデータ</p>
	///@author 森本寛
	///@version 1.0 (2002/11/05)
	public class GASearchContext
	{

		//各世代の最優秀個体(最新の検索中)
		private List<Individual> superior = new();

		////全検索の中で生き残った最優秀個体
		//private Individual bestIndividual = null!;


		///<sammary>
		/// デフォルトコンストラクタ
		///</sammary>
		public GASearchContext() { }


		/// <summary>
		/// 集団の個体数
		/// </summary>
		public int IndividualCnt { get; set; } = 200;

		/// <summary>
		/// 最大世代数
		/// </summary>
		public int MaxGenerationCnt { get; set; } = 3000;

		/// <sammary>
		/// 途中経過報告クラス
		/// </sammary>
		/// <remarks>
		/// デフォルトでは標準出力に適応度を出力
		/// </remarks>
		public IGeneticReportable Reporter { get; set; } = new DefaultGeneticReporter();


		/// <summary>
		/// 検索に対する命令を取得または設定します
		/// </summary>
		public GASearchCommand Command { get; set; } = GASearchCommand.GO_AHEAD_SEARCH;

		/// <sammary>
		/// 状態変数を取得または設定します
		/// </sammary>
		public GASearchStatus SearchStatusType { get; set; } = GASearchStatus.WAIT_FOR_SEARCH;

		/// <sammary>
		/// 検索手法を取得または設定します
		/// </sammary>
		public GASearchMethod SearchMethod { get; set; } = GASearchMethod.LIMIT_NUMBER;


		/// 
		/// <summary>
		/// 指定した世代の最優秀個体を取得します。
		/// </summary>
		/// <remarks>
		/// 本クラスには各世代の最高個体が保持されています。<br>
		/// いわば、遺伝的アルゴリズムの記録と言えます。<br>
		/// 本メソッドでは世代を指定することでその世代の最優秀個体を得ることができます。<br>
		/// これにより世代による個体の成長を見ることもできます。<br>
		/// </remarks>
		/// <param name="generationIndex">指定する世代</param>
		/// <returns>指定世代の最優秀個体</returns>
		/// <exception cref="IllegalParameterSizeException"></exception>
		public Individual GetSuperior(int generationIndex)
		{
			//------ サイズをチェック ------//
			if (generationIndex >= superior.Count)
				throw new GeneticAlgorithmException("指定世代が保持世代サイズを越えています");

			//------ 指定された世代の最高個体を取得 ------//
			return superior[generationIndex];
		}

		///<sammary>
		///記録した現検索の優秀個体の情報を全て削除します。
		///</sammary>
		///<remarks>
		///本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>
		///</remarks>
		public void ClearSuperior()
		{
			superior.Clear();
		}

		/// <summary>
		/// 今までの全検索の内、最優秀である個体を返します。
		/// </summary>
		/// <remarks>
		/// 全検索とは、複数回の検索全てを含みます。<br>
		/// よって最終的な検索結果となります。<br>
		/// </remarks>
		/// <returns>全検索中最優秀個体</returns>
		public Individual? GetBestIndividual()
		{
			if (superior.Count <= 0) return null;

			double maxFitnessValue = superior.Max(e => e.FitnessValue);

			return superior.FirstOrDefault(e => e.FitnessValue == maxFitnessValue);
		}


		/// <summary>
		/// 最優秀候補を交代します。
		/// </summary>
		/// <remarks>
		/// 適応度計算アルゴリズムによって適応度が比較され、現在保持されている最優秀個体よりも優秀な場合は交代となります。<br>
		/// つまり、候補を引数として渡せば自動的にチェックされます。<br>
		/// 本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>
		/// </remarks>
		/// <param name="candidate">最優秀個体候補</param>
		/// <exception cref="NullReferenceException">FitnessAlgorithmがNullの場合</exception>
		public void SetBestIndividual(Individual candidate)
		{
			superior.Add(candidate);
		}
	}
}