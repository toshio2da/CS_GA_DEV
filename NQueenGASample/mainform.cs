namespace jp.co.tmdgroup.nqueengasample;

using java.awt;

using javax.swing;
using java.awt.event;

/**
 * N-QUEEN Probrem メインフォームオブジェクト
 *
 * @author Hiroshi Morimoto
 * @version 1.0
 */
public class MainForm extends JFrame {

	ControlPanel controlPanel;
	MapPanel     mapPanel;
        NQueen       nqueen;

	public MainForm() {
		controlPanel = new ControlPanel(this);
		mapPanel     = new MapPanel(this);
                nqueen       = new NQueen(this);
	}

	public void makeContents() {
		this.setSize(800,800);

		Container _container = this.getContentPane();
		_container.add(controlPanel.makeContents(),BorderLayout.WEST);
		_container.add(mapPanel.makeContents(),BorderLayout.CENTER);

		this.addWindowListener(
				new WindowAdapter(){
		        	public void windowClosing(WindowEvent e){
		            	System.exit(0);
		        	}
		        }
		);
	}

	public static void main(String[] args){
		MainForm _form = new MainForm();
		_form.makeContents();
		_form.show();
	}
}
