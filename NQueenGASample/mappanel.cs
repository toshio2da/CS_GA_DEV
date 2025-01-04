namespace jp.co.tmdgroup.nqueengasample;

using java.util;

using java.awt;
using javax.swing;

/**
 * N-Queen Probrem の結果を表示するマップオブジェクト
 *
 * @author Hiroshi Morimoto
 * @version 1.0
 */
public class MapPanel {

	/**
	 * 盤を描画する色
	 **/
	static final Color LINE_COLOR = Color.BLACK;

	static final Color BK_COLOR = Color.WHITE;

	MainForm owner;

	/**
	 * 結果を描画する対象オブジェクト
	 **/
	MapCanvas  canvas;

	MapPanel(MainForm o) {
		this.owner = o;
		canvas = new MapCanvas();
	}

	Container makeContents(){
		JPanel _base = new JPanel(new BorderLayout());
		_base.add(canvas,BorderLayout.CENTER);
		_base.setBackground(BK_COLOR);

		return _base;
	}

	/**
	 * 描画領域の幅
	 **/
	public int getCanvasWidth() {
		return canvas.getWidth();
	}

	/**
	 * 描画領域の高さ
	 **/
	public int getCanvasHeight() {
		return canvas.getHeight();
	}

	/**
	 * 描画オブジェクト
	 **/
	class MapCanvas extends JComponent {

		/**
		 * 探索状況を描画します
		 * @see java.awt.Component#paint(Graphics)
		 */
		public void paint(Graphics g) {
			Color _orig = g.getColor();
                        System.out.println("MapCanvas paint");

			drawQueens(g);          // QUEENの描画

			drawCost();

			g.setColor(_orig);
		}

                public void drawQueens(Graphics g) {
                  int w = canvas.getWidth();
                  int h = canvas.getHeight();
                  int cnt = owner.nqueen.getQueens();
                  int i;
                  int x, y, xs, ys, xe, ye;
                  double dx,dy;
                  int[] pat = owner.nqueen.getBestPattern();

                  xs = (int)(0.1 * w);
                  ys = xs;
                  dx = 0.8 * w  / cnt;
                  dy = dx;
                  xe = (int)(xs + dx * cnt);
                  ye = xe;

                  //横のライン
                  y = ys;
                  for (i=0; i<=cnt; ++i) {
                    y = (int)(ys + dy * i);
                    g.drawLine(xs, y, xe, y);
                  }

                  //縦のライン
                  x = xs;
                  for (i=0; i<=cnt; ++i) {
                    x = (int)(xs + dx * i);
                    g.drawLine(x, ys, x, ye);
                  }

                  if (pat[0] > -1) {
                    for (i=0; i<cnt; ++i) {
                      y = (int)(ys + dy * i);
                      x = (int)(xs + dx * pat[i]);
                      g.drawLine(x,y,(int)(x+dx),(int)(y+dy)) ;
                      g.drawLine(x,(int)(y+dy),(int)(x+dx),y) ;
                    }
                  }
                }

                public void drawCost() {
                  try {
                    owner.controlPanel.cost.setIntValue((int)owner.nqueen.gaStatus.getBestIndividual().getFitnessValue());
                  } catch (Exception e){
                  }
                }
	}
}
