namespace jp.co.tmdgroup.common.geneticalgorithm;

using jp.co.tmdgroup.common.geneticalgorithm.exception;

/**
 * <p>個体の持つ遺伝子情報を持つクラスのインタフェースです。</p>
 * 遺伝子は様々な塩基タイプを持っており、それらの共通インタフェースとして本インタフェースを使用します。<br>
 * 個体は遺伝子とその適応度を持ちます。個体の持つ遺伝子情報クラスは必ず本インタフェースを実装する必要があります。
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/16)
 */
public interface IGene {


    /**
     * <p>自己遺伝子の遺伝子長を返します。</p>
     *
     * @return 自己遺伝子の遺伝子長です。
     */
    int  getGenoSize();



    /**
     * <p>遺伝子の塩基配列を返します。</p>
     * この塩基配列を使って適応度の算出などを行います。<br>
     *
     * @return 遺伝子配列
     */
    object  getBase();




    /**
     * <p>遺伝子断片から個体の遺伝子を生成します。</p>
     * 渡された遺伝子断片をつなぎ合わせ、生成された遺伝子を自分の遺伝子として保持します。<br>
     * 遺伝子断片の塩基タイプは遺伝子クラスの塩基タイプと一致している必要があります。<br>
     * 遺伝子断片はVectorの順番通りに融合されます。<br>
     *
     * @param piecesOfGene  融合する遺伝子断片、塩基タイプは一致していなければないけません
     * @throws IllegalGenoSizeException  遺伝子断片の合計遺伝子長が本遺伝子の遺伝子長と一致しません(遺伝子不足又は過多)
     * @throws IllegalGenoTypeException  遺伝子断片の塩基タイプが本遺伝子の塩基タイプと一致しません
     */
    void createGene(object[] piecesOfGene); //throws IllegalGenoSizeException, IllegalGenoTypeException;



    /**
     * <p>自己遺伝子の部分遺伝子断片を返します</p>
     * 部分遺伝子を返すことで交叉を行うことができます。<br>
     * 部分遺伝子は初端と終端を指定することで抜き出します。<br>
     * 初端と終端の遺伝子も返される部分遺伝子断片に含まれます。<br>
     * 例えば、getSubGene(0, 5) とした場合の返される遺伝子断片の長さは6となります。<br>
     * getSubGene(1,1)とすることで1塩基を抜き出すこともできます。<br>
     *
     * @param firstGenoIndex  抜き出す遺伝子断片の初端を指定します
     * @param lastGenoIndex  抜き出す遺伝子断片の終端を指定します
     * @return  抜き出された部分遺伝子断片です
     * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
     */
    IGene  getSubGene(int firstGenoIndex, int lastGenoIndex) ; //throws OutOfBoundsGeneException;



    /**
     * <p>自己遺伝子を全てランダムなもので再構築します。</p>
     * 個体遺伝子の初期化などに用いられます。<br>
     */
    void randumReconstruct();



     /**
     * <p>1塩基に対して突然変異を起こします。</p>
     * 自己遺伝子内の指定塩基に対して突然変位を行います。<br>
     * 突然変位は遺伝子の塩基タイプによって異なります。<br>
     *
     * @param genoIndex  突然変異を起こさせる塩基の場所を指定します(0\uFF5E)
     * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
     */
    void  mutateOneGene(int genoIndex) ; //throws OutOfBoundsGeneException;




   /**
     * <p>指定した場所の遺伝子に逆位を行います。</p>
     * 逆位とは指定した場所の遺伝子の順番を反転させる操作を指します。<br>
     * あまり一般的に用いられるGAオペレーションではありません。
     *
     * @param firstGenoIndex  抜き出す遺伝子断片の初端を指定します
     * @param lastGenoIndex  抜き出す遺伝子断片の終端を指定します
     * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
     */
    void InverseSubGene(int firstGenoIndex, int lastGenoIndex) ; //throws OutOfBoundsGeneException;
}
