namespace jp.co.tmdgroup.common.geneticalgorithm;


using jp.co.tmdgroup.common.geneticalgorithm.model;

using System.Reflection;
/**
 * <p>1点交叉による交叉を行います。</p>
 * 1点交叉は交叉法の中で最も一般的なものとして知られています。<br>
 * 1点で2体の親の遺伝子を分断し、互い違いにつなぎ合わせた2本の遺伝子で2体の子供を生成します。<br>
 * 交叉点はランダムに選ばれます。<br>
 * <br>
 * 本クラスでは新しく生成される子供が親集団のクラスと全く同じクラスのインスタンスであることが保証されます。<br>
 * つまり、Individualクラスでなく、派生クラスであってもその派生クラスの構築子を動的に判断し、呼び出します。<br>
 * 同時に使用している個体モデルクラスも判定し、使用します。<br>
 * そのため、セキュリティポリシーの関係上、アプレットでは本クラスを使用できない可能性があります。<br>
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

public class OnePointCrossover : ICrossoverAlgorithm
{


	//================================================//
	//-------------------- 構築子 --------------------//
	//================================================//

	/**
     * <p>構築子です。</p>
     */
	public OnePointCrossover()
	{
	}




	//======================================================================//
	//-------------------- インタフェースメソッドの実装 --------------------//
	//======================================================================//


	/**
     * <p>親候補集団から交叉を行い、子集団を生成します。</p>
     * 交叉親集団からランダムに2体を選び、その2体を元に2体の子供を生成します。<br>
     * 子供2体の合計遺伝子は親の合計遺伝子と等しくなります。<br>
     * つまり子供2体で親の同じ遺伝子は共有されません。<br>
     * 交叉点はランダムに選ばれた1点です。基本的な遺伝的アルゴリズムによく用いられます。<br>
     * <br>
     * 本メソッドでは親と同じクラスの個体を子供として生成します。<br>
     * これは親がIndividualの派生クラスであればどのクラスでもいいことを示します。<br>
     * メタクラスClass及びConstructorを使用しています。<br>
     * 内部でインスタンスの動的生成を行っているため、セキュリティポリシーの関係上、アプレットでは使用できない可能性があります。<br>
     * 個体のモデルクラスも同様に親から引き継がれます。<br>
     *
     * @param perentCandidates 親候補集団。この中からランダムに親を選びます。
     * @param childrenNumber 生成する子集団の数。偶数でなければなりません。
     * @return 生成された子集団
     * @throws IllegalIndividualException perentCandidatesの中にindividualクラスでないオブジェクトが入っています
     */
	public List<Individual> Crossover(List<Individual> perentCandidates, int childrenNumber)
	{
		try
		{
			//------ 必要な情報を取得 ------//
			Individual sample = perentCandidates[0];  // 個体に関する情報を得るためにサンプルとして取得
			int geneSize = sample.Gene.GetGenoSize();       // この集団の個体が持っている遺伝子の長さを取得
			IIndividual ourModel = sample.IndividualModel;          // 個体のモデルクラスを取得

			//Class individualClass = sample.getClass();                    // メタクラスを取得
			//Class individualModelClass = Class.forName("jp.co.tmdgroup.common.geneticalgorithm.model.IIndividual");
			//Class[] argmentModel = { individualModelClass };                      // メタクラスに呼ぶコンストラクタの引数定義(個体の生成構築子)
			//Constructor constructor = individualClass.getConstructor(argmentModel); // メタコンストラクタ。クラス名から動的に個体を生成。

			object[] argment = [ourModel];                                   // 引数。個体のモデルクラス。

            //T.Tsuda
            //コンストラクタメタ情報を取得
            //ConstructorInfo? constructorInfo = typeof(Individual).GetType().GetConstructor([typeof(IIndividual)]);
            //if (constructorInfo == null)
            //{
            //	throw new ArgumentException("指定されたタイプにIIndividualをを引数としたコンストラクタが存在しません");
            //}

            //------------------------------------------//
            //------ 親集団と同じ数の子集団を生成 ------//
            //------------------------------------------//
            List<Individual> children = new(perentCandidates.Count);                           // 生成する子集団
			object[] sonsGene = new object[2];       // 1点交叉なので2つの部分遺伝子から作成
			object[] daughtersGene = new object[2];       // 1点交叉なので2つの部分遺伝子から作成
														  //sonsGene.setSize(2);                              // 2つの遺伝子を合成する
														  //daughtersGene.setSize(2);                         // 2つの遺伝子を合成する


			for (int childIndex = 0; childIndex < childrenNumber / 2; childIndex++)
			{

				//------ ランダムに親を2体選ぶ ------//
				Individual father = perentCandidates[(int)(GARandomGenerator.Random * perentCandidates.Count)];   // 父を選ぶ
				Individual mother = perentCandidates[(int)(GARandomGenerator.Random * perentCandidates.Count)];   // 母を選ぶ


				//------ 交叉点をランダムに生成 ------//
				int crossoverPoint = (int)(1 + (GARandomGenerator.Random * geneSize - 2));                     // ランダムに交叉点を決定[1 - (size-1)]

				//------ 両親から部分遺伝子を搾取 ------//
				IGene fathersLeftGene = father.Gene.GetSubGene(0, crossoverPoint);                // 父の左側の部分遺伝子
				IGene fathersRightGene = father.Gene.GetSubGene(crossoverPoint + 1, geneSize - 1); // 父の右側の部分遺伝子
				IGene mothersLeftGene = mother.Gene.GetSubGene(0, crossoverPoint);                // 母の左側の部分遺伝子
				IGene mothersRightGene = mother.Gene.GetSubGene(crossoverPoint + 1, geneSize - 1); // 母の右側の部分遺伝子


				//------ 子供に与える遺伝子を生成 ------//
				//sonsGene.setElementAt(fathersLeftGene.getBase(), 0);          // 息子は父の左側と母の右側を受け継ぎます
				//sonsGene.setElementAt(mothersRightGene.getBase(), 1);         //
				//daughtersGene.setElementAt(mothersLeftGene.getBase(), 0);     // 娘は母の左側と父の右側を受け継ぎます
				//daughtersGene.setElementAt(fathersRightGene.getBase(), 1);    //

				sonsGene[0] = fathersLeftGene.GetBase();          // 息子は父の左側と母の右側を受け継ぎます
				sonsGene[1] = mothersRightGene.GetBase();         //
				daughtersGene[0] = mothersLeftGene.GetBase();     // 娘は母の左側と父の右側を受け継ぎます
				daughtersGene[1] = fathersRightGene.GetBase();    //


                //------ 子供を2体生成 ------//
                //Individual son = (Individual)constructorInfo.Invoke(argment);// 親と同じクラス（派生クラス）で子供を生成
                //Individual daughter = (Individual)constructorInfo.Invoke(argment);  // メタクラスによる動的生成を使用。
                //son.				Gene.CreateGene(sonsGene);                                         // 新しく生成された遺伝子を子供に設定
                //daughter.				Gene.CreateGene(daughtersGene);                               // 新しく生成された遺伝子を子供に設定

                // とりあえず　LimitedNumberIndividualModel を使う
                // 本当は、引数の型から LimitedNumberIndividualModel または NumberIndividualModel を取得しなければならない。
                Individual son = (Individual)(new LimitedNumberIndividualModel(geneSize, childrenNumber)).CreateNewGene().GetBase();
                Individual daughter = (Individual)(new LimitedNumberIndividualModel(geneSize, childrenNumber)).CreateNewGene().GetBase();

                //------ 生成した子供を次世代の集団に追加 ------//
                children.Add(son);                                                          // 息子を追加
				children.Add(daughter);                                                     // 娘を追加
			}


			//------ 生成した次世代の子集団を返す ------//
			return children;                                                                // 次世代候補

		}

		catch (Exception exception)
		{
			Console.WriteLine(exception.StackTrace);
			return [];//null;
		}
		/*
		catch (OutOfBoundsGeneException exception) {

            //------ サイズをチェックしてから読んでいるのでこれが呼ばれることはない ------//
            Console.WriteLine(exception.StackTrace);
        }
        catch (MissingMethodException exception) {

            //------ モデルクラスを引数をするコンストラクタが個体を生成するクラスに見つかりません ------//
            Console.WriteLine(exception.StackTrace);
        }
        catch (InvocationTargetException exception) {

            Console.WriteLine(exception.StackTrace);
        }
        catch (IllegalAccessException exception) {

            Console.WriteLine(exception.StackTrace);
        }
        catch (InstantiationException exception) {

            Console.WriteLine(exception.StackTrace);
        }
        catch (IllegalGenoSizeException exception) {

            Console.WriteLine(exception.StackTrace);
        }
        catch (IllegalGenoTypeException exception) {

            Console.WriteLine(exception.StackTrace);
        }
        catch (ClassNotFoundException exception) {

            Console.WriteLine(exception.StackTrace);
        }
        */
	}
}
