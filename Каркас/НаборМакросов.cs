/*
	�������� ��������
*/


using System.Collections.Generic;
using System.Text.RegularExpressions;


using � = ����������;


class �������������
{
	Dictionary<string, string> ������� = new Dictionary<string, string>(256);

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
			�������("### ��� �� ������ �������.");
			return;
		}
		�������.Clear();
		�������("### ������� ��� �������.");
	}

	public void ��������(string ������, string �������)
	{
		this[������] = �������;
	}

	public string this[string ������]
	{
		get
		{
			Dictionary<string, string>.Enumerator enumerator = �������.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Match match = Regex.Match(������, enumerator.Current.Key);
				if (match.Success)
					return match.Result(enumerator.Current.Value);
			}
			return null;
		}
		set
		{
			if (������ == "" || ������ == null)
			{
				�������("### ������������ ������.");
				return;
			}
			if (value == null)
			{
				�������(������);
				return;
			}
			�������[������] = value;
			string ��������� = "### ������ ����� ������, ��������������� ������� \"" + ������ + "\" ����������� ";
			��������� += "\"" + value + "\".";
			�������(���������);
		}
	}

	public void �������(string ������)
	{
		if (!�������.ContainsKey(������))
		{
			�������("### ������ ������� �� ����������.");
			return;
		}
		�������.Remove(������);
		�������("### ������ ������.");
	}

	public string[] ��������������()
	{
		List<string> ��������� = new List<string>(�������.Count);
		Dictionary<string, string>.Enumerator enumerator = �������.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string ������ = �.��������������� + "������ " + �.����������� + enumerator.Current.Key + �.����������;
			������ += " " + �.����������� + enumerator.Current.Value + �.����������;
			���������.Add(������);
		}
		return ���������.ToArray();
	}

	public void �������������()
	{
		if (�������.Count == 0)
		{
			�������("### ��� �� ������ �������.");
			return;
		}
		string[] ������ = ��������������();
		for (int i = 0; i < ������.Length; i++)
			�������("### " + ������[i] + ".");
	}
}