namespace jp.co.tmdgroup.common.GeneticAlgorithm;

using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
using jp.co.tmdgroup.common.GeneticAlgorithm.Fitnesses;
using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

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
public class GASearchStatus
{

	//各世代の最優秀個体(最新の検索中)
	private List<Individual> superior = [];

	//全検索の中で生き残った最優秀個体
	private Individual bestIndividual = null!;


	///<sammary>
	/// デフォルトコンストラクタ
	///</sammary>
	public GASearchStatus() { }


	/// <sammary>
	/// 適応度計算アルゴリズムを取得または設定します
	/// </sammary>
	/// <remarks>
	/// GeneticAlgorithmクラスに自動的に設定されます。
	/// </remarks>
	public IFitnessAlgorithm? FitnessAlgorithm { get; set; } = null;

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
	public GASearchStatusTypes SearchStatusType { get; set; } = GASearchStatusTypes.WAIT_FOR_SEARCH;

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
		if (generationIndex >= this.superior.Count)
			throw new IllegalParameterSizeException("指定世代が保持世代サイズを越えています");


		//------ 指定された世代の最高個体を取得 ------//
		return this.superior[generationIndex];
	}


	///<sammary>
	/// 新しい世代の最優秀個体を登録します。
	///</sammary>
	/// <param name="newBestIndividual">新しく登録する個体</param>
	public void AddSuperior(Individual newBestIndividual)
	{

		//------ 個体を登録 ------//
		this.superior.Add(newBestIndividual);
	}

	///<sammary>
	///記録した現検索の優秀個体の情報を全て削除します。
	///</sammary>
	///<remarks>
	///本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>
	///</remarks>
	public void ClearSuperior()
	{
		this.superior.Clear();
	}

	/// <summary>
	/// 今までの全検索の内、最優秀である個体を返します。
	/// </summary>
	/// <remarks>
	/// 全検索とは、複数回の検索全てを含みます。<br>
	/// よって最終的な検索結果となります。<br>
	/// </remarks>
	/// <returns>全検索中最優秀個体</returns>
	public Individual GetBestIndividual()
	{
		return this.bestIndividual;
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
		//------ 始めの1回目かチェック ------//
		if (this.bestIndividual == null)
		{

			//------ 始めの1回は無条件で登録 ------//
			this.bestIndividual = candidate;
			return;
		}

		if (this.FitnessAlgorithm == null) throw new NullReferenceException("FitnessAlgorithmがNullです");

		//------ 適応度が現在の最優秀候補よりも高いかチェック ------//
		if (this.FitnessAlgorithm.GetFitnessValue(this.bestIndividual) < this.FitnessAlgorithm.GetFitnessValue(candidate))
		{
			//------ さらに優秀な個体が現れたので交代 ------//
			this.bestIndividual = candidate;

			//------ 最優秀個体が交代したので報告 ------//
			this.Reporter.Report(this.bestIndividual);
		}
	}
}
