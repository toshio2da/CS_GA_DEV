namespace jp.co.tmdgroup.common.geneticalgorithm;


using jp.co.tmdgroup.common.geneticalgorithm.exception;
using jp.co.tmdgroup.common.geneticalgorithm.model;
using jp.co.tmdgroup.common.interfaces;
using jp.co.tmdgroup.common.interfaces.exception;

using System.Globalization;

using static System.Runtime.InteropServices.JavaScript.JSType;


/**
 * <p>遺伝的アルゴリズムにより様々な組み合わせ問題の準最適解を高速に検索します。</p>
 * 遺伝的アルゴリズムは様々な問題の解候補を遺伝子配列として表現し、その遺伝子を持つ個体を
 * 多数存在させ、淘汰、交叉、突然変異などを用いて準最適解を検索する自然界をモチーフにした手法です。<br>
 * Nクイーン問題、巡回サラリーマン問題など、式を用いた解法が困難な場合に非常に有効な手法です。<br>
 * 本クラスはモデルクラスによってその挙動を定めます。<br>
 * モデルクラスはGeneticAlgorithmModelインタフェースの実装クラスによってなされます。<br>
 * モデルクラスにより柔軟なカスタマイズを容易に行うことができます。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリ</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/11/01)
 */

public class GeneticAlgorithm :
	//Runnable, 
	SearchAlgorithm
{


	//==================================================//
	//-------------------- メンバ変数 --------------------//
	//==================================================//

	/** 探索に用いる個体の数。デフォルトでは200 */
	protected int peopleNumber = 200;

	/** 遺伝的アルゴリズムに用いる個体の集団 */
	protected List<Individual> group = new List<Individual>();

	/** 使用する遺伝的アルゴリズムのモデルクラス */
	protected GeneticAlgorithmModel model;

	/** 検索状況の報告クラス。自動的に同期が取られます。 */
	protected GeneticStatus status = null;

	/** 現在の世代交代数を保持します。 */
	protected int nowGenerationNumber = 0;

	/** 検索を始めた時間を保持します */
	protected long startingTime = 0;

	/** 指定された世代交代数。デフォルトは3000[回] */
	protected int generationNumber = 3000;

	/** 指定された検索時間[秒]。デフォルトは60[秒] */
	protected long searchingTime = -1;

	/** 進化中断までのインターバル */
	protected int stopSearchInterval = -1;

	/** 進化中断までの無進化世代数*/
	protected int stopSearchGeneration = -1;





	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>構築子です。デフォルトでは集団数は200、最大世代数は1000となっています。</p>
     * 最大世代数に到達するか、個体の示す究極の個体(最大適応度を持つ)が現れると探索を終了します。<br>
     *
     * @param model 使用する遺伝的アルゴリズムのモデルクラス
     * @param status 状況報告クラス。検索の制御にも使用。
     */
	public GeneticAlgorithm(GeneticAlgorithmModel model, GeneticStatus status)
	{

		//------ 使用するモデルクラスを保持 ------//
		this.model = model;


		//------ 状況報告クラスを保持 ------//
		this.status = status;


		//------ 適応度計算アルゴリズムを渡す ------//
		this.status.setFitnessAlgorithm(this.model.getFitnessAlgorithm());


		//------ 集団を形成 ------//
		for (int index = 0; index < this.peopleNumber; index++)
		{

			//------ 個体を準に生成 ------//
			this.group.Add(new Individual(this.model.getIndividualModel()));
		}
	}



	/**
     * <p>構築子です。集団数と最大世代交代数を指定します。</p>
     * 最大世代数に到達するか、個体の示す究極の個体(最大適応度を持つ)が現れると探索を終了します。<br>
     *
     * @param model 使用する遺伝的アルゴリズムのモデルクラス
     * @param status 状況報告クラス。検索の制御にも使用。
     * @param peopleNumber 集団の個体数
     */
	public GeneticAlgorithm(GeneticAlgorithmModel model, GeneticStatus status, int peopleNumber)
	{

		//------ 集団数と最大世代交代数を保持 ------//
		this.peopleNumber = peopleNumber;              // 集団数を保持


		//------ 状況報告クラスを保持 ------//
		this.status = status;


		//------ 使用するモデルクラスを保持 ------//
		this.model = model;


		//------ 適応度計算アルゴリズムを渡す ------//
		this.status.setFitnessAlgorithm(this.model.getFitnessAlgorithm());


		//------ 集団を形成 ------//
		for (int index = 0; index < this.peopleNumber; index++)
		{

			//------ 個体を準に生成 ------//
			this.group.Add(new Individual(this.model.getIndividualModel()));
		}
	}



	/**
     * <p>検索に用いる世代交代数を取得します。</p>
     * 世代交代数指定、または検索時間かつ世代交代数指定の場合に用いられる世代交代数です。<br>
     *
     * @return 現在設定されている世代交代数
     */
	public int getGenetationNumber()
	{

		//------ 現在設定されている検索を行う世代交代数を取得 ------//
		return this.generationNumber;
	}


	/**
     * <p>世代交代数を設定します。</p>
     * 世代交代数指定、または検索時間かつ世代交代数指定の場合に用いられる世代交代数です。<br>
     *
     * @param newGenerationNumber 設定する世代交代数です。
     */
	public void setGenerationNumber(int newGenerationNumber)
	{

		//------ 世代交代数を設定 ------//
		this.generationNumber = newGenerationNumber;
	}


	/**
     * <p>検索時間[秒]を取得します。</p>
     * 時間指定、または時間指定かつ世代交際数指定の場合に用いられる検索時間です。<br>
     *
     * @return 現在設定されている検索時間を取得します。
     */
	public long getSearchingTime()
	{

		//------ 現在設定されている検索時間を取得 ------//
		return this.searchingTime;
	}


	/**
     * <p>検索時間[秒]を設定します。</p>
     * 時間指定、または時間指定かつ世代交際数指定の場合に用いられる検索時間です。<br>
     *
     * @param newSearchingTime 設定する検索時間[秒]です。
     */
	public void setSearchingTime(long newSearchingTime)
	{

		//------ 検索時間を設定 ------//
		this.searchingTime = newSearchingTime;
	}



	/**
     * <p> 進化を中断する無進化世代数を設定します</p>
     * 指定された世代数進化が無ければそこで中止とします
     * 負の値がセットされた場合は無視されます
     * @param genelation  世代数
     */
	public void setStopSearchGeneration(int generation)
	{
		stopSearchGeneration = generation;
	}

	public int getStopSearchGeneration()
	{
		return stopSearchGeneration;
	}

	/**
     * <p> 進化を中断する無進化時間を設定します</p>
     * 指定された時間に進化が無ければそこで中止とします
     * 負の値がセットされた場合は無視されます
     * @param interval    時間[秒]
     */
	public void setStopSearchInterval(int interval)
	{
		stopSearchInterval = interval;
	}


	public int getStopSearchInterval()
	{
		return stopSearchInterval;
	}


	//==========================================================================//
	//-------------------- SearchAlgorithmインタフェースの実装 --------------------//
	//==========================================================================//

	/**
     * <p>遺伝的アルゴリズムを用いて様々な組み合わせ問題の準最適解を高速に検索します。</p>
     * 探索は集団内の個体の適応度によって評価されます。<br>
     * 最高の適応度を持った究極の個体が現れるか、最大世代交代数の世代交代を終了するとその時点で最適な個体が返されます。<br>
     * 満足のいく結果が得られない場合は再び本メソッドを呼ぶことで探索の続きを行うことができます。<br>
     * つまり、探索が終了しても中の個体情報は保持されています。<br>
     * <br>
     * 本メソッドを直接呼び出して検索を行う場合には呼び出しスレッドがブロックされます。<br>
     * つまり、検索中に処理を行うことができなくなります。<br>
     * 本クラスは別スレッドによる検索を行うことが可能です。<br>
     * 本メソッドを直接呼ばす、start()メソッドを呼び出すことにより呼び出し元とは異なるスレッドを生成し、検索を行います。<br>
     * 途中経過の取得や検索中止命令などは構築時に渡したGeneticStatusクラスによって行うことができます。<br>
     *
     * @param maxIterationNumber 最大繰り返し数
     * @return 探索で得た最適の個体(class: individual)
     * @throws IllegalParameterTypeException 遺伝子の塩基タイプに不正があります。FitnessAlgorithmと一致していません。
     * @throws IllegalParameterSizeException 遺伝子長が異なります。モデルクラスの値と一致していません。
     * @throws IllegalElementException 個体の中にIndividualクラス又はその派生クラスでないものが含まれています。
     * @throws ArgumentOutOfRangeException 保持世代数を越えた位置を指定しました。
     */
	public Individual search(int maxIterationNumber)
	{
		//throws IllegalParameterTypeException, IllegalParameterSizeException, IllegalElementException, ArgumentOutOfRangeException {
		try
		{
			//------ 各世代毎の優秀な個体を登録していく ------//
			//List bestIndividuals = new LinkedList();                             // 各世代の最優秀者の一覧
			this.startingTime = DateTime.Now.Ticks;                     // 現在の時刻を記録

			//------ 初めに全個体の適応度を計算 ------//

			foreach (var individual in this.group)
			{
				//------ 適応度を計算・個体に保持させる。究極の個体が現れたらその場で終了 ------//

				double fitnessValue = this.model.getFitnessAlgorithm().fitness(individual);   // 適応度を計算
				if (fitnessValue == this.model.getFitnessAlgorithm().getBestFitnessValue())   // 究極の個体か検証
					this.status.setCommand(GeneticStatus.STOP_SEARCH);                        // 究極の個体であれば返す
			}
			this.status.setBestIndividual(this.group[0]);


			//------ 最大世代交代数まで繰り返す ------//
			this.nowGenerationNumber = 0;

			//前回進化した時間(秒)
			long lastEvolutionTime = DateTime.Now.Ticks;// DateTime.Now.Ticks;
														//前回進化してからの世代数
			int lastEvolutionGeneration = 0;
			//検索終了目標
			long limitSearchingTime = searchingTime * 1000;

			//前回の最大評価
			double lastBestFitnessValue = Double.MaxValue;
			double bestFitnessValue;


			for (int index = 0; index < maxIterationNumber; index++)
			{
				//------ 世代毎の一番優秀な個体を登録していく ------//
				this.status.setBestIndividual(this.newGeneration());

				//------ 中断命令がきていれば検索を強制終了 ------//
				if (this.status.getCommand() == GeneticStatus.STOP_SEARCH)
				{
					break;
				}

				//------ 世代交代数を記録 ------//
				this.nowGenerationNumber++;

				//------ 検索時間が終了していれば終了 --------//
				long nowTime = DateTime.Now.Ticks;
				if ((limitSearchingTime > 0) && (nowTime - startingTime) > limitSearchingTime)
				{
					break;
				}

				//------ 新しい進化があったかどうかを調べる ------//
				bestFitnessValue = this.status.getBestIndividual().getFitnessValue();
				if (lastBestFitnessValue != bestFitnessValue)
				{
					lastBestFitnessValue = bestFitnessValue;
					//世代をリセット
					lastEvolutionGeneration = 0;
					//経過時間をリセット
					lastEvolutionTime = DateTime.Now.Ticks;
				}
				else
				{
					lastEvolutionGeneration++;
					if ((this.stopSearchGeneration > 0) && lastEvolutionGeneration > this.stopSearchGeneration)
					{
						break;
					}
					else if ((this.stopSearchInterval > 0) && ((DateTime.Now.Ticks - lastEvolutionTime) / 1000) > this.stopSearchInterval)
					{
						break;
					}
				}
			}


			//------ 最大世代交代数が終わっても究極の個体が見つからなかったのでその中で一番個体を返す ------//
			Individual lastSuperior = this.status.getBestIndividual();

			this.status.setSearchStatus(GeneticStatus.DONE_SEARCH);
			this.status.reporter.finishReport(lastSuperior, this.nowGenerationNumber, DateTime.Now.Ticks - this.startingTime);
			return lastSuperior;
		}
		catch (ArgumentException exception)
		{
			Console.WriteLine(exception.StackTrace);
			return this.status.getBestIndividual();
		}
		catch (IllegalGenoTypeException exception)
		{
			throw new IllegalParameterTypeException("遺伝子内の塩基タイプが不正です。");
		}
		catch (IllegalGenoSizeException exception)
		{
			throw new IllegalParameterSizeException("遺伝子長が一致しません。");
		}
		catch (IllegalIndividualException exception)
		{
			throw new IllegalElementException("Individualクラスでない個体があります。");
		}
		catch (OutOfBoundsGeneException exception)
		{
			throw new ArgumentOutOfRangeException("保持世代を越えたアクセスがありました。");
		}
	}




	/**
     * <p>遺伝的アルゴリズムによる検索を1世代進めます。</p>
     * 世代交代を1世代行い、遺伝的アルゴリズムによる検索を進めます。<br>
     * 本メソッドは検索メソッド search() から呼ばれる内部メソッドです。<br>
     * 本メソッドを繰り返す呼び出すことで検索を進めることが出来ます。<br>
     *
     * @return 世代の中で一番優秀な個体
     * @throws IllegalGenoTypeException 遺伝子の塩基タイプに不正があります。FitnessAlgorithmと一致していません。
     * @throws IllegalGenoSizeException 遺伝子長が異なります。モデルクラスの値と一致していません。
     * @throws IllegalIndividualException 個体の中にIndividualクラス又はその派生クラスでないものが含まれています。
     * @throws OutOfBoundsGeneException 保持世代数を越えた位置を指定しました。
     */
	protected Individual newGeneration()
	{
		//throws IllegalGenoTypeException, IllegalGenoSizeException, IllegalIndividualException, OutOfBoundsGeneException {

		//------ 既に究極の個体がいる場合にはその個体を即時に返す ------//
		if (this.status.getBestIndividual() == null) ;
		else if (this.status.getBestIndividual().getFitnessValue() == this.model.getFitnessAlgorithm().getBestFitnessValue())
		{

			return this.status.getBestIndividual();
		}


		//------ 生存を行う。優秀な親は次世代集団に残る ------//
		List<Individual> survivors = this.model.getSurvivalAlgorithm().survive(this.group);


		//------ 淘汰を行う。優秀な個体が多く残る ------//
		List<Individual> new_group = this.model.getSelectionAlgorithm().select(this.group);


		//------ 交叉を行う。生存しなかった親は全て入れ替える ------//
		List<Individual> children = this.model.getCrossoverAlgorithm().crossover(new_group, new_group.Count - survivors.Count);



		//------ 突然変異を子集団の各塩基に対して行う。突然変異率が0.0の場合は行わない ------//
		double mutationProbability = this.model.getMutationProbability();
		if (mutationProbability != 0.0)
		{
			this.mutation(children.GetEnumerator(), mutationProbability);
		}


		//------ 逆位を子集団の各個人に対して行う。逆位率が0.0の場合は行わない ------//
		double inverseProbability = this.model.getInverseProbability();
		if (inverseProbability != 0.0)
		{
			this.inverse(children.GetEnumerator(), inverseProbability);
		}


		//------ 親の生存集団と次世代子供集団を新しい世代として結合 ------//
		List<Individual> nextGeneration = new List<Individual>(survivors);                // 親の生き残りを次世代集団に追加
		nextGeneration.AddRange(children);                                // 新しい子供達を次世代集団に追加


		//------ 世代交代 ------//
		this.group = nextGeneration;



		//------ 新しい世代の適応度を算出、究極の個体があれば検索終了 ------//
		foreach (Individual individual in group)
		{

			//}

			//Iterator iterator = this.group.iterator();
			//while (iterator.hasNext())
			//{

			//------ 適応度を計算・個体に保持させる。究極の個体が現れたらその場で終了 ------//
			//Individual individual = (Individual)iterator.next();                          // 個体を取得
			double fitnessValue = this.model.getFitnessAlgorithm().fitness(individual);   // 適応度を計算
			if (fitnessValue == this.model.getFitnessAlgorithm().getBestFitnessValue())   // 究極の個体か検証
				return individual;                                                        // 究極の個体であれば返す
		}


		//------ 適応度順にソートする・世代内で一番優秀な個体を取得 ------//
		//Collections.sort(this.group);                                                     // 適応度でソート
		this.group.Sort();
		Individual bestIndividual = this.group[0];                    // 世代の中で一番優秀な個体を取得


		//------ 今の世代の中で一番優秀な個体を登録 ------//
		return bestIndividual;
	}




	/**
     * <p>保持集団を初期状態に戻します。<p>
     * 各個体をランダムに生成し直します。<br>
     * これにより初めから探索をやり直すことができます。<br>
     */
	public void reset()
	{

		//------ 集団を一旦全削除 ------//
		this.group.Clear();


		//------ 今までの記録も削除 ------//
		this.status.clearSuperior();


		//------ 集団を再形成 ------//
		for (int index = 0; index < this.peopleNumber; index++)
		{

			//------ 個体を準に生成 ------//
			this.group.Add(new Individual(this.model.getIndividualModel()));
		}
	}




	//==============================================================================//
	//-------------------- Threadクラスメソッドのオーバーライド --------------------//
	//==============================================================================//

	public void run()
	{

		try
		{
			//------ 状況報告クラスが設定されていない場合は何もせずに返す ------//
			if (this.status == null)
			{
				return;
			}


			//------ 状況報告クラスから情報を取得 ------//
			int searchMethod = this.status.getSearchMethod();


			//------ 今回は必ず世代数指定 ------//
			if (searchMethod == GeneticStatus.LIMIT_NUMBER)
			{
				this.search(this.getGenetationNumber());
			}



		}
		catch (Exception exception)
		{
			Console.WriteLine(exception.StackTrace);
		}
	}




	//====================================================//
	//-------------------- 内部メソッド --------------------//
	//====================================================//

	/**
	 * <p>集団に対して突然変異操作を行います。</p>
	 * 内部メソッドです。<br>
	 *
	 * @param individualIterator 集団の先頭イテレータ
	 * @param mutationProbability 各塩基に対して突然変異が起こる確率
	 * @throws OutOfBoundsGeneException 遺伝子範囲外の塩基にアクセスすると送出されます
	 */
	protected void mutation(IEnumerator<Individual> individualIterator, double mutationProbability)
	{ //throws OutOfBoundsGeneException {

		//------ 各個人の各塩基に対して行う ------//
		while (individualIterator.MoveNext())
		{
			//------ 個体を遺伝子を取得 ------//
			Individual individual = (Individual)individualIterator.Current;  // 突然変異を行う個体を取得
			IGene gene = individual.getGene();                   // その個体が持つ遺伝子を取得

			//------ 各塩基に対して行う ------//
			for (int geneIndex = 0; geneIndex < gene.getGenoSize(); geneIndex++)
			{

				//------ 確率のサイコロを振る ------//
				if (GARandomGenerator.random() < mutationProbability)
				{
					gene.mutateOneGene(geneIndex);                  // 突然変異
				}
			}
		}
	}



	/**
	 * <p>集団の個体全部に対して逆位を行います。</p>
	 * 内部メソッドです。<br>
	 *
	 * @param individualIterator 操作する集団の先頭イテレータ
	 * @param inverseProbability 逆位を起こす確率
	 * @throws OutOfBoundsGeneException 遺伝子範囲外の塩基にアクセスすると送出されます
	 */
	protected void inverse(IEnumerator<Individual> individualIterator, double inverseProbability)
	{ //throws OutOfBoundsGeneException {

		//------ 各個体に対して行う ------//
		while (individualIterator.MoveNext())
		{

			//------ 個体と遺伝子を取得 ------//
			Individual individual = (Individual)individualIterator.Current;
			IGene gene = individual.getGene();

			//------ 確率のサイコロ以下であれば逆位を行う。逆位点はランダムに生成 ------//
			if (GARandomGenerator.random() < inverseProbability)
			{

				gene.InverseSubGene((int)(GARandomGenerator.random() * gene.getGenoSize()), (int)(GARandomGenerator.random() * gene.getGenoSize()));
			}
		}
	}
}
