	# �X�N���v�g�t�@�C���̃p�����[�^��錾�i�擪����u�ϊ��Ώۂ̃t�H���_�v
	# �u�ϊ���̃t�@�C���̕ۑ���v�u�ϊ��O�̕����R�[�h�v�u�ϊ���̕����R�[�h�v�j
param(
  [String]$in = "E:\SSC_DEV\CS_GA_DEV\GeneticAlgorithm_ShiftJis",
  [String]$out = "E:\SSC_DEV\CS_GA_DEV\GeneticAlgorithm",
  [String]$from = "Shift-JIS",
  [String]$to = "UTF-8"
)

	# ����$from�A$to����A�����R�[�h��\��Encoding�I�u�W�F�N�g�𐶐�
$enc_f = [Text.Encoding]::GetEncoding($from)
$enc_t = [Text.Encoding]::GetEncoding($to)
	# �^����ꂽ�p�X�ic:\tmp\convert�j���獇�v����t�@�C�����X�g���ċA�I�Ɏ擾
  Get-ChildItem $in -recurse |
	# �擾�����t�@�C�������Ԃɏ���
	ForEach-Object {
	# �擾�����I�u�W�F�N�g���t�@�C���̏ꍇ�̂ݏ����i�t�H���_�̏ꍇ�̓X�L�b�v�j
	  if($_.GetType().Name -eq "FileInfo"){
	# �ϊ����t�@�C����StreamReader�I�u�W�F�N�g�œǂݍ���
		$reader = New-Object IO.StreamReader($_.FullName, $enc_f)
	# �ۑ���̃p�X�A�ۑ���̐e�t�H���_�̃p�X�𐶐�
		$o_path = $_.FullName.ToLower().Replace($in.ToLower(), $out)
		$o_folder = Split-Path $o_path -parent
	# �ۑ���̃t�H���_�����݂��Ȃ��ꍇ�Ƀt�H���_����������
		if(!(Test-Path $o_folder)){
		  [Void][IO.Directory]::CreateDirectory($o_folder)
		}
	# �ۑ���t�@�C����StreamWriter�I�u�W�F�N�g�ŃI�[�v��
		$writer = New-Object IO.StreamWriter($o_path, $false, $enc_t)
	# �ϊ����t�@�C�������ɓǂݍ��݁A�ۑ���t�@�C���ɏ�������
		while(!$reader.EndOfStream){$writer.WriteLine($reader.ReadLine())}
	# �t�@�C�������ׂăN���[�Y
		$reader.Close()
		$writer.Close()
	  }
	}