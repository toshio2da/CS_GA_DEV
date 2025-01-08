using GALib.Core.Models;
using GALib.Core.Plugins;
using GALib.Core.Utils;

namespace jp.co.tmdgroup.nqueengasample
{
	/**
	 * <p>N-Queen問題において各個体の適応度を算出します。</p>
	 * N-Queen問題では各クイーンがお互いに取れない様に配置されていなければなりません。<br>
	 * 本N-Queen問題では適応度をInteger.MAX_VALUEからの減点方式で算出します。<br>
	 * つまり、Integer.MAX_VALUEが最高適応度となります。<br>
	 * 互いに取れるクイーンが配置されると100減点されます。<br>
	 * <br>
	 * <br>
	 * <br>
	 * <p>タイトル: Genetic Algorithm Library</p>
	 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	 * <p>著作権: Copyright (c) 2001  森本寛</p>
	 * <p>会社名: 株式会社東京マイクロデータ</p>
	 * @author 森本寛
	 * @version 1.0
	 */
	public class NQueenFitnessAlgorithm : IFitnessAlgorithm
	{

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public NQueenFitnessAlgorithm() { }

		/// <summary>
		/// N-Queen問題における個体の適応度の計算を行います。
		/// </summary>
		/// <remarks>
		/// N-Queen問題では各クイーンがお互いに取れない様に配置されていなければなりません。<br>
		/// 本N-Queen問題では適応度をInteger.MAX_VALUEからの減点方式で算出します。<br>
		/// つまり、Integer.MAX_VALUEが最高適応度となります。<br>
		/// 互いに取れるクイーンが配置されると100減点されます。<br>
		/// 適応度は本メソッドに返されると同時に渡された個体に保持されます。<br>
		/// </remarks>
		/// <param name="individual">適応度を算出する個体</param>
		/// <returns>算出された適応度</returns>
		public double GetFitnessValue(Individual individual)
		{

			//------ 遺伝子情報の組み替え。致死遺伝子の削除 ------//
			int[] gene = DataTools.CreateUniqElementArray(individual.Gene.GetBase<int>());
			//int[] gene = (int[])individual.Gene.GetBase();
			int fitnessValue = (int)this.BestFitnessValue;              // 適応度を保持


			//------ 各塩基を順に調査 ------//
			for (int index = 0; index < gene.Length; index++)
			{

				//------調査(自分と同じ番号が他にあるか) ------//
				int myValue = gene[index];
				for (int baseIndex = 0; baseIndex < gene.Length; baseIndex++)
				{

					//------ 縦を調査(自分と違う塩基が自分と同じ値を持っていると縦が重なっている ------//
					//CreateUniqElementArrayで致死遺伝子（縦が重なるパターン）を削除しているので以下のチェ㏍は不要
					//if (index != baseIndex && myValue == gene[baseIndex])
					//{
					//	fitnessValue -= 50;
					//}

					//------ 斜めを調査(自分との位置の差と値の差が同じ場合は斜めで重なっている ------//
					if (index != baseIndex && Math.Abs(index - baseIndex) == Math.Abs(myValue - gene[baseIndex]))
					{

						fitnessValue -= 50;
					}
				}
			}


			//------ 算出した適応度を個体に保持させ、返す ------//
			individual.FitnessValue = fitnessValue;                               // 個体に適応度を保持させる
			return fitnessValue;                                                    // 算出した適応度を返す
		}

		/// <summary>
		/// N-Queen問題における個体の最大適応度(究極の個体)を返します。
		/// </summary>
		/// <remarks>
		/// 本問題ではInteger.MAX_VALUEからの減点方式を採用しています。<br>
		/// よってInteger.MAX_VALUEが最大適応度として返されます。<br>
		/// </remarks>
		/// <returns>N-Queen問題における個体の最大適応度</returns>
		public double BestFitnessValue => (double)1000000;
	}
}