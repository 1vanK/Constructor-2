/*
	���������� ������
*/


using System;
using System.Windows.Forms;


class ������ : ����
{
	������()
	{
		Text = "���������� ������";
		WindowState = FormWindowState.Maximized;
	}

	public override bool ������������������������(������� �������, bool ctrl, bool alt, bool shift)
	{
		if (!ctrl && !alt && !shift)
		{
			switch (�������)
			{
				case �������.F1:
					������������������������ = !������������������������;
					return true;
				case �������.F2:
					������������.����������� = !������������.�����������;
					return true;
				case �������.F3:
					�������������.��������������� = !�������������.���������������;
					return true;
				case �������.F5:
					�������������.�������������("���");
					return true;
				case �������.F6:
					�������������.�������������();
					return true;
				case �������.F7:
					�������������.�������������("���");
					return true;
				case �������.F8:
					�������������.����();
					return true;
				case �������.F9:
					�������������.����� = !�������������.�����;
					return true;
				case �������.F10:
					�������.���������(2000, "�����");
					return true;
				case �������.F11:
					�������.���������������("������1", 1000, 1000, 5, "���");
					return true;
				case �������.F12:
					�������.�������������();
					return true;
				case �������.Num8:
					������������������������("n");
					return true;
				case �������.Num2:
					������������������������("s");
					return true;
				case �������.Num4:
					������������������������("w");
					return true;
				case �������.Num6:
					������������������������("e");
					return true;
				case �������.Num9:
					������������������������("u");
					return true;
				case �������.Num3:
					������������������������("d");
					return true;
				case �������.Num7:
					������������������������("��");
					return true;
				case �������.Num5:
					������������������������("���");
					return true;
				case �������.Num1:
					������������������������("���");
					return true;
			}
		}
		if (ctrl && !alt && !shift)
		{
			switch (�������)
			{
				case �������.�:
					����������.����������("localhost", 4000);
					return true;
				case �������.�:
					����������.����������("mud.ru", 4000);
					return true;
				case �������.�:
					����������.����������("hiervard.ru", 4000);
					return true;
				case �������.�:
					����������.���������();
					return true;
			}
		}
		return base.������������������������(�������, ctrl, alt, shift);
	}

	[STAThread]
	static void Main()
	{
		Application.Run(new ������());
	}
}