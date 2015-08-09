/*
	��������� � ������� Windows GDI
*/


using System;
using System.Drawing;
using System.Runtime.InteropServices;


class �������
{
	const string �������������� = "Fixedsys";

	public const int ������������� = 16;
	public const int ������������� = 8;

	static readonly uint[] ����� = new uint[16]
	{
		//BBGGRR
		0x000000,
		0x0000C0,
		0x00C000,
		0x00C0C0,
		0xC00000,
		0xC000C0,
		0xC0C000,
		0xC0C0C0,
		0x808080,
		0x0000FF,
		0x00FF00,
		0x00FFFF,
		0xFF0000,
		0xFF00FF,
		0xFFFF00,
		0xFFFFFF,
	};

	[DllImport("Gdi32.dll")]
	static extern IntPtr CreateFont(int height, int width, int escapement, int orientation, int weight, uint italic, uint underline, uint strikeout, uint charSet, uint outputPrecision, uint clipPrecision, uint quality, uint pitchAndFamily, string face);

	[DllImport("Gdi32.dll")]
	static extern IntPtr SelectObject(IntPtr hdc, IntPtr obj);

	[DllImport("Gdi32.dll")]
	static extern bool DeleteObject(IntPtr obj);

	[DllImport("Gdi32.dll")]
	static extern uint SetTextColor(IntPtr hdc, uint color);

	[DllImport("Gdi32.dll")]
	static extern uint SetBkColor(IntPtr hdc, uint color);

	[DllImport("Gdi32.dll")]
	static extern bool TextOut(IntPtr hdc, int x, int y, string str, int len);

	[DllImport("Gdi32.dll")]
	static extern IntPtr CreateSolidBrush(uint color);

	[DllImport("User32.dll")]
	static extern int FillRect(IntPtr hdc, ref Rect rect, IntPtr brush);

	[DllImport("User32.dll")]
	static extern bool InvertRect(IntPtr hdc, ref Rect rect);

	IntPtr ������������ = CreateSolidBrush(0);
	IntPtr ����� = CreateFont(�������������, �������������, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ��������������);

	~�������()
	{
		DeleteObject(������������);
		DeleteObject(�����);
	}

	Graphics ������� = null;
	IntPtr hdc = IntPtr.Zero;
	IntPtr ������������� = IntPtr.Zero;

	public void ���������������(Graphics �������)
	{
		this.������� = �������;
		hdc = �������.GetHdc();
		������������� = SelectObject(hdc, �����);
	}

	public void ������������������()
	{
		SelectObject(hdc, �������������);
		�������.ReleaseHdc(hdc);
		������� = null;
		hdc = IntPtr.Zero;
		������������� = IntPtr.Zero;
	}

	public void ����������������(string ��������, byte ����, int x, int y)
	{
		int ������������������ = ���� & 0x0F;
		int �������� = ���� >> 4;
		SetTextColor(hdc, �����[������������������]);
		SetBkColor(hdc, �����[��������]);
		TextOut(hdc, x, y, ��������, ��������.Length);
	}

	public void ��������������������������(int x, int y, int ������, int ������)
	{
		Rect rect = new Rect(x, y, x + ������, y + ������);
		InvertRect(hdc, ref rect);
	}

	public void ����������������������(int x, int y, int ������, int ������)
	{
		Rect rect = new Rect(x, y, x + ������, y + ������);
		FillRect(hdc, ref rect, ������������);
	}
}
