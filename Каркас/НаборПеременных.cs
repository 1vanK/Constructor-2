/*
	�������� ����������
*/


using System;
using System.Collections.Generic;


using � = ����������;


class ���������������
{
	Dictionary<string, string> ������� = new Dictionary<string, string>(256);
	string ��� = "";

	public ������ �������� = null;

	void �������(params string[] ������)
	{
		if (�������� != null)
			��������.�������������.��������(������);
	}

	public int ����������
	{
		get
		{
			return �������.Count;
		}
	}

	public string ���
	{
		get
		{
			if (��� == null)
				return "";
			return ���;
		}
		set
		{
			��� = value;
			if (��� == null)
				��� = "";
			�������("### ���������� \"���\" ��������� �������� \"" + ��� + "\".");
			if (�������� != null)
				��������.Text = ���;
		}
	}

	public void ��������()
	{
		if (�������.Count == 0)
		{
			�������("### ��� �� ����� ����������.");
			return;
		}
		�������.Clear();
		�������("### ������� ��� ����������.");
	}

	public void ��������(string ��������, string ��������)
	{
		this[��������] = ��������;
	}

	public string this[string ��������]
	{
		get
		{
			try
			{
				return �������[��������];
			}
			catch
			{
				return null;
			}
		}
		set
		{
			if (�������� == null || �������� == "")
			{
				�������("### ������������ �������� ����������.");
				return;
			}
			if (value == null)
			{
				�������(��������);
				return;
			}
			�������[��������] = value;
			�������("### ���������� \"" + �������� + "\" ��������� �������� \"" + value + "\".");
		}
	}

	public void �������(string ��������)
	{
		if (!�������.ContainsKey(��������))
		{
			�������("### ����� ���������� �� ����������.");
			return;
		}
		�������.Remove(��������);
		�������("### ���������� \"" + �������� + "\" �������.");
	}

	public string[] ��������������()
	{
		List<string> ��������� = new List<string>(�������.Count);
		Dictionary<string, string>.Enumerator enumerator = �������.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string ������ = �.��������������� + "���������� " + �.����������� + enumerator.Current.Key + �.����������;
			������ += " " + �.����������� + enumerator.Current.Value + �.����������;
			���������.Add(������);
		}
		return ���������.ToArray();
	}

	public void �������������()
	{
		if (�������.Count == 0)
		{
			�������("### ��� �� ����� ����������.");
			return;
		}
		string[] ������ = ��������������();
		for (int i = 0; i < ������.Length; i++)
			�������("### " + ������[i] + ".");
	}

	public string ������������������(string ������)
	{
		if (������ == null || ������ == "")
			return ������;
		������ = ������.Replace("$���", ���);
		������ = ������.Replace("$����", DateTime.Now.ToString("yyyy.MM.dd"));
		������ = ������.Replace("$�����", DateTime.Now.ToString("HH-mm-ss"));
		Dictionary<string, string>.Enumerator enumerator = �������.GetEnumerator();
		while (enumerator.MoveNext())
			������ = ������.Replace("$" + enumerator.Current.Key, enumerator.Current.Value);
		return ������;
	}
}
