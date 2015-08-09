/*
	������� ����� ��� �������
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;


using � = ����������;


partial class ������ : ����
{
	public MainMenu ���� = new MainMenu();
	public ��������������� ���������� = new ���������������();
	public ������������������ �������������� = new ������������������();
	public ������������� ������� = new �������������();
	public �������������� �������� = new ��������������();
	public string ���� = ""; // ����� �������� �������

	public ������()
	{
		Text = "";
		MenuItem ������� = ����.MenuItems.Add("�������");
		�������.MergeOrder = 0;
		�������.MergeType = MenuMerge.MergeItems;
		MenuItem �������_��������� = new MenuItem("���������", new EventHandler(�����������������_�������_���������), Shortcut.CtrlS);
		�������.MenuItems.Add(�������_���������);
		MenuItem �������_������������ = new MenuItem("��������� ���...", new EventHandler(�����������������_�������_������������));
		�������.MenuItems.Add(�������_������������);
		Menu = ����;
		����������.�������� = this;
		��������������.�������� = this;
		�������.�������� = this;
		��������.�������� = this;
	}

	public virtual string �����������������(string �������)
	{
		if (�������.Length > 0 && �������[0] == ����������.���������������)
		{
			�������������.�����������(�������);
			����������������(�������.Substring(1));
		}
		else
		{
			string ������� = �������[�������];
			if (������� != null)
				return �������;
			������� = ����������.�������������������(�������);
			�������������.�����������(�������);
			����������.��������(�������);
		}
		return null;
	}

	void ���������������������������(string �����)
	{
		if (����� == null)
			return;
		����� = ����������.������������������(�����);
		string[] ������� = ����������.����������������(�����);
		foreach (string ������� in �������)
			���������������������������(�����������������(�������));
	}

	public void �����������������(string �����)
	{
		lock (this)
		{
			�������������.���������������������������();
			���������������������������(�����);
		}
	}

	public override void ������������������������(string �����)
	{
		lock (this)
		{
			�����������������(�����);
			�������������.�������();
			����������.��������������();
		}
	}

	public virtual string ����������������(������ ������, bool ���������������)
	{
		�������������.��������(������);
		if (������.����� > 0)
			return ��������[������.ToString()];
		return null;
	}

	public override void �������������������������(params ������[] ������)
	{
		foreach (������ ������ in ������)
		{
			if (������.����� > 0 && ������[������.����� - 1].�������� == ' ')
			{
				������.�������������������();
				�����������������(����������������(������, true));
			}
			else
			{
				�����������������(����������������(������, false));
			}
		}
		�������������.�������();
		����������.��������������();
	}

	public void ��������������������()
	{
		for (byte i = 0; i < 16; i++)
		{
			������ ������ = new ������(32);
			for (byte j = 0; j < 16; j++)
				������.��������(i.ToString("X") + j.ToString("X"), j, i);
			�������������.��������(������);
		}
	}

	public static string ������������
	{
		get
		{
			return Path.Combine(Application.StartupPath, "�������");
		}
	}

	public static string �������������(string ����)
	{
		return ����.Replace("/", "\\").Replace(Application.StartupPath + "\\", "");
	}

	public static string ������������(string ����)
	{
		if (!Path.IsPathRooted(����))
			���� = Path.Combine(Application.StartupPath, ����);
		return ����;
	}

	public static void �������������������()
	{
		if (!Directory.Exists(������������))
			Directory.CreateDirectory(������������);
	}

	public static string ������������(string ����)
	{
		�������������������();
		if (File.Exists(����))
			return ����;
		string ���� = ������������(����);
		if (File.Exists(����))
			return ����;
		���� += ".txt";
		if (File.Exists(����))
			return ����;
		���� = Path.Combine(������������, ����);
		if (File.Exists(����))
			return ����;
		���� += ".txt";
		if (File.Exists(����))
			return ����;
		return null;
	}

	public bool ����������������(string ����)
	{
		�������������������();
		List<string> ������ = new List<string>(256);
		if (����������.��� != "")
			������.Add(string.Format("{0}��� {1}{2}{3}", �.���������������, �.�����������, ����������.���, �.����������));
		������.AddRange(����������.��������������());
		������.AddRange(��������������.��������������());
		������.AddRange(�������.��������������());
		������.AddRange(��������.��������������());
		���� = ������������(����);
		try
		{
			File.WriteAllLines(����, ������.ToArray(), Encoding.GetEncoding(1251));
		}
		catch
		{
			�������������.��������("### �� ������� ��������� �������.");
			return false;
		}
		���� = �������������(����);
		�������������.��������("### ������� �������� � ���� \"" + ���� + "\".");
		return true;
	}

	public bool �������������������()
	{
		�������������������();
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
		saveFileDialog.FilterIndex = 1;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.AddExtension = true;
		if (���� != null && ���� != "")
			saveFileDialog.FileName = ����;
		else if (����������.��� != "")
			saveFileDialog.FileName = ����������.���;
		saveFileDialog.InitialDirectory = ������������;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
			return ����������������(saveFileDialog.FileName);
		return false;
	}

	public bool ����������������()
	{
		if (���� != null && ���� != "" && ����������������(����))
			return true;
		return �������������������();
	}

	public bool ���������(string ����, bool ���������������)
	{
		�������������������();
		���� = ������������(����);
		string[] ������;
		try
		{
			������ = File.ReadAllLines(����, Encoding.GetEncoding(1251));
		}
		catch
		{
			�������������.��������("### �� ������� ������� ����.");
			return false;
		}
		���� = �������������(����);
		if (���������������)
			�������������.��������("### �������� ������� \"" + ���� + "\"...");
		else
			�������������.��������("### ���������� ����� \"" + ���� + "\"...");
		foreach (string ������ in ������)
			�����������������(������);
		if (���������������)
		{
			���� = ����;
			�������������.��������("### ������� ��������.");
		}
		else
		{
			�������������.��������("### ���� ��������.");
		}
		return true;
	}

	public bool ���������(bool ���������������)
	{
		�������������������();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = ������������;
		openFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
		openFileDialog.FilterIndex = 1;
		openFileDialog.RestoreDirectory = true;
		if(openFileDialog.ShowDialog() == DialogResult.OK)
			return ���������(openFileDialog.FileName, ���������������);
		return false;
	}

	public override bool ������������������������(������� �������, bool ctrl, bool alt, bool shift)
	{
		��������������� ��������� = new ���������������(�������, ctrl, alt, shift);
		string ������� = ��������������[���������];
		if (������� == null)
			return base.������������������������(�������, ctrl, alt, shift);
		������������������������(�������);
		return true;
	}

	void �����������������_�������_���������(object sender, EventArgs e)
	{
		����������������();
		�������������.�������();
	}

	void �����������������_�������_������������(object sender, EventArgs e)
	{
		�������������������();
		�������������.�������();
	}
}
