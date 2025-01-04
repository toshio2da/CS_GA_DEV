namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.tmdtools;
using jp.co.tmdgroup.common.interfaces.exception;
using jp.co.tmdgroup.common.geneticalgorithm;
using jp.co.tmdgroup.common.geneticalgorithm.exception;
using System.Runtime.CompilerServices;

/**
 * N-QUEEN問題を解きます。
 *
 * @author Hiroshi Morimoto
 * @version 1.0
 */
public class NQueen
{

	//MainForm owner
	


	//
	// 探索状態定数
	//

	/**
	 * 探索の開始を待っています
	 **/
	public readonly int WAIT_FOR_SEARCH = GeneticStatus.WAIT_FOR_SEARCH;

	/**
	 * 探索が終了
	 **/
	public readonly int DONE_SEARCH = GeneticStatus.DONE_SEARCH;

	/**
	 * 探索中
	 **/
	public readonly int SEARCHING = GeneticStatus.SEARCHING;

	/**
	 * 探索状態変数
	 **/
	int status = GeneticStatus.WAIT_FOR_SEARCH;

	//
	// 制御コマンド定数
	//

	/**
	 * 探索中止コマンド
	 **/
	public readonly int STOP_SEARCH = GeneticStatus.STOP_SEARCH;

	/**
	 * 探索継続コマンド
	 **/
	readonly int GO_AHEAD_SEARCH = GeneticStatus.GO_AHEAD_SEARCH;

	/**
	 * 制御コマンド変数
	 **/
	int command = GeneticStatus.GO_AHEAD_SEARCH;

	/**
	 * 探索結果
	 **/
	int[] bestPattern;

	/**
	 * 探索用スレッド
	 **/
	Thread searchThread = new Thread;

	/**
	 * コンストラクタ
	 * @param o 問題領域のモデル
	 **/
	NQueen(MainForm o)
	{
		this.owner = o;
		bestPattern = new int[] { -1 };
	}

	/**
	 * 現在の探索状態を取得します。
	 * @return 状態({@link #WAIT_FOR_SEARCH}:探索開始待ち、{@link #SEARCHING}:探索中、{@link #DONE_SEARCH}:探索終了)
	 **/
	[MethodImpl(MethodImplOptions.Synchronized)]
	public int getSearchStatus()
	{
		return this.status;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void setSearchStatus(int new_status)
	{
		this.status = new_status;
	}

	/**
	 * 探索命令をセットします。
	 * @param command 探索命令({@link #STOP_SEARCH}:探索中断）
	 * @exception IllegalValueException サポートされていない探索命令をセットした
	 **/
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void setCommand(int commnad)
	{ //throws IllegalValueException {
		if (command != NQueen.STOP_SEARCH)
		{
			throw new IllegalValueException("サポートしていない探索命令です:" + command);
		}
		this.command = command;
		if (gaStatus != null)
		{
			this.gaStatus.setCommand(this.command);
		}
	}

	/**
	 * セットされている探索命令を取得します
	 * @return 探索命令
	 **/
	[MethodImpl(MethodImplOptions.Synchronized)]
	int getCommand()
	{
		return this.command;
	}

	/**
	 * 探索結果をセットします
	 * @param p セットするパターン
	 */
	[MethodImpl(MethodImplOptions.Synchronized)]
	void setBestPattern(int[] p)
	{
		this.bestPattern = p;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	int[] getBestPattern()
	{
		return this.bestPattern;
	}

	/**
	 * 別スレッドで探索を行います。
	 **/
	public void start()
	{
		this.searchThread = new Thread(
				new Runnable()
				{
					public void run()
	{
		NQueen.this.search();
	}
});
		this.searchThread.start();
}

/**
 * 探索が終了するまでこのメソッドを呼び出したスレッドをブロックします
 **/
public void join()
{ //throws InterruptedException {
	this.searchThread.join();
}

/**
 * 探索スレッドが生存しているかチェックします。
 **/
public boolean isAlive()
{
	return this.searchThread.isAlive();
}

/**
 * 最適な乗り合わせパターンを探索します
 * @return 探索結果（エラーが発生した場合は<code>null</code>）
 **/
public void search()
{
	try
	{
		ga();
		return;

	}
	catch (IllegalParameterTypeException e)
	{
	}
	catch (IllegalParameterSizeException e)
	{
	}
	catch (IllegalElementException e)
	{
	}
	catch (OutOfBoundsException e)
	{
	}
	catch (ExceptionInInitializerError e)
	{
		//		} catch (IllegalAccessException e) {
		//		} catch (InstantiationException e) {
	}
	return;
}

//
// 遺伝的アルゴリズムによる探索
//

/**
 * GAの状態オブジェクト
 **/
GeneticStatus gaStatus;

/**
 * QUEEN の数
 */
int NumOfQueens = 10;

/**
 * 個体数
 **/
int individualNumber = 100;

/**
 * 繰り返し回数（世代数）
 **/
int iterationNumOfGA = 500;

/**
 * 最大コスト
 **/
double bestValue = Double.MAX_VALUE;

/**
 * QUEEN数をセットします
 * @param num QUEEN数
 */
public void setQueens(int num)
{
	this.NumOfQueens = num;
}

/**
 * 設定されているQUEEN数を取得します
 * @return QUEEN数
 */
public int getQueens()
{
	return this.NumOfQueens;
}

/**
 * GAでの個体数をセットします
 * @param num 個体数
 */
public void setIndividualNumber(int num)
{
	this.individualNumber = num;
}

/**
 * 設定されているGAでの個体数を取得します
 * @return 個体数
 */
public int getIndividualNumber()
{
	return this.individualNumber;
}

/**
 * GAの探索世代数をセットします
 * @param num 世代数
 */
public void setGeneratioinNumber(int num)
{
	this.iterationNumOfGA = num;
}

/**
 * 設定されているGAの探索世代数を取得します
 * @return 世代数
 */
public int getGenerationNumber()
{
	return this.iterationNumOfGA;
}

/**
 * <P>最大コストをセットします。</P>
 * <P>{@link OmnibusTaxi}では、{@link setMaxCost(double cost)}で設定された
 * 値から{@link CostCalculator}によって計算されるコストの総和を引いたを値を
 * GAの適応度としてして使用します。</P>
 * @param maxCost 最大コスト
 */
public void setMaxCost(double maxCost)
{
	this.bestValue = maxCost;
}

/**
 * 設定されている最大コストを取得します
 * @return 最大コスト
 */
public double getMaxCost()
{
	return this.bestValue;
}

/**
 * 遺伝的アルゴリズムによる探索を行います
 **/
void ga() //throws IllegalParameterTypeException, IllegalParameterSizeException, IllegalElementException,OutOfBoundsException
{
	gaStatus = new GeneticStatus();
	try
	{
		gaStatus.setCommand(this.command);
	}
	catch (IllegalValueException e)
	{
	}
	gaStatus.setReporter(new GeneticReportable()
	{ // 途中経過報告オブジェクト

			public void report(Individual surperior)
{
	status = SEARCHING;
	System.out.println(String.valueOf("report"));
	setBestPattern(
			DataTools.createUniqElementArray((int[])surperior.getGene().getBase()));
	owner.mapPanel.canvas.repaint();
}

public void finishReport(Individual lastSurperior, int num, long time)
{
	status = DONE_SEARCH;
	System.out.println(String.valueOf("finish report"));
	setBestPattern(
			DataTools.createUniqElementArray((int[])lastSurperior.getGene().getBase()));
	owner.mapPanel.canvas.repaint();
}
		});

NQueenModel model = new NQueenModel(getQueens());

GeneticAlgorithm _ga = new GeneticAlgorithm(model, gaStatus, getIndividualNumber());
Individual _best = (Individual)_ga.search(getGenerationNumber()); // 探索
gaStatus = null;

owner.nqueen.setSearchStatus(owner.nqueen.WAIT_FOR_SEARCH);
owner.controlPanel.searchBtn.button.setEnabled(true);
owner.controlPanel.searchBtn.button.setText("検索");

return;
	}
}
