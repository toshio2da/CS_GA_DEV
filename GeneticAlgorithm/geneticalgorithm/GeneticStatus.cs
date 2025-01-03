namespace jp.co.tmdgroup.common.geneticalgorithm;

using jp.co.tmdgroup.common.geneticalgorithm.exception;

using System.Runtime.CompilerServices;

/**
 * <p>遺伝的アルゴリズムによる検索の状態を保持します。</p>
 * 遺伝的アルゴリズムによる最適解の検索は一般的に長い時間を必要とします。<br>
 * GeneticAlgorithmクラスによる検索は本クラスにその状態を保持させることができます。<br>
 * GeneticAlgorithmはその検索の際、自己スレッドを立て、その中で処理を行います。<br>
 * その途中経過と最終結果のデータの受け渡しクラスが本クラスとなります。<br>
 * 本クラスに適切な値をセットさせることで検索を中断するなどの操作を行うことが出来ます。<br>
 * また、途中結果や最終結果が本クラスに格納されるのでそれらをユーザーに表示させることもできます。<br>
 * データは自動的に同期が取られます。処理速度のためにも不要なアクセスはしないことをお奨めします。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/11/05)
 */
public class GeneticStatus
{


	//====================================================//
	//-------------------- クラス定数 --------------------//
	//====================================================//

	/** 検索続行命令。検索中は通常この命令が格納されています。 */
	static public int GO_AHEAD_SEARCH = 0;

	/** 検索終了命令。検索を終了させるときに格納します。世代交代時にチェックされます。 */
	static public int STOP_SEARCH = 1;


	/** 状態変数。現在検索中であることを示します。 */
	static public int SEARCHING = 100;

	/** 状態変数。検索が完了したことを示します。*/
	static public int DONE_SEARCH = 101;

	/** 状態変数。検索を待っていることを示します。デフォルト値です。*/
	static public int WAIT_FOR_SEARCH = 102;


	/** 検索の種類。指定世代数まで世代交代を行います。デフォルト値です。 */
	static public int LIMIT_NUMBER = 200;

	/** 検索の種類。指定時間まで延々と世代交代を行います。*/
	static public int LIMIT_TIME = 201;

	/** 検索の種類.指定世代数の検索を指定時間まで繰り返します。広範囲に渡る検索が可能です。*/
	static public int LIMIT_NUMBER_UNTIL_TIME = 202;





	//====================================================//
	//-------------------- メンバ変数 --------------------//
	//====================================================//

	/** 各世代の最優秀個体(最新の検索中) */
	protected List<Individual> superior = new List<Individual>();

	/** 全検索の中で生き残った最優秀個体 */
	protected Individual bestIndividual = null;

	/** 検索に対する命令格納場所。別スレッドで動くためこの変数を介して制御します。 */
	protected int command = GeneticStatus.GO_AHEAD_SEARCH;

	/** 状態変数です。現在の検索状況を示します。*/
	protected int status = GeneticStatus.WAIT_FOR_SEARCH;

	/** 検索の方法を示します。世代交代数指定と時間指定、またはその組み合わせが可能です。 */
	protected int search_method = GeneticStatus.LIMIT_NUMBER;

	/** 適応度計算アルゴリズム。GeneticAlgorithmクラスに自動的に設定されます。 */
	protected FitnessAlgorithm fitness;

	/** 途中経過の報告クラス。デフォルトでは標準出力に適応度を出力 */
	public GeneticReportable reporter = new DefaultGeneticReporter();




	//================================================//
	//-------------------- 構築子 --------------------//
	//================================================//

	/**
     * <p>構築子です。</p>
     */
	public GeneticStatus()
	{
	}





	//====================================================================//
	//-------------------- 適応度計算アルゴリズム設定 --------------------//
	//====================================================================//

	/**
     * <p>適応度計算アルゴリズムを設定します。</p>
     * このメソッドはGeneticAlgorithmクラスによって自動的に呼び出されます。<br>
     *
     * @param fitness 設定する適応度計算アルゴリズム
     */
	public void setFitnessAlgorithm(FitnessAlgorithm fitness)
	{

		//------ 適応度計算アルゴリズムを設定 ------//
		this.fitness = fitness;
	}








	//==========================================================//
	//-------------------- 途中経過報告クラス --------------------//
	//==========================================================//

	/**
     * <p>現在保持されている途中経過報告クラスを取得します。</p>
     *
     * @return 保持され値得る途中経過報告クラス
     */
	public GeneticReportable getReporter()
	{

		//------ 現在の途中経過報告クラスを渡す ------//
		return this.reporter;
	}


	/**
     * <p>途中経過報告クラスを変更します。</p>
     *
     * @param newReporter 新しい途中経過報告クラス
     */
	public void setReporter(GeneticReportable newReporter)
	{

		//------ 途中経過報告クラスを変更 ------//
		this.reporter = newReporter;
	}




	//==================================================//
	//-------------------- 検索命令 --------------------//
	//==================================================//



	/**
     * <p>現在の検索命令を取得します。</p>
     *
     * @return 現在設定されている検索命令
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public int getCommand()
	{

		//------ 現在の検索命令を取得します。 ------//
		return this.command;
	}



	/**
     * <p>検索命令を設定します。</p>
     * 本メソッドによって検索命令を設定することで別スレッドで行っている検索を中断することが出来ます。<br>
     *
     * @param command 設定する検索命令。GeneticStatus.STOP_SEARCH で検索を中断できます。
     * @throws ArgumentException サポートされていない検索命令を設定しようとしました。
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void setCommand(int command)
	{ //throws ArgumentException {

		//------ サポートされている検索命令かチェック ------//
		if (command != GeneticStatus.GO_AHEAD_SEARCH && command != GeneticStatus.STOP_SEARCH)
		{

			throw new ArgumentException("サポートされていない検索命令です");
		}


		//------ 検索命令を設定 ------//
		this.command = command;
	}






	//==================================================//
	//-------------------- 状態変数 --------------------//
	//==================================================//

	/**
     * <p>現在の検索状況を取得します。検索中、検索完了の2つがあります。</p>
     * 別スレッドで検索する場合終了通知がありません。<br>
     * よって本メソッドにより検索状態を取得し、完了していればユーザーに完了通知を行います。<br>
     *
     * @return 状態を返します。GeneticStatus.SEARCHING(検索中)と GeneticStatus.DONE_SEARCH(検索完了)があります。
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public int getSearchStatus()
	{

		//------ 現在の状態を返す ------//
		return this.status;
	}


	/**
     * <p>GeneticAlgorithmによって現在の検索状況を設定するメソッドです。</p>
     * よってGeneticAlgorithmによって自動的に呼び出されます。
     *
     * @param newStatus 現在の検索状態です。GeneticStatus.SEARCHING(検索中)と GeneticStatus.DONE_SEARCH(検索完了)があります。
     * @throws ArgumentException サポートされていない状態変数を設定しようとしました。
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void setSearchStatus(int newStatus)
	{ //throws ArgumentException {

		//------ サポートしているかチェックする ------//
		if (status != GeneticStatus.SEARCHING && status != GeneticStatus.DONE_SEARCH && status != GeneticStatus.WAIT_FOR_SEARCH)
		{

			throw new ArgumentException("サポートされていない状態変数です。");
		}


		//------ 検索状態を変更 ------//
		this.status = newStatus;
	}





	//==================================================//
	//-------------------- 検索手法 --------------------//
	//==================================================//

	/**
     * <p>現在の検索手法を返します。世代交代数の指定、時間指定、その組み合わせの3種類があります。</p>
     * GeneticStatus.LIMIT_NUMBER(世代交代数指定)とGeneticStatus.LIMIT_TIME(時間指定)、
     * GeneticStatus.LIMIT_NUMBER_UNTIL_TIME(両方の組み合わせ)の3種類です。<br>
     *
     * @return 現在の検索手法です。
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public int getSearchMethod()
	{

		//------ 現在の検索手法を返す ------//
		return this.search_method;
	}


	/**
     * <p>検索手法を変更します。世代交代数の指定、時間指定、その組み合わせの3種類があります。</p>
     * GeneticStatus.LIMIT_NUMBER(世代交代数指定)とGeneticStatus.LIMIT_TIME(時間指定)、
     * GeneticStatus.LIMIT_NUMBER_UNTIL_TIME(両方の組み合わせ)の3種類です。<br>
     *
     * @param newSearchMedthod 新しく変更する検索手法です
     * @throws ArgumentException 説明にある3種類の値以外の値を渡すと送出されます。
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void setSearchMethod(int newSearchMethod)
	{ //throws ArgumentException {

		//------ チェック ------//
		if (newSearchMethod != GeneticStatus.LIMIT_NUMBER && newSearchMethod != GeneticStatus.LIMIT_TIME &&
			newSearchMethod != GeneticStatus.LIMIT_NUMBER_UNTIL_TIME)
		{
			throw new ArgumentException("不正な検索手法を指定しています。");
		}


		//------ 検索手法を変更 ------//
		this.search_method = newSearchMethod;
	}



	//==========================================================//
	//-------------------- 現検索中の優秀個体 --------------------//
	//=========================================================//

	/**
     * <p>指定した世代の最優秀個体を取得します。</p>
     * 本クラスには各世代の最高個体が保持されています。<br>
     * いわば、遺伝的アルゴリズムの記録と言えます。<br>
     * 本メソッドでは世代を指定することでその世代の最優秀個体を得ることができます。<br>
     * これにより世代による個体の成長を見ることもできます。<br>
     *
     * @param generationIndex 指定する世代
     * @return 指定世代の最優秀個体
     * @throws ArgumentOutOfRangeException 指定世代が記録されている世代数の範囲を超えています
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public Individual getSuperior(int generationIndex)
	{ //throws ArgumentOutOfRangeException {

		//------ サイズをチェック ------//
		if (generationIndex >= this.superior.Count)
			throw new ArgumentOutOfRangeException("指定世代が保持世代サイズを越えています");


		//------ 指定された世代の最高個体を取得 ------//
		return this.superior[generationIndex];
	}



	/**
     * <p>新しい世代の最優秀個体を登録します。</p>
     * 本メソッドはGeneticAlgorithmクラスによって呼ばれます。<br>
     *
     * @param newBestIndividual 新しく登録する個体
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	void setSuperior(Individual newBestIndividual)
	{

		//------ 個体を登録 ------//
		this.superior.Add(newBestIndividual);
	}




	/**
     * <p>記録した現検索の優秀個体の情報を全て削除します。</p>
     * 本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void clearSuperior()
	{

		//------ 記録を全て削除 ------//
		this.superior.Clear();
	}





	//===========================================================//
	//-------------------- 全検索中の最優秀個体 --------------------//
	//===========================================================//

	/**
     * <p>今までの全検索の内、最優秀である個体を返します。</p>
     * 全検索とは、複数回の検索全てを含みます。<br>
     * よって最終的な検索結果となります。<br>
     *
     * @return 全検索中最優秀個体
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public Individual getBestIndividual()
	{


		//------ 最優秀の個体を返す ------//
		return this.bestIndividual;
	}



	/**
     * <p>最優秀候補を交代します。</p>
     * 適応度計算アルゴリズムによって適応度が比較され、現在保持されている最優秀個体よりも優秀な場合は交代となります。<br>
     * つまり、候補を引数として渡せば自動的にチェックされます。<br>
     * 本メソッドはGeneticAlgorithmクラスによって呼び出されます。<br>
     *
     * @param candidate 最優秀個体候補
     * @param geneticNumber 現在の世代数
     * @throws IllegalGenoSizeException 候補として渡された個体の遺伝子の遺伝子長が一致していません
     * @throws IllegalGenoTypeException 候補として渡された個体の遺伝子の塩基タイプが一致していません
     */
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void setBestIndividual(Individual candidate)
	{ //throws IllegalGenoSizeException, IllegalGenoTypeException {

		//------ 始めの1回目かチェック ------//
		if (this.bestIndividual == null)
		{

			//------ 始めの1回は無条件で登録 ------//
			this.bestIndividual = candidate;
			return;
		}



		//------ 適応度が現在の最優秀候補よりも高いかチェック ------//
		if (this.fitness.fitness(this.bestIndividual) < this.fitness.fitness(candidate))
		{

			//------ さらに優秀な個体が現れたので交代 ------//
			this.bestIndividual = candidate;


			//            jp.co.tmdgroup.common.tmdtools.DataTools.output((int[])this.bestIndividual.getGene().getBase());


			//------ 最優秀個体が交代したので報告 ------//
			this.reporter.report(this.bestIndividual);
		}
		//        else {Console.Write("|");};
	}
}
