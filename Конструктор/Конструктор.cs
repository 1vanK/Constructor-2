/*
	������� ����� ����������
*/


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


class ����������� : Form, IMessageFilter
{
	public static ����������� ����������� = new �����������();

	[STAThread]
	static void Main()
	{
		Application.Run(�����������);
	}

	int x, y, ������, ������;
	FormWindowState ���������;

	public ����������� ����������� = new �����������();
	public ����������� ����������� = new �����������();
	public ������������� ������������� = new �������������();

	�����������()
	{
		Text = "����������� 2.15";
		IsMdiContainer = true;
		StartPosition = FormStartPosition.Manual;
		Menu = �����������;
		�����������.Parent = this;
		�������������.Dock = DockStyle.Bottom;
		�������������.Parent = this;
		����������������();
		Application.AddMessageFilter(this);
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		����������������();
		string �������������� = "";
		foreach (���� ���� in MdiChildren)
		{
			if (����.���� == null || ����.���� == "")
				continue;
			if (�������������� != "")
				�������������� += "|";
			�������������� += ����.����;
		}
		Ini.���������(null, "���������", "�������", ��������������);
		base.OnClosing(e);
	}

	protected override void OnLoad(EventArgs e)
	{
		string �������������� = Ini.���������(null, "���������", "�������", "").Trim();
		if (�������������� == "")
			return;
		string[] ����� = ��������������.Split('|');
		foreach (string ���� in �����)
			��������������(����);
		base.OnLoad(e);
	}

	protected override void OnResize(EventArgs e)
	{
		if (WindowState == FormWindowState.Normal)
		{
			������ = Width;
			������ = Height;
		}
		if (WindowState != FormWindowState.Minimized)
			��������� = WindowState;
		base.OnResize(e);
	}

	protected override void OnMove(EventArgs e)
	{
		if (WindowState == FormWindowState.Normal)
		{
			x = Left;
			y = Top;
		}
		if (WindowState != FormWindowState.Minimized)
			��������� = WindowState;
		base.OnMove(e);
	}

	void ����������������()
	{
		x = Ini.���������(null, "���������", "X", 100);
		y = Ini.���������(null, "���������", "Y", 100);
		Location = new Point(x, y);
		������ = Ini.���������(null, "���������", "������", 400);
		������ = Ini.���������(null, "���������", "������", 300);
		Size = new Size(������, ������);
		��������� = Ini.���������(null, "���������", "���������", FormWindowState.Maximized);
		WindowState = ���������;
		�������������.Height = Ini.���������(null, "���������", "��������������������", �������.������������� * 3);
	}

	void ����������������()
	{
		Ini.���������(null, "���������", "X", x);
		Ini.���������(null, "���������", "Y", y);
		Ini.���������(null, "���������", "������", ������);
		Ini.���������(null, "���������", "������", ������);
		Ini.���������(null, "���������", "���������", ���������);
		Ini.���������(null, "���������", "��������������������", �������������.Height);
	}

	public void ��������������()
	{
		���� ���� = new ����();
		����.MdiParent = this;
		if (MdiChildren.Length == 1)
			����.WindowState = FormWindowState.Maximized;
		����.Show();
	}

	public void ��������������()
	{
		���� ���� = new ����();
		if (!����.���������(true))
			return;
		����.�������������.�������();
		����.����������.��������������();
		����.MdiParent = this;
		if (MdiChildren.Length == 1)
			����.WindowState = FormWindowState.Maximized;
		����.Show();
	}

	public void ��������������(string ����)
	{
		���� ���� = new ����();
		if (!����.���������(����, true))
			return;
		����.�������������.�������();
		����.����������.��������������();
		����.MdiParent = this;
		if (MdiChildren.Length == 1)
			����.WindowState = FormWindowState.Maximized;
		����.Show();
	}

	public void ����������������(���� ����)
	{
		if (���� == null)
			return;
		����.Activate();
		if (����.WindowState == FormWindowState.Minimized)
			����.WindowState = FormWindowState.Normal;
	}

	public void ����������������(int �����)
	{
		����������������(���������(�����));
	}

	public void ����������������(string ���)
	{
		����������������(���������(���));
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (m.Msg != 0x0100 && m.Msg != 0x0104)
			return false;
		uint ���������� = (uint)m.LParam;
		���������� = ���������� >> 16;
		���������� = ���������� & 0x1FF;
		������� ������� = (�������)����������;
		bool ctrl  = ((ModifierKeys & Keys.Control) == Keys.Control);
		bool alt   = ((ModifierKeys & Keys.Alt) == Keys.Alt);
		bool shift = ((ModifierKeys & Keys.Shift) == Keys.Shift);
		if (ctrl && !alt && !shift)
		{
			switch (�������)
			{
				case �������.D1:
					����������������(1);
					return true;
				case �������.D2:
					����������������(2);
					return true;
				case �������.D3:
					����������������(3);
					return true;
				case �������.D4:
					����������������(4);
					return true;
				case �������.D5:
					����������������(5);
					return true;
				case �������.D6:
					����������������(6);
					return true;
				case �������.D7:
					����������������(7);
					return true;
				case �������.D8:
					����������������(8);
					return true;
				case �������.D9:
					����������������(9);
					return true;
				case �������.D0:
					����������������(10);
					return true;
			}
		}
		return false;
	}

	public void �������������(string ������, ������ �����)
	{
		if (������ == null)
			return;
		foreach (������ ���� in MdiChildren)
		{
			if (���� != �����)
				����.������������������������(������);
		}
	}

	public void ���������(int ���������, string ������)
	{
		if (������ == null)
			return;
		���� ���� = ���������(���������);
		if (���� != null)
			����.������������������������(������);
	}

	public void ���������(string ���, string ������)
	{
		if (������ == null)
			return;
		���� ���� = ���������(���);
		if (���� != null)
			����.������������������������(������);
	}

	public ���� ���������(int ���������)
	{
		if (��������� == 0)
			��������� = 9;
		else
			���������--;
		if (��������� < 0 || ��������� >= MdiChildren.Length)
			return null;
		return (����)MdiChildren[���������];
	}

	public ���� ���������(string ���)
	{
		if (��� == null || ��� == "")
			return null;
		foreach (���� ���� in MdiChildren)
		{
			if (string.Compare(����.����������.���, ���, true) == 0)
				return ����;
		}
		return null;
	}
}
