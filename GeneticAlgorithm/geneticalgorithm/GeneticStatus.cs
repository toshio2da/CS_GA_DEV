namespace jp.co.tmdgroup.common.geneticalgorithm;

using jp.co.tmdgroup.common.interfaces.exception;

using System.Runtime.CompilerServices;

/**
 ///<p>遺伝的アルゴリズムによる検索の状態を保持します。</p>
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
 */
public class GeneticStatus
{

	///<sammary> 検索続行命令。検索中は通常この命令が格納されています。 */
	public const int GO_AHEAD_SEARCH = 0;

	///<sammary> 検索終了命令。検索を終了させるときに格納します。世代交代時にチェックされます。 */
	public const int STOP_SEARCH = 1;


	///<sammary> 状態変数。現在検索中であることを示します。 */
	public const int SEARCHING = 100;

	///<sammary> 状態変数。検索が完了したことを示します。*/
	public const int DONE_SEARCH = 101;

	///<sammary> 状態変数。検索を待っていることを示します。デフォルト値です。*/
	public const int WAIT_FOR_SEARCH = 102;


	///<sammary> 検索の種類。指定世代数まで世代交代を行います。デフォルト値です。 */
	public const int LIMIT_NUMBER = 200;

	///<sammary> 検索の種類。指定時間まで延々と世代交代を行います。*/
	public const int LIMIT_TIME = 201;

	///<sammary> 検索の種類.指定世代数の検索を指定時間まで繰り返します。広範囲に渡る検索が可能です。*/
	public const int LIMIT_NUMBER_UNTIL_TIME = 202;



	///<sammary> 各世代の最優秀個体(最新の検索中) */
	private List<Individual> superior = [];

	///<sammary> 全検索の中で生き残った最優秀個体 */
	private Individual bestIndividual = null!;

	///<sammary> 検索に対する命令格納場所。別スレッドで動くためこの変数を介して制御します。 */
	private int command = GeneticStatus.GO_AHEAD_SEARCH;

	///<sammary> 状態変数です。現在の検索状況を示します。*/
	private int status = GeneticStatus.WAIT_FOR_SEARCH;

	///<sammary> 検索の方法を示します。世代交代数指定と時間指定、またはその組み合わせが可能です。 */
	private int search_method = GeneticStatus.LIMIT_NUMBER;

	///<sammary> 適応度計算アルゴリズム。GeneticAlgorithmクラスに自動的に設定されます。 */
	private IFitnessAlgorithm? fitness;

	///<sammary> 途中経過の報告クラス。デフォルトでは標準出力に適応度を出力 */
	private IGeneticReportable reporter = new DefaultGeneticReporter();


	///<sammary>
	///<p>構築子です。</p>
	///</sammary>
	public GeneticStatus() { }



	/// <sammary>
	/// 適応度計算アルゴリズムを取得または設定します
	/// </sammary>
	public IFitnessAlgorithm? FitnessAlgorithm { get => fitness; set => fitness = value; }


	/// <sammary>
	/// 途中経過報告クラス
	/// </sammary>
	public IGeneticReportable Reporter { get => this.reporter; set => this.reporter = value; }




	//==================================================//
	//-------------------- 検索命令 --------------------//
	//==================================================//

	public int Command
	{
		get => this.command;
		set
		{
			//------ サポートされている検索命令かチェック ------//
			if (value != GeneticStatus.GO_AHEAD_SEARCH && value != GeneticStatus.STOP_SEARCH)
			{

				throw new ArgumentException("サポートされていない検索命令です");
			}

			//------ 検索命令を設定 ------//
			this.command = value;
		}
	}

	/// <sammary>
	/// 状態変数
	/// </sammary>
	public int SearchStatus
	{
		get => this.status;
		set
		{
			//------ サポートしているかチェックする ------//
			if (value != GeneticStatus.SEARCHING && status != GeneticStatus.DONE_SEARCH && value != GeneticStatus.WAIT_FOR_SEARCH)
			{
				throw new ArgumentException("サポートされていない状態変数です。");
			}

			//------ 検索状態を変更 ------//
			this.status = value;
		}
	}

	/// <sammary>
	/// 検索手法
	/// </sammary>
	public int SearchMethod
	{

		get => this.search_method;
		set
		{
			//------ チェック ------//
			if (value != GeneticStatus.LIMIT_NUMBER && value != GeneticStatus.LIMIT_TIME &&
				value != GeneticStatus.LIMIT_NUMBER_UNTIL_TIME)
			{
				throw new ArgumentException("不正な検索手法を指定しています。");
			}

			//------ 検索手法を変更 ------//
			this.search_method = value;
		}
	}




	//==========================================================//
	//-------------------- 現検索中の優秀個体 --------------------//
	//=========================================================//

	///<sammary>
	///<p>指定した世代の最優秀個体を取得します。</p>
	///本クラスには各世代の最高個体が保持されています。<br>
	///いわば、遺伝的アルゴリズムの記録と言えます。<br>
	///本メソッドでは世代を指定することでその世代の最優秀個体を得ることができます。<br>
	///これにより世代による個体の成長を見ることもできます。<br>
	///@param generationIndex 指定する世代
	///@return 指定世代の最優秀個体
	///@throws ArgumentOutOfRangeException 指定世代が記録されている世代数の範囲を超えています
	///</sammary>
	public Individual GetSuperior(int generationIndex)
	{ //throws ArgumentOutOfRangeException {

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
	///<p>記録した現検索の優秀個体の情報を全て削除します。</p>
	///本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>
	///</sammary>
	public void ClearSuperior()
	{

		//------ 記録を全て削除 ------//
		this.superior.Clear();
	}

	//===========================================================//
	//-------------------- 全検索中の最優秀個体 --------------------//
	//===========================================================//

	///<sammary>
	///<p>今までの全検索の内、最優秀である個体を返します。</p>
	///全検索とは、複数回の検索全てを含みます。<br>
	///よって最終的な検索結果となります。<br>

	///@return 全検索中最優秀個体
	///</sammary>
	public Individual GetBestIndividual()
	{


		//------ 最優秀の個体を返す ------//
		return this.bestIndividual;
	}

	///<sammary>
	///<p>最優秀候補を交代します。</p>
	///適応度計算アルゴリズムによって適応度が比較され、現在保持されている最優秀個体よりも優秀な場合は交代となります。<br>
	///つまり、候補を引数として渡せば自動的にチェックされます。<br>
	///本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>

	///@param candidate 最優秀個体候補
	///@param geneticNumber 現在の世代数
	///@throws IllegalGenoSizeException 候補として渡された個体の遺伝子の遺伝子長が一致していません
	///@throws IllegalGenoTypeException 候補として渡された個体の遺伝子の塩基タイプが一致していません
	///</sammary>
	public void SetBestIndividual(Individual candidate)
	{

		//------ 始めの1回目かチェック ------//
		if (this.bestIndividual == null)
		{

			//------ 始めの1回は無条件で登録 ------//
			this.bestIndividual = candidate;
			return;
		}

		if (this.fitness == null) throw new NullReferenceException("fitnessがNullです");

		//------ 適応度が現在の最優秀候補よりも高いかチェック ------//
		if (this.fitness.GetFitnessValue(this.bestIndividual) < this.fitness.GetFitnessValue(candidate))
		{
			//------ さらに優秀な個体が現れたので交代 ------//
			this.bestIndividual = candidate;

			//------ 最優秀個体が交代したので報告 ------//
			this.reporter.Report(this.bestIndividual);
		}
	}
}
