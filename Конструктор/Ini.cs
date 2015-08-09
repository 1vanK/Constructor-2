/*
	������ � ini-�������
*/


using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


class Ini
{
	[DllImport("Kernel32.dll")]
	static extern bool WritePrivateProfileString(string section, string key, string value, string file);

	[DllImport("Kernel32.dll")]
	static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int maxValueLen, string file);

	static string ������������(string ����)
	{
		if (���� == "" || ���� == null)
			���� = "�����������.ini";
		if (!Path.IsPathRooted(����))
			���� = Path.Combine(Application.StartupPath, ����);
		return ����;
	}

	public static void ���������(string ����, string ������, string ���, string ��������)
	{
		WritePrivateProfileString(������, ���, ��������, ������������(����));
	}

	public static string ���������(string ����, string ������, string ���, string �������������������)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		GetPrivateProfileString(������, ���, �������������������, stringBuilder, stringBuilder.Capacity, ������������(����));
		return stringBuilder.ToString();
	}

	public static void ���������(string ����, string ������, string ���, int ��������)
	{
		���������(����, ������, ���, ��������.ToString());
	}

	public static int ���������(string ����, string ������, string ���, int �������������������)
	{
		string ������ = ���������(����, ������, ���, �������������������.ToString());
		try
		{
			return int.Parse(������);
		}
		catch
		{
			return �������������������;
		}
	}

	public static void ���������(string ����, string ������, string ���, bool ��������)
	{
		���������(����, ������, ���, �������� ? 1 : 0);
	}

	public static bool ���������(string ����, string ������, string ���, bool �������������������)
	{
		int ����� = ���������(����, ������, ���, ������������������� ? 1 : 0);
		return ����� != 0;
	}

	public static void ���������(string ����, string ������, string ���, FormWindowState ��������)
	{
		���������(����, ������, ���, (int)��������);
	}

	public static FormWindowState ���������(string ����, string ������, string ���, FormWindowState �������������������)
	{
		int ����� = ���������(����, ������, ���, (int)�������������������);
		if (����� < 0 || ����� > 2)
			return �������������������;
		return (FormWindowState)�����;
	}
}