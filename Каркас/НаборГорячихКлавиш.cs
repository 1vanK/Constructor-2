/*
	�������� ������� ������
*/


using System.Collections.Generic;


using � = ����������;


class ������������������
{
	Dictionary<���������������, string> ������� = new Dictionary<���������������, string>(256);

	public ������ �������� = null;

	void �������(params string[] ������)
	{
		if (�������� != null)
			��������.�������������.��������(������);
	}

	public void ��������()
	{
		if (�������.Count == 0)
		{
			�������("### ��� ����������� ������� ������.");
			return;
		}
		�������.Clear();
		�������("### ������� ��� ������� �������.");
	}

	public void ��������(��������������� ���������, string �������)
	{
		this[���������] = �������;
	}

	public void ��������(������� �������, bool ctrl, bool alt, bool shift, string �������)
	{
		this[new ���������������(�������, ctrl, alt, shift)] = �������;
	}

	public void ��������(string ���������, string �������)
	{
		this[new ���������������(���������)] = �������;
	}

	public string this[��������������� ���������]
	{
		get
		{
			try
			{
				return �������[���������];
			}
			catch
			{
				return null;
			}
		}
		set
		{
			if (���������.������� == 0)
			{
				�������("### ������������ ���������� ������.");
				return;
			}
			if (value == null)
			{
				�������(���������);
				return;
			}
			�������[���������] = value;
			string ��������� = "### ������ ��� ������� " + ���������.ToString() + " ����������� ";
			��������� += "\"" + value + "\".";
			�������(���������);
		}
	}

	public void �������(��������������� ���������)
	{
		if (!�������.ContainsKey(���������))
		{
			�������("### ����� ������� ������� �� ����������.");
			return;
		}
		�������.Remove(���������);
		string ��������� = "### ��� ������� " + ���������.ToString() + " ������ ������ �� �����������.";
		�������(���������);
	}

	public void �������(������� �������, bool ctrl, bool alt, bool shift)
	{
		�������(new ���������������(�������, ctrl, alt, shift));
	}

	public void �������(string ���������)
	{
		�������(new ���������������(���������));
	}

	public string[] ��������������()
	{
		List<string> ��������� = new List<string>(�������.Count);
		Dictionary<���������������, string>.Enumerator enumerator = �������.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string ������ = �.��������������� + "��������������� " + enumerator.Current.Key.ToString();
			������ += " " + �.����������� + enumerator.Current.Value + �.����������;
			���������.Add(������);
		}
		return ���������.ToArray();
	}

	public void �������������()
	{
		if (�������.Count == 0)
		{
			�������("### ��� ����������� ������� ������.");
			return;
		}
		string[] ������ = ��������������();
		for (int i = 0; i < ������.Length; i++)
			�������("### " + ������[i] + ".");
	}
}
