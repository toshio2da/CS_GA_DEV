namespace GALib.Impls.Plugins;

using GALib.Core.Plugins;
using GALib.Core.Models;
using GALib.Core.Utils;

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
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public OnePointCrossover() { }

	/// <summary>
	/// 親候補集団から交叉を行い、子集団を生成します
	/// </summary>
	/// <remarks>
	/// 交叉親集団からランダムに2体を選び、その2体を元に2体の子供を生成します。<br>
	/// 子供2体の合計遺伝子は親の合計遺伝子と等しくなります。<br>
	/// つまり子供2体で親の同じ遺伝子は共有されません。<br>
	/// </remarks>
	/// <param name="perentCandidates">親候補集団。この中からランダムに親を選びます。</param>
	/// <param name="childrenNumber">生成する子集団の数。偶数でなければなりません。</param>
	/// <returns>生成された子集団</returns>
	public List<Individual> Crossover(List<Individual> perentCandidates, int childrenNumber)
	{
		//------ 必要な情報を取得 ------//
		Individual sample = perentCandidates[0];  // 個体に関する情報を得るためにサンプルとして取得
		int geneSize = sample.Gene.GenoSize;       // この集団の個体が持っている遺伝子の長さを取得

		//------------------------------------------//
		//------ 親集団と同じ数の子集団を生成 ------//
		//------------------------------------------//
		List<Individual> children = new(perentCandidates.Count);                           // 生成する子集団

		/*
		object[] sonsGene = new object[2];       // 1点交叉なので2つの部分遺伝子から作成
		object[] daughtersGene = new object[2];       // 1点交叉なので2つの部分遺伝子から作成
													  //sonsGene.setSize(2);                              // 2つの遺伝子を合成する
													  //daughtersGene.setSize(2);                         // 2つの遺伝子を合成する
		*/

		for (int childIndex = 0; childIndex < childrenNumber / 2; childIndex++)
		{
			//------ ランダムに親を2体選ぶ ------//
			Individual father = perentCandidates[(int)(RandomGenerator.Random * perentCandidates.Count)];   // 父を選ぶ
			Individual mother = perentCandidates[(int)(RandomGenerator.Random * perentCandidates.Count)];   // 母を選ぶ

			//------ 交叉点をランダムに生成 ------//
			int crossoverPoint = (int)(1 + (RandomGenerator.Random * geneSize - 2));                     // ランダムに交叉点を決定[1 - (size-1)]

			var result = DataTools.Crossover(father, mother, crossoverPoint);
			children.Add(result.son);                                                          // 息子を追加
			children.Add(result.daughter);                                                     // 娘を追加


			/*
			//------ 両親から部分遺伝子を搾取 ------//
			var fatherGenArray = father.Gene.GetBase<object>();
			var motherGenArray = mother.Gene.GetBase<object>();
			var sonsGenArray = new int[geneSize];
			var daughtersGenArray = new int[geneSize];

			int rightLength = geneSize - crossoverPoint;
			Array.Copy(fatherGenArray, 0, sonsGenArray, 0, crossoverPoint);// 息子へ父の左側の部分遺伝子
			Array.Copy(motherGenArray, crossoverPoint + 1, sonsGenArray, crossoverPoint + 1, rightLength);// 息子へ父の左側の部分遺伝子

			Array.Copy(motherGenArray, 0, daughtersGenArray, 0, crossoverPoint);// 娘へ母の左側の部分遺伝子
			Array.Copy(fatherGenArray, crossoverPoint + 1, daughtersGenArray, crossoverPoint + 1, rightLength);//娘へ父の右側の部分遺伝子



			//IGene fathersLeftGene = father.Gene.GetSubGene(0, crossoverPoint);                // 父の左側の部分遺伝子
			//IGene fathersRightGene = father.Gene.GetSubGene(crossoverPoint + 1, geneSize - 1); // 父の右側の部分遺伝子
			//IGene mothersLeftGene = mother.Gene.GetSubGene(0, crossoverPoint);                // 母の左側の部分遺伝子
			//IGene mothersRightGene = mother.Gene.GetSubGene(crossoverPoint + 1, geneSize - 1); // 母の右側の部分遺伝子


			////------ 子供に与える遺伝子を生成 ------//
			//sonsGene[0] = fathersLeftGene.GetBase();          // 息子は父の左側と母の右側を受け継ぎます
			//sonsGene[1] = mothersRightGene.GetBase();         //
			//daughtersGene[0] = mothersLeftGene.GetBase();     // 娘は母の左側と父の右側を受け継ぎます
			//daughtersGene[1] = fathersRightGene.GetBase();    //


			//------ 子供を2体生成 ------//
			//Individual son = (Individual)constructorInfo.Invoke(argment);// 親と同じクラス（派生クラス）で子供を生成
			//Individual daughter = (Individual)constructorInfo.Invoke(argment);  // メタクラスによる動的生成を使用。
			Individual son = new Individual(ga.GAModel.IndividualModel);// 親と同じクラス（派生クラス）で子供を生成
			Individual daughter = new Individual(ga.GAModel.IndividualModel);  // メタクラスによる動的生成を使用。

			son.Gene.CreateGene(sonsGene);                                         // 新しく生成された遺伝子を子供に設定
			daughter.Gene.CreateGene(daughtersGene);                               // 新しく生成された遺伝子を子供に設定


			//------ 生成した子供を次世代の集団に追加 ------//
			children.Add(son);                                                          // 息子を追加
			children.Add(daughter);                                                     // 娘を追加
			*/
		}


		//------ 生成した次世代の子集団を返す ------//
		return children;                                                                // 次世代候補

	}
}
