/*
	������� ��� ����������� ����� ������
*/


using System.Drawing;
using System.IO;
using System.Windows.Forms;


class ������� : Form, IMessageFilter
{
	const int wmSysKeyDown = 0x0104;
	const int wmKeyDown    = 0x0100;

	StreamWriter streamWriter = new StreamWriter("������� �������.txt");
	uint ���������� = 0;

	�������()
	{
		ClientSize = new Size(400, 0);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		Text = "��������� �������...";
		MaximizeBox = false;
		StartPosition = FormStartPosition.CenterScreen;
		Application.AddMessageFilter(this);
		streamWriter.AutoFlush = true;
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (m.Msg == wmSysKeyDown || m.Msg == wmKeyDown)
		{
			���������� = (uint)m.LParam;
			���������� = ���������� >> 16;
			���������� = ���������� & 0x1FF;
		}
		return false;
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		string ��������� = e.KeyCode.ToString() + " = 0x" + ����������.ToString("X3");
		Text = ���������;
		streamWriter.WriteLine(���������);
	}

	static void Main()
	{
		Application.Run(new �������());
	}
}
