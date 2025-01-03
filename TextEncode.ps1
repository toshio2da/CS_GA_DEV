	# スクリプトファイルのパラメータを宣言（先頭から「変換対象のフォルダ」
	# 「変換後のファイルの保存先」「変換前の文字コード」「変換後の文字コード」）
param(
  [String]$in = "E:\SSC_DEV\CS_GA_DEV\GeneticAlgorithm_ShiftJis",
  [String]$out = "E:\SSC_DEV\CS_GA_DEV\GeneticAlgorithm",
  [String]$from = "Shift-JIS",
  [String]$to = "UTF-8"
)

	# 引数$from、$toから、文字コードを表すEncodingオブジェクトを生成
$enc_f = [Text.Encoding]::GetEncoding($from)
$enc_t = [Text.Encoding]::GetEncoding($to)
	# 与えられたパス（c:\tmp\convert）から合致するファイルリストを再帰的に取得
  Get-ChildItem $in -recurse |
	# 取得したファイルを順番に処理
	ForEach-Object {
	# 取得したオブジェクトがファイルの場合のみ処理（フォルダの場合はスキップ）
	  if($_.GetType().Name -eq "FileInfo"){
	# 変換元ファイルをStreamReaderオブジェクトで読み込み
		$reader = New-Object IO.StreamReader($_.FullName, $enc_f)
	# 保存先のパス、保存先の親フォルダのパスを生成
		$o_path = $_.FullName.ToLower().Replace($in.ToLower(), $out)
		$o_folder = Split-Path $o_path -parent
	# 保存先のフォルダが存在しない場合にフォルダを自動生成
		if(!(Test-Path $o_folder)){
		  [Void][IO.Directory]::CreateDirectory($o_folder)
		}
	# 保存先ファイルをStreamWriterオブジェクトでオープン
		$writer = New-Object IO.StreamWriter($o_path, $false, $enc_t)
	# 変換元ファイルを順に読み込み、保存先ファイルに書き込み
		while(!$reader.EndOfStream){$writer.WriteLine($reader.ReadLine())}
	# ファイルをすべてクローズ
		$reader.Close()
		$writer.Close()
	  }
	}