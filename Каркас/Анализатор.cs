/*
	������� ��� ������� �����
*/


using System;
using System.Collections.Generic;
using System.Text;


static class ����������
{
	public const char ����������������� = '+';
	public const char ����������������� = ';';
	public const char ����������� = '{';
	public const char ���������� = '}';
	public const char ��������������� = '#';

	public static bool �����������(string ������, string �������)
	{
		if (������ == null || ������� == null || ������ == "" || ������� == "")
			return false;
		if (������.Length > �������.Length)
			return false;
		return (string.Compare(������, 0, �������, 0, ������.Length, true) == 0);
	}

	public static bool ��������(string ������1, string ������2)
	{
		return (string.Compare(������1, ������2, true) == 0);
	}

	public static string[] ����������������(string ������)
	{
		List<string> ��������� = new List<string>(8);
		StringBuilder ������� = new StringBuilder(64);
		int ���������������� = 0;
		bool ������������������������� = false;
		for (int i = 0; i < ������.Length; i++)
		{
			if (�������������������������)
			{
				�������.Append(������[i]);
				������������������������� = false;
				continue;
			}
			if (������[i] == ����������������� && ���������������� == 0)
			{
				���������.Add(�������.ToString());
				������� = new StringBuilder(64);
				continue;
			}
			�������.Append(������[i]);
			if (������[i] == '\\')
				������������������������� = true;
			else if (������[i] == �����������)
				����������������++;
			else if (������[i] == ����������)
				���������������� = Math.Max(0, ���������������� - 1);
		}
		���������.Add(�������.ToString());
		return ���������.ToArray();
	}

	public static void ����������������(string �������, out string ��������, out string ���������)
	{
		�������� = �������.Trim();
		��������� = "";
		int ������� = -1;
		for (int i = 0; i < ��������.Length; i++)
		{
			if (��������[i] == ' ' || ��������[i] == �����������)
			{
				������� = i;
				break;
			}
		}
		if (������� != -1)
		{
			��������� = ��������.Substring(�������).Trim();
			�������� = ��������.Substring(0, �������);
		}
	}

	public static string[] ������������������(string ������)
	{
		List<string> ��������� = new List<string>(8);
		StringBuilder �������� = new StringBuilder(64);
		int ���������������� = 0;
		bool ������������������������� = false;
		for (int i = 0; i < ������.Length; i++)
		{
			if (�������������������������)
			{
				��������.Append(������[i]);
				������������������������� = false;
				continue;
			}
			if (������[i] == '\\')
			{
				��������.Append(������[i]);
				������������������������� = true;
				continue;
			}
			if (������[i] == �����������)
			{
				if (���������������� > 0)
				{
					��������.Append(������[i]);
				}
				else if (��������.Length != 0)
				{
					���������.Add(��������.ToString());
					�������� = new StringBuilder(64);
				}
				����������������++;
				continue;
			}
			if (������[i] == ����������)
			{
				����������������--;
				if (���������������� < 0)
				{
					���������������� = 0;
					��������.Append(������[i]);
				}
				else if (���������������� > 0)
				{
					��������.Append(������[i]);
				}
				else
				{
					���������.Add(��������.ToString());
					�������� = new StringBuilder(64);
				}
				continue;
			}
			if (������[i] == ' ')
			{
				if (���������������� > 0)
				{
					��������.Append(������[i]);
				}
				else if (��������.Length != 0)
				{
					���������.Add(��������.ToString());
					�������� = new StringBuilder(64);
				}
				continue;
			}
			��������.Append(������[i]);
		}
		if (��������.Length != 0)
			���������.Add(��������.ToString());
		return ���������.ToArray();
	}

	public static string �������������������(string ������)
	{
		StringBuilder ��������� = new StringBuilder(������.Length);
		bool ������������������������� = false;
		for (int i = 0; i < ������.Length; i++)
		{
			if (�������������������������)
			{
				���������.Append(������[i]);
				������������������������� = false;
				continue;
			}
			if (������[i] == '\\')
			{
				������������������������� = true;
				continue;
			}
			���������.Append(������[i]);
		}
		if (�������������������������)
			���������.Append('\\');
		return ���������.ToString();
	}

	public static bool ��������������(string ������)
	{
		try
		{
			int.Parse(������);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool ���������������(params string[] ������)
	{
		foreach (string ������ in ������)
		{
			if (!��������������(������))
				return false;
		}
		return true;
	}
}
