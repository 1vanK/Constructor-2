/*
	���������� ������
*/


using System;
using System.Collections.Generic;


struct ���������������
{
	static Dictionary<string, �������> ������� = new Dictionary<string, �������>(256);

	static ���������������()
	{
		string[] ����� = Enum.GetNames(typeof(�������));
		foreach (string ��� in �����)
		{
			������� ��� = (�������)Enum.Parse(typeof(�������), ���);
			�������.Add(���.ToUpper(), ���);
		}
		�������.Add("`", �������.������);
		�������.Add("~", �������.������);
		�������.Add("1", �������.D1);
		�������.Add("!", �������.D1);
		�������.Add("2", �������.D2);
		�������.Add("@", �������.D2);
		�������.Add("3", �������.D3);
		�������.Add("#", �������.D3);
		�������.Add("4", �������.D4);
		�������.Add("$", �������.D4);
		�������.Add("5", �������.D5);
		�������.Add("%", �������.D5);
		�������.Add("6", �������.D6);
		�������.Add("^", �������.D6);
		�������.Add("7", �������.D7);
		�������.Add("&", �������.D7);
		�������.Add("8", �������.D8);
		�������.Add("*", �������.D8);
		�������.Add("9", �������.D9);
		�������.Add("(", �������.D9);
		�������.Add("0", �������.D0);
		�������.Add(")", �������.D0);
		�������.Add("-", �������.�����);
		�������.Add("_", �������.�����);
		�������.Add("=", �������.����);
		�������.Add("+", �������.����);
		�������.Add("\\", �������.Backslash);
		�������.Add("|", �������.Backslash);
		�������.Add("[", �������.OpenBrack);
		�������.Add("{", �������.OpenBrack);
		�������.Add("]", �������.CloseBrack);
		�������.Add("}", �������.CloseBrack);
		�������.Add(";", �������.Semicolon);
		�������.Add(":", �������.Semicolon);
		�������.Add("'", �������.Quote);
		�������.Add("\"", �������.Quote);
		�������.Add(",", �������.Comma);
		�������.Add("<", �������.Comma);
		�������.Add(".", �������.Period);
		�������.Add(">", �������.Period);
		�������.Add("/", �������.Question);
		�������.Add("?", �������.Question);
		�������.Add(" ", �������.������);
	}

	������� �������;
	bool ctrl;
	bool alt;
	bool shift;

	public ���������������(������� �������, bool ctrl, bool alt, bool shift)
	{
		if (!Enum.IsDefined(typeof(�������), �������))
		{
			this.������� = 0;
			this.ctrl = this.alt = this.shift = false;
		}
		else
		{
			this.������� = �������;
			this.ctrl = ctrl;
			this.alt = alt;
			this.shift = shift;
		}
	}

	public ������� �������
	{
		get
		{
			return �������;
		}
	}

	public bool Ctrl
	{
		get
		{
			return ctrl;
		}
	}

	public bool Alt
	{
		get
		{
			return alt;
		}
	}

	public bool Shift
	{
		get
		{
			return shift;
		}
	}

	public override string ToString()
	{
		if (!Enum.IsDefined(typeof(�������), �������))
			return "���";
		string ��������� = "";
		if (Ctrl)
			��������� += "CTRL" + ����������.�����������������;
		if (Alt)
			��������� += "ALT" + ����������.�����������������;
		if (Shift)
			��������� += "SHIFT" + ����������.�����������������;
		��������� += �������.ToString().ToUpper();
		return ���������;
	}

	public ���������������(string ������)
	{
		������� = 0;
		ctrl = alt = shift = false;
		������ = ������.Trim().ToUpper();
		string ����������� = ����������.�����������������.ToString();
		������ = ������.Replace(����������� + �����������, ����������� + "�����������");
		if (������.Length == 0)
			return;
		string[] ��������� = ������.Split(����������.�����������������);
		try
		{
			string ���������� = ���������[���������.Length - 1];
			if (���������� == "�����������")
				���������� = �����������;
			if (���������� == "")
				���������� = "������";
			������� = �������[����������];
		}
		catch
		{
			goto �����;
		}
		for (int i = 0; i < ���������.Length - 1; i++)
		{
			if (���������[i] == "CTRL")
			{
				if (ctrl)
					goto �����;
				ctrl = true;
			}
			else if (���������[i] == "ALT")
			{
				if (alt)
					goto �����;
				alt = true;
			}
			else if (���������[i] == "SHIFT")
			{
				if (shift)
					goto �����;
				shift = true;
			}
			else
			{
				goto �����;
			}
		}
		return;
	�����:
		������� = 0;
		ctrl = alt = shift = false;
	}

	public static bool operator ==(��������������� ���������1, ��������������� ���������2)
	{
		if (���������1.������� != ���������2.�������)
			return false;
		if (���������1.Ctrl != ���������2.Ctrl)
			return false;
		if (���������1.Alt != ���������2.Alt)
			return false;
		if (���������1.Shift != ���������2.Shift)
			return false;
		return true;
	}

	public static bool operator !=(��������������� ���������1, ��������������� ���������2)
	{
		return !(���������1 == ���������2);
	}

	public override bool Equals(object obj)
	{
		try 
		{
			return (this == (���������������)obj);
		}
		catch 
		{
			return false;
		}
	}

	public override int GetHashCode()
	{
		int ��� = (int)�������;
		if (ctrl)
			��� |= 0x200;
		if (alt)
			��� |= 0x400;
		if (shift)
			��� |= 0x800;
		return ���;
	}
}
