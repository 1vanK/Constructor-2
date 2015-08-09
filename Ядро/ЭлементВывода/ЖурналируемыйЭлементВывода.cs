/*
	�����, ����������� ������ � ��������������� ����
*/


using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;


class �������������������������� : �������������
{
	static readonly string ������������ = Path.Combine(Application.StartupPath, "�������");

	public bool ��������������� = true;
	public bool ��������������� = true;

	StreamWriter streamWriter = null;
	List<������> ������������������ = new List<������>(256);
	long ��������������� = 0;

	public bool ������������
	{
		get
		{
			return (streamWriter != null);
		}
	}

	string ����������
	{
		get
		{
			return DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss");
		}
	}

	string ����
	{
		get
		{
			return DateTime.Now.ToString("yyyy.MM.dd");
		}
	}

	void ��������()
	{
		if (!������������)
		{
			�������("### ������ �� ������.");
			return;
		}
		long �������� = -1;
		foreach (������ ������ in ������������������)
		{
			if (�������� == -1)
			{
				long ������������ = DateTime.Now.Ticks;
				�������� = ������������ - ���������������;
				��������������� = ������������;
				�������� /= 10000;
				if (�������� < 100)
					�������� = 0;
				if (�������� > 0xFFFF)
					�������� = 0xFFFF;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			if (���������������)
				stringBuilder.Append(��������.ToString("X4") + " ");
			if (!���������������)
				stringBuilder.Append(������.ToString());
			else
				stringBuilder.Append(������������������(������));
			streamWriter.WriteLine(stringBuilder.ToString());
			�������� = 0;
		}
		������������������ = new List<������>(256);
		streamWriter.Flush();
	}

	public override void ��������(params ������[] �����������������)
	{
		lock (this)
		{
			base.��������(�����������������);
			if (������������)
				������������������.AddRange(�����������������);
		}
	}

	public void �������������()
	{
		if (!������������)
		{
			�������("### ������ �� ������.");
			return;
		}
		string ������ = "### ����� ������: " + ���������� + ".";
		if (���������������)
			streamWriter.Write("0000 ");
		if (���������������)
			streamWriter.Write("\u001B07");
		streamWriter.WriteLine(������);
		streamWriter.Close();
		streamWriter = null;
		������������������ = new List<������>(256);
		��������������� = 0;
		�������("### ������ ������.");
	}

	public override void �������()
	{
		lock (this)
		{
			base.�������();
			if (������������ && ������������������.Count > 0)
				��������();
		}
	}

	string ������������������(������ ������)
	{
		if (������.����� == 0)
			return "";
		StringBuilder ��������� = new StringBuilder(������.����� * 2);
		byte ���� = ������[0].����;
		StringBuilder ��������� = new StringBuilder(������.�����);
		���������.Append(������[0].��������);
		for (int i = 1; i < ������.�����; i++)
		{
			if (������[i].���� != ����)
			{
				���������.Append("\u001B" + ����.ToString("X2"));
				���������.Append(���������);
				���� = ������[i].����;
				��������� = new StringBuilder(������.�����);
			}
			���������.Append(������[i].��������);
		}
		���������.Append("\u001B" + ����.ToString("X2"));
		���������.Append(���������);
		return ���������.ToString();
	}

	public void �������������(string ��������, bool �������������)
	{
		if (������������)
		{
			�������("### ������ ��� ������.");
			return;
		}
		if (��������������������)
		{
			�������("### ������ ������� ������ �� ����� ���������������.");
			return;
		}
		if (!Directory.Exists(������������))
			Directory.CreateDirectory(������������);
		if (�������������)
			�������� = �������� + " " + ����;
		�������� = ��������.Trim();
		if (�������� == "")
			�������� = ����������;
		int ������������ = 0;
		StreamWriter sw = null;
	�������������:
		������������++;
		string ���� = Path.Combine(������������, �������� + ".txt");
		try
		{
			sw = new StreamWriter(����, true, Encoding.GetEncoding(1251));
		}
		catch
		{
			if (������������ >= 10)
			{
				�������("### �� ������� ������� ������.");
				return;
			}
			�������� += "_";
			goto �������������;
		}
		��������������� = DateTime.Now.Ticks;
		�������("### ������ ������ ���� � ���� \"�������\\" + �������� + ".txt\".");
		streamWriter = sw;
		string ������ = "### ������ ������: " + ���������� + ".";
		if (���������������)
			streamWriter.Write("0000 ");
		if (���������������)
			streamWriter.Write("\u001B07");
		streamWriter.WriteLine(������);
		���������������������������();
	}

	public void �������������()
	{
		�������������(����������, false);
	}

	public void �������������(string ��������)
	{
		�������������(��������, false);
	}

	bool ����� = false;
	int �������� = 100;
	string[] ����� = null;
	Thread ����� = null;

	void ��������()
	{
		����� = false;
		�������� = 100;
		����� = null;
		if (����� != null)
		{
			�����.Abort();
			�����.Join();
			����� = null;
		}
	}

	public bool ��������������������
	{
		get
		{
			return (����� != null);
		}
	}

	public bool �����
	{
		get
		{
			return �����;
		}
		set
		{
			if (!��������������������)
			{
				�������("### ��������������� �� ������.");
				return;
			}
			����� = value;
			if (�����)
				�������("### ��������������� ��������������.");
			else
				�������("### ��������������� ����������.");
		}
	}

	public int ��������
	{
		get
		{
			return ��������;
		}
		set
		{
			if (!��������������������)
			{
				�������("### ��������������� �� ������.");
				return;
			}
			�������� = value;
			if (�������� < 1)
				�������� = 1;
			if (�������� > 10000)
				�������� = 10000;
			�������("### ����������� �������� ���������������: " + �������� + "%.");
		}
	}

	public void ����()
	{
		if (!��������������������)
		{
			�������("### ��������������� �� ������.");
			return;
		}
		�������("### ��������������� ��������.");
		��������();
	}

	byte �������������(char ������)
	{
		if (������ >= '0' && ������ <= '9')
			return (byte)(������ - '0');
		if (������ >= 'a' && ������ <= 'f')
			return (byte)(������ - 'a' + 10);
		if (������ >= 'A' && ������ <= 'F')
			return (byte)(������ - 'A' + 10);
		return 0;
	}

	������ ������������(string ������)
	{
		������ ��������� = new ������(������.Length);
		byte ������������������ = 7;
		byte �������� = 0;
		int ��������� = 0;
		foreach (char ������ in ������)
		{
			if (��������� == 1)
			{
				�������� = �������������(������);
				��������� = 2;
				continue;
			}
			if (��������� == 2)
			{
				������������������ = �������������(������);
				��������� = 0;
				continue;
			}
			if (������ == '\u001B')
			{
				��������� = 1;
				continue;
			}
			���������.��������(new ������(������, ������������������, ��������));
		}
		return ���������;
	}

	void ������������������()
	{
		List<������> ��������������� = new List<������>(�����.Length + 2);
		���������������.Add(new ������("### ��������������� ������."));
		foreach (string ����� in �����)
		{
			if (�����.Length < 5 || �����[4] != ' ')
			{
				���������������.Add(������������(�����));
				continue;
			}
			int �������� = 0;
			try
			{
				�������� = int.Parse(�����.Substring(0, 4), NumberStyles.AllowHexSpecifier);
			}
			catch
			{
				���������������.Add(������������(�����));
				continue;
			}
			if (�������� != 0)
			{
				�������(���������������.ToArray());
				��������������� = new List<������>(�����.Length);
				long �������������� = DateTime.Now.Ticks / 10000;
				while (true)
				{
					long ������������ = DateTime.Now.Ticks / 10000;
					if (������������ - �������������� >= �������� * 100 / ��������)
						break;
					Thread.Sleep(1);
				}
				while (�����)
					Thread.Sleep(1);
			}
			���������������.Add(������������(�����.Substring(5)));
		}
		���������������.Add(new ������("### ��������������� ���������."));
		�������(���������������.ToArray());
		��������();
	}

	string �����������(string ��������)
	{
		if (File.Exists(��������))
			return ��������;
		string ���� = �������� + ".txt";
		if (File.Exists(����))
			return ����;
		���� = Path.Combine(Application.StartupPath, ��������);
		if (File.Exists(����))
			return ����;
		���� += ".txt";
		if (File.Exists(����))
			return ����;
		���� = Path.Combine(������������, ��������);
		if (File.Exists(����))
			return ����;
		���� += ".txt";
		if (File.Exists(����))
			return ����;
		return null;
	}

	public void �������������(string ����)
	{
		if (��������������������)
		{
			�������("### ��������������� ��� ������.");
			return;
		}
		if (������������)
		{
			�������("### ������ ������ ��������������� � �������� ������ ����.");
			return;
		}
		try
		{
			����� = File.ReadAllLines(�����������(����), Encoding.GetEncoding(1251));
		}
		catch
		{
			�������("### �� ������� ������� ����.");
			return;
		}
		����� = new Thread(new ThreadStart(������������������));
		�����.Start();
	}
}
