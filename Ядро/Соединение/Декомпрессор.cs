/*
	�����, ����������� ��������� MCCP ����� ������
*/


using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip.Compression;


class ������������
{
	const byte mccp_Compress  = 85;
	const byte mccp_Compress2 = 86;

	const int ���������_�������           = 0;
	const int ���������_Iac               = 1;
	const int ���������_IacWill           = 2;
	const int ���������_IacSb             = 3;
	const int ���������_IacSbCompress     = 4;
	const int ���������_IacSbCompressWill = 5;
	const int ���������_IacSbCompress2    = 6;
	const int ���������_IacSbCompress2Iac = 7;

	Inflater inflater = null;
	int ������Mccp = 0;
	int ��������� = ���������_�������;
	List<byte> ������������������ = new List<byte>(8);

	public byte[] �����������(byte[] �����, int �����, out byte[] ������������)
	{
		byte[] ����� = new byte[����� * 16];
		int �������� = 0;
		List<byte> ��������� = new List<byte>(�����.Length);
		List<byte> ����� = new List<byte>(8);
	������:
		if (inflater != null)
		{
			inflater.SetInput(�����, ��������, ����� - ��������);
			while (true)
			{
				int ��������� = inflater.Inflate(�����);
				if (��������� > 0)
				{
					for (int i = 0; i < ���������; i++)
						���������.Add(�����[i]);
					continue;
				}
				if (inflater.IsFinished)
				{
					�������� = ����� - inflater.RemainingInput;
					inflater = null;
					������Mccp = 0;
					goto ������;
				}
				break;
			}
		}
		else
		{
			while (�������� < �����)
			{
				byte ���� = �����[��������];
				������������������.Add(����);
				��������++;
				if (��������� == ���������_������� && ���� == Telnet.Iac)
				{
					��������� = ���������_Iac;
					continue;
				}
				if (��������� == ���������_Iac && ���� == Telnet.Will)
				{
					��������� = ���������_IacWill;
					continue;
				}
				if (��������� == ���������_IacWill && ���� == mccp_Compress)
				{
					��������� = ���������_�������;
					������������������ = new List<byte>(8);
					�����.Add(Telnet.Iac);
					�����.Add(Telnet.Do);
					�����.Add(mccp_Compress);
					continue;
				}
				if (��������� == ���������_IacWill && ���� == mccp_Compress2)
				{
					��������� = ���������_�������;
					������������������ = new List<byte>(8);
					�����.Add(Telnet.Iac);
					�����.Add(Telnet.Do);
					�����.Add(mccp_Compress2);
					continue;
				}
				if (��������� == ���������_Iac && ���� == Telnet.Sb)
				{
					��������� = ���������_IacSb;
					continue;
				}
				if (��������� == ���������_IacSb && ���� == mccp_Compress)
				{
					��������� = ���������_IacSbCompress;
					continue;
				}
				if (��������� == ���������_IacSb && ���� == mccp_Compress2)
				{
					��������� = ���������_IacSbCompress2;
					continue;
				}
				if (��������� == ���������_IacSbCompress && ���� == Telnet.Will)
				{
					��������� = ���������_IacSbCompressWill;
					continue;
				}
				if (��������� == ���������_IacSbCompress2 && ���� == Telnet.Iac)
				{
					��������� = ���������_IacSbCompress2Iac;
					continue;
				}
				if (��������� == ���������_IacSbCompressWill && ���� == Telnet.Se)
				{
					��������� = ���������_�������;
					������������������ = new List<byte>(8);
					������Mccp = 1;
					inflater = new Inflater();
					goto ������;
				}
				if (��������� == ���������_IacSbCompress2Iac && ���� == Telnet.Se)
				{
					��������� = ���������_�������;
					������������������ = new List<byte>(8);
					������Mccp = 2;
					inflater = new Inflater();
					goto ������;
				}
				��������� = ���������_�������;
				���������.AddRange(������������������);
				������������������ = new List<byte>(8);
			}
		}
		������������ = �����.ToArray();
		return ���������.ToArray();
	}

	public int ������Mccp
	{
		get
		{
			return ������Mccp;
		}
	}

	public float �����������������
	{
		get
		{
			if (inflater == null || inflater.TotalIn == 0)
				return 1;
			return (float)inflater.TotalOut / inflater.TotalIn;
		}
	}
}
