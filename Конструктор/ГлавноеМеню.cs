/*
	������� ���� ����������
*/


using System;
using System.Windows.Forms;


class ����������� : MainMenu
{
	public �����������()
	{
		MenuItem ������� = MenuItems.Add("�������");
		�������.MergeOrder = 0;
		�������.MergeType = MenuMerge.MergeItems;
		MenuItem �������_������� = new MenuItem("�������", new EventHandler(�����������������_�������_�������), Shortcut.CtrlN);
		�������.MenuItems.Add(�������_�������);
		MenuItem �������_������� = new MenuItem("�������", new EventHandler(�����������������_�������_�������), Shortcut.CtrlO);
		�������.MenuItems.Add(�������_�������);
	}

	void �����������������_�������_�������(object sender, EventArgs e)
	{
		�����������.�����������.��������������();
	}

	void �����������������_�������_�������(object sender, EventArgs e)
	{
		�����������.�����������.��������������();
	}
}