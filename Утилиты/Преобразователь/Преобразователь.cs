/*
	������� ��� �������������� ����� � HTML � ������� �� �� �������� ����� � ����
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Sequential)]
public class Win32FindData 
{
	public uint FileAttributes = 0;
	public uint CreationTime_LowDateTime = 0;
	public uint CreationTime_HighDateTime = 0;
	public uint LastAccessTime_LowDateTime = 0;
	public uint LastAccessTime_HighDateTime = 0;
	public uint LastWriteTime_LowDateTime = 0;
	public uint LastWriteTime_HighDateTime = 0;
	public uint FileSizeHigh = 0;
	public uint FileSizeLow = 0;
	public uint Reserved0 = 0;
	public uint Reserved1 = 0;
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string FileName = null;
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
	public string AlternateFileName = null;
}


static class ���������������
{
	static readonly Encoding ��������� = Encoding.GetEncoding(1251);

	[DllImport("Kernel32.dll")]
	static extern IntPtr FindFirstFile(string fileName, [In, Out] Win32FindData findFileData);

	[DllImport("Kernel32.dll")]
	static extern bool FindNextFile(IntPtr findFile, [In, Out] Win32FindData findFileData);

	[DllImport("Kernel32.dll")]
	static extern bool FindClose(IntPtr findFile);

	static string[] ����������(string �����)
	{
		string ����;
		try
		{
			���� = Path.GetDirectoryName(�����);
		}
		catch
		{
			return new string[0];
		}
		Win32FindData fd = new Win32FindData();
		IntPtr handle = FindFirstFile(�����, fd);
		if (handle == new IntPtr(-1))
			return new string[0];
		List<string> ����� = new List<string>();
		while (true)
		{
			�����.Add(Path.Combine(����, fd.FileName));
			if (!FindNextFile(handle, fd))
				break;
		}
		FindClose(handle);
		return �����.ToArray();
	}

	static void �����������(string ����)
	{
		Console.WriteLine("����: " + ����);
		StreamWriter sw = null;
		try
		{
			string[] ����� = File.ReadAllLines(����, ���������);
			int i = 1;
			while(true)
			{
				string �������� = ���� + ".old";
				if (i != 1)
					�������� += i;
				if (!File.Exists(��������))
				{
					File.Move(����, ��������);
					break;
				}
				i++;
			}
			sw = new StreamWriter(����, false, ���������);
			for (i = 0; i < �����.Length; i++)
			{
				string ����� = �����[i];
				����� = Regex.Replace(�����, @"^[\da-fA-F]{4} ", "");
				����� = Regex.Replace(�����, @"\u001B[\da-fA-F]{2}", "");
				sw.WriteLine(�����);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		if (sw != null)
			sw.Close();
	}

	static void ����������������(string ����)
	{
		Console.WriteLine("����: " + ����);
		StreamWriter sw = null;
		try
		{
			string[] ����� = File.ReadAllLines(����, ���������);
			���� = Path.Combine(Path.GetDirectoryName(����), Path.GetFileNameWithoutExtension(����));
			string ���������;
			int i = 1;
			while(true)
			{
				��������� = ����;
				if (i != 1)
					��������� += " (" + i + ")";
				��������� += ".htm";
				if (!File.Exists(���������))
					break;
				i++;
			}
			sw = new StreamWriter(���������, false, ���������);
			sw.WriteLine("<html><head>");
			sw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">");
			sw.WriteLine("<link href=\"mystyles.css\" rel=\"stylesheet\" type=\"text/css\">");
			sw.Write("</head><body><pre><a class=07>");
			for (i = 0; i < �����.Length; i++)
			{
				string ����� = �����[i];
				����� = �����.Replace("&", "&amp;");
				����� = �����.Replace("<", "&lt;");
				����� = �����.Replace(">", "&gt;");
				����� = �����.Replace("\"", "&quot;");
				����� = Regex.Replace(�����, @"^[\da-fA-F]{4} ", "");
				����� = Regex.Replace(�����, @"\u001B([\da-fA-F]{2})", "</a><a class=$1>");
				sw.WriteLine(�����);
			}
			sw.WriteLine("</a></pre></body></html>");
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		if (sw != null)
			sw.Close();
	}

	static void Main(string[] ���������)
	{
		if (���������.Length < 2 || (���������[0] != "�" && ���������[0] != "�" && ���������[0] != "�" && ���������[0] != "�"))
		{
			Console.WriteLine("������� ��� �������������� ����� � HTML � ������� �� �� �������� ����� � ����");
			Console.WriteLine("������� ������ ��� HTML ����� ������� � ������� ��������� �����");
			Console.WriteLine();
			Console.WriteLine("�������������:");
			Console.WriteLine("    ���������������.exe <�|�|?> <����� ������>[ <����� ������>[ ...]]");
			Console.WriteLine("    � - �������������� ����� � HTML");
			Console.WriteLine("    � - ������� �����");
			Console.WriteLine("    ? - ����� ���� �������");
			Console.WriteLine();
			Console.WriteLine("����������:");
			Console.WriteLine("    ���� � ����� ������� �������, ��������� �� � �������");
			Console.WriteLine();
			Console.WriteLine("�������:");
			Console.WriteLine("    ���������������.exe � *.txt");
			Console.WriteLine("    ���������������.exe � ������.txt C:\\����\\*.txt");
			Console.WriteLine("    ���������������.exe � \"D:\\��� ����\\*.txt\" C:/�������/*.txt");
			Console.WriteLine("    ���������������.exe � \"����� 2007.01.*.*\"");
			return;
		}
		for (int i = 1; i < ���������.Length; i++)
		{
			Console.WriteLine("�����: " + ���������[i]);
			string[] ����� = ����������(���������[i]);
			if (�����.Length == 0)
			{
				Console.WriteLine("�� ������� �� ������ �����, ���������������� ���� �����.");
				continue;
			}
			if (���������[0] == "�" || ���������[0] == "�")
			{
				foreach (string ���� in �����)
					����������������(����);
			}
			else
			{
				foreach (string ���� in �����)
					�����������(����);
			}
		}
	}
}
