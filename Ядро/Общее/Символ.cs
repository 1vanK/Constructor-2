/*
	������� ������
*/


struct ������
{
	public char ��������;
	public byte ����;

	public ������(char ��������)
	{
		�������� = ��������;
		���� = 0x07;
	}

	public ������(char ��������, byte ����)
	{
		�������� = ��������;
		���� = ����;
	}

	public ������(char ��������, byte ������������������, byte ��������)
	{
		�������� = ��������;
		������������������ = (byte)(������������������ & 0x0F);
		�������� = (byte)(�������� << 4);
		���� = (byte)(������������������ | ��������);
	}

	public byte ��������
	{
		get
		{
			return (byte)(���� >> 4);
		}
	}

	public byte ������������������
	{
		get
		{
			return (byte)(���� & 0x0F);
		}
	}

	public override string ToString()
	{
		return ��������.ToString();
	}
}
