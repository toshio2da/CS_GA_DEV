namespace jp.co.tmdgroup.nqueengasample;

using java.awt;
using java.awt.event;


using javax.swing;
using javax.swing.border;
using jp.co.tmdgroup.common.interfaces.exception;
using jp.co.tmdgroup.common.tmdtools.exception;

/**
 * N-QUEEN Probrem で設定を行うパネル
 *
 * @author  Hiroshi Morimoto
 * @version 1.0
 */
public class ControlPanel {
	/**
	 * ControlPanelを所有するフォーム
	 **/
	MainForm   owner;

	/**
	 * 入力フィールド : number of Queen
	 **/
	InputIntegerField queenSize = new InputIntegerField("QUEEN の数",10);

	/**
	 * 世代数の入力フィールド
	 **/
	InputIntegerField generationSize = new InputIntegerField("世代数",500);

	/**
	 * 個体数の入力フィールド
	 **/
	InputIntegerField individualsSize = new InputIntegerField("個体数",100);

	/**
	 * 突然変異発生確率
	 **/
	InputDoubleField  mutationProbability = new InputDoubleField("突然変異発生確率",0.05);

	/**
	 * 探索開始ボタン
	 **/
	ActionButton      searchBtn     = new ActionButton("検索") {           // クリックされたらstartSearch()を呼ぶ
		                                  public void actionPerformed(ActionEvent e){
		                                  	  this.button.setEnabled(false);
		                                  	  this.button.setText("検索中");
		                                  	  startSearch();}
	};

	/**
	 * コストフィールド
	 **/
	InputIntegerField cost = new InputIntegerField("コスト",0);

	/**
	 * コンストラクタ
	 * @param o 問題領域のモデル
	 **/
	ControlPanel(MainForm f){
		owner = f;
	}

	/**
	 * ウィンドウのコンテンツの配置
	 **/
	Container makeContents() {

		Box _box = Box.createVerticalBox();
		_box.add(Box.createHorizontalStrut(100));           // 幅は100pixel
		queenSize.makeContents(_box);                       // QUEEN数の入力フィールド
		generationSize.makeContents(_box);                  // 世代数の入力フィールド
		individualsSize.makeContents(_box);                 // 個体数の入力フィールド
		mutationProbability.makeContents(_box);             // 突然変異発生確率入力フィールド

		_box.add(Box.createVerticalStrut(20));              // 20pixelのスペースを挿入

		searchBtn.makeContents(_box,ActionButton.CENTER);   // 探索開始ボタンの配置

		_box.add(Box.createVerticalStrut(20));              // 20pixelのスペースを挿入

		cost.makeContents(_box);

		JPanel _basePanel = new JPanel(new BorderLayout());
		_basePanel.add(_box,BorderLayout.NORTH);

		return _basePanel;
	}

	/**
	 * 探索の開始
	 **/
	public void startSearch() {
          owner.nqueen.setQueens(queenSize.getIntValue());
	  owner.nqueen.setGeneratioinNumber(generationSize.getIntValue());  // 世代数のセット
	  owner.nqueen.setIndividualNumber(individualsSize.getIntValue()); // 個体数のセット

	  owner.nqueen.start();
	}

        public void setEnable() {
          this.searchBtn.button.setEnabled(true);
      	  this.searchBtn.button.setText("検索");
        }
}

/**
 * テキスト入力フィールドのオブジェクトです
 **/
class InputTextField {
	/**
	 * タイトル
	 **/
	JLabel      caption;

	/**
	 * テキスト入力フィールド
	 **/
	JTextField  field;

	/**
	 * コンストラクタ
	 * @param cap タイトル
	 **/
	public InputTextField(String cap){
		caption = new JLabel(cap);
		field   = new JTextField();
	}

	/**
	 * コンストラクタ
	 * @param cap    タイトル
	 * @param defVal デフォルト文字列
	 **/
	public InputTextField(String cap, String defVal){
		caption = new JLabel(cap);
		field   = new JTextField(defVal);
	}

	/**
	 * VirticalBox上にコンテンツを配置します。
	 * @param  box コンテンツを配置するボックスオブジェクト
	 * @return コンテンツを配置したboxオブジェクト
	 **/
	public Box makeContents(Box box){
		Box _captionBox = Box.createHorizontalBox();   // キャプション配置用のHBox（左よせるため）
		_captionBox.add(caption);                      // キャプションの配置
		_captionBox.add(Box.createHorizontalGlue());   // 右側をGlueでうめる

		box.add(_captionBox);
		box.add(field);                                // テキストフィールドの配置

		return box;
	}

	/**
	 * テキストフィールドの値を取得します
	 * @return フィールド値
	 **/
	public String getTextValue() {
		return field.getText();
	}

	/**
	 * テキストフィールドの値をセットします
	 * @param val フィールド値
	 **/
	public void setTextValue(String val){
		field.setText(val);
	}
}

/**
 * 数値入力用フィールドオブジェクト<BR>
 * 整数のみを入力できます。それ以外の文字が入力された場合、値を読み込む際に直前の数値にリセットします。
 **/
class InputIntegerField extends InputTextField {
	/**
	 * 最後に読み込んだ数値
	 **/
	int lastValue = 0;

	/**
	 * コンストラクタ
	 * @param cap タイトル
	 **/
	public InputIntegerField(String cap){
		super(cap,"0");
		field.setHorizontalAlignment(JTextField.RIGHT);
	}

	/**
	 * コンストラクタ
	 * @param cap    タイトル
	 * @param defVal デフォルト値
	 **/
	public InputIntegerField(String cap, int defVal){
		super(cap,Integer.toString(defVal));
		lastValue = defVal;
		field.setHorizontalAlignment(JTextField.RIGHT);
	}

	/**
	 * フィールドに入力された整数値を読み込みます。
	 * もし、整数以外の値が入力されていれば、最後に入力された整数値に
	 * リセットされます。
	 * @return フィールドの値
	 **/
	public int getIntValue() {
		try{
			lastValue = Integer.parseInt(getTextValue());
			return lastValue;
		}
		catch(NumberFormatException e){
			setIntValue(lastValue);
			return lastValue;
		}
	}

	/**
	 * フィールドの値をセットします。
	 * @param val フィールド値
	 **/
	public void setIntValue(int val){
		lastValue = val;
		setTextValue(Integer.toString(val));
	}
}

/**
 * 数値入力用フィールドオブジェクト<BR>
 * 実数を入力できます。それ以外の文字が入力された場合、値を読み込む際に直前の数値にリセットします。
 **/
class InputDoubleField extends InputTextField {
	/**
	 * 最後に読み込んだ数値
	 **/
	double lastValue = 0.0;

	/**
	 * コンストラクタ
	 * @param cap タイトル
	 **/
	public InputDoubleField(String cap){
		super(cap,"0");
		field.setHorizontalAlignment(JTextField.RIGHT);
	}

	/**
	 * コンストラクタ
	 * @param cap    タイトル
	 * @param defVal デフォルト値
	 **/
	public InputDoubleField(String cap, double defVal){
		super(cap,Double.toString(defVal));
		lastValue = defVal;
		field.setHorizontalAlignment(JTextField.RIGHT);
	}

	/**
	 * フィールドに入力された整数値を読み込みます。
	 * もし、実数以外の値が入力されていれば、最後に入力された実数値に
	 * リセットされます。
	 * @return フィールドの値
	 **/
	public double getDoubleValue() {
		try{
			lastValue = Double.parseDouble(getTextValue());
			return lastValue;
		}
		catch(NumberFormatException e){
			setDoubleValue(lastValue);
			return lastValue;
		}
	}

	/**
	 * フィールドの値をセットします。
	 * @param val フィールド値
	 **/
	public void setDoubleValue(double val){
		lastValue = val;
		setTextValue(Double.toString(val));
	}
}


/**
 * クリックされると何らかのイベントを行うボタンです。
 * {@link #actionPerformed(ActionEvent e)}に、クリックされたときの処理を
 * 記述します。
 **/
class ActionButton implements ActionListener {
	/**
	 * ボタンを左によせて配置します。
	 **/
	static final int LEFT   = 0;

	/**
	 * ボタンを中央に配置します。
	 **/
	static final int CENTER = 1;

	/**
	 * ボタンを右によせて配置します。
	 **/
	static final int RIGHT  = 2;

	/**
	 * ボタンオブジェクト
	 **/
	JButton button;

	/**
	 * コンストラクタ
	 * @param cap タイトル
	 **/
	public ActionButton(String cap){
		button = new JButton(cap);
		button.addActionListener(this);
	}

	/**
	 * ボタンをVBoxに配置します。
	 * @param box   ボタンを配置するBoxオブジェクト
	 * @param align ボタンの配置位置({@link #LEFT},{@link #CENTER},{@link #RIGHT})
	 **/
	public Box makeContents(Box box, int align){
		Box _buttonBox = Box.createHorizontalBox();       // ボタンを配置するHBoxオブジェクト
		switch(align){
		case LEFT:                                        // 左に寄せる
			_buttonBox.add(button);
			_buttonBox.add(Box.createHorizontalGlue());
			break;
		case CENTER:                                      // 中央に配置
			_buttonBox.add(Box.createHorizontalGlue());
			_buttonBox.add(button);
			_buttonBox.add(Box.createHorizontalGlue());
			break;
		case RIGHT:                                        // 右に寄せる
			_buttonBox.add(Box.createHorizontalGlue());
			_buttonBox.add(button);
			break;
		}

		box.add(_buttonBox);
		return box;
	}

	/**
	 * ボタンオブジェクトを取得します。
	 **/
	public JButton getComponent() {
		return button;
	}

	/**
	 * ボタンがクリックされたときの処理を記述します。
	 **/
	public void actionPerformed(ActionEvent e){

	}
}
