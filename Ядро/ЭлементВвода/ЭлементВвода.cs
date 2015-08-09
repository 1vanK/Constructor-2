/*
	������� ��� ����� ���������������� ������
*/


using System;
using System.Drawing;
using System.Windows.Forms;


delegate void ���������������������(string ������);
delegate bool �������������������������������(������� �������, bool ctrl, bool alt, bool shift);


class ������������ : TextBox, IMessageFilter
{
	�������������<string> ������� = new �������������<string>(100);
	int ��������������� = 0;
	bool ��������������������������� = false;

	public event ��������������������� ���� = null;
	public event ������������������������������� �������������� = null;
	public bool ����������� = false;

	public ������������()
	{
		Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Regular);
		BackColor = Color.White;
		ForeColor = Color.Black;
		BorderStyle = BorderStyle.None;
		Multiline = true;
		WordWrap = false;
		Application.AddMessageFilter(this);
	}

	new public void SelectAll()
	{
		base.SelectAll();
		ScrollToCaret();
	}

	protected virtual void ���������������������(string ������)
	{
		if (���� != null)
			����(������);
	}

	protected virtual bool �������������������������������(������� �������, bool ctrl, bool alt, bool shift)
	{
		if (�������������� != null)
			return ��������������(�������, ctrl, alt, shift);
		return false;
	}

	// ��������� �������� Text ��� ������������� ������� OnTextChanged.
	void �������������(string �����)
	{
		��������������������������� = true;
		Text = �����;
		��������������������������� = false;
	}

	protected override void OnTextChanged(EventArgs e)
	{
		if (���������������������������)
			return;
		��������������� = �������.��������������;
		// ������� �������������� ������.
		string[] ������ = Text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
		if (������.Length == 1)
			return;
		for (int i = 0; i < ������.Length - 1; i++)
		{
			if (������[i].Length == 0)
				continue;
			if (�������.�������������� == 0 || �������[�������.�������������� - 1] != ������[i])
				�������.��������(������[i]);
		}
		if (������[������.Length - 1] != "" || ����������� || ������[������.Length - 2].Length == 0)
		{
			��������������� = �������.��������������;
			�������������(������[������.Length - 1]);
			SelectionStart = Text.Length;
			ScrollToCaret();
		}
		else
		{
			��������������� = �������.�������������� - 1;
			�������������(�������[���������������]);
			SelectAll();
		}
		for (int i = 0; i < ������.Length - 1; i++)
			���������������������(������[i]);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		// ������� Enter'�.
		if (e.KeyChar != '\r')
			return;
		e.Handled = true;
		string ������ = Text;
		if (������.Length > 0)
		{
			if (�������.�������������� == 0 || �������[�������.�������������� - 1] != ������)
				�������.��������(������);
			if (�����������)
			{
				��������������� = �������.��������������;
				�������������("");
			}
			else
			{
				��������������� = �������.�������������� - 1;
				SelectAll();
			}
		}
		���������������������(������);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (e.KeyData == Keys.Up)
		{
			if (��������������� > 0)
				���������������--;
		}
		else if (e.KeyData == Keys.Down)
		{
			if (��������������� < �������.��������������)
				���������������++;
		}
		else
		{
			return;
		}
		e.Handled = true;
		if (��������������� == �������.��������������)
			�������������("");
		else
			�������������(�������[���������������]);
		SelectAll();
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (IsDisposed || m.HWnd != Handle)
			return false;
		if (m.Msg != 0x0100 && m.Msg != 0x0104)
			return false;
		uint ���������� = (uint)m.LParam;
		���������� = ���������� >> 16;
		���������� = ���������� & 0x1FF;
		������� ������� = (�������)����������;
		bool ctrl  = ((ModifierKeys & Keys.Control) == Keys.Control);
		bool alt   = ((ModifierKeys & Keys.Alt) == Keys.Alt);
		bool shift = ((ModifierKeys & Keys.Shift) == Keys.Shift);
		return �������������������������������(�������, ctrl, alt, shift);
	}
}
