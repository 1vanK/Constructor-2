/*
	������ ��������� ��� �������� ������
*/


using System;
using System.Windows.Forms;


class ��������������� : VScrollBar
{
	public bool ����������������������������� = false;

	public ���������������()
	{
		Dock = DockStyle.Right;
		SmallChange = LargeChange = 1;
		������������();
	}

	public void ������������()
	{
		����������������������������� = false;
		Minimum = Maximum = -1;
		Enabled = false;
	}

	protected override void OnValueChanged(EventArgs e)
	{
		if (�����������������������������)
			return;
		if (Parent != null)
			Parent.Invalidate();
	}

	new public int Minimum
	{
		set
		{
			if (Maximum < value)
				Maximum = value;
			// � ��������� .Net Framework v2.0.40607 ������
			// "this.Value = value" �������� "this.value = value",
			// ������� OnValueChanged �� ����������.
			// ����� ��� ������ ���������.
			if (value > Value)
				Value = value;
			base.Minimum = value;
		}
		get
		{
			return base.Minimum;
		}
	}

	public int ��������
	{
		set
		{
			if (value < 0)
			{
				������������();
			}
			else
			{
				Minimum = 0;
				Maximum = value;
				if (Maximum > 0)
					Enabled = true;
			}
		}
		get
		{
			return Maximum;
		}
	}
}
