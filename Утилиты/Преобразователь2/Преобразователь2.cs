/*
	��������������� � ����������� �����������
*/


using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


class ���������������2 : Form
{
	static readonly Encoding ��������� = Encoding.GetEncoding(1251);

	ListBox ������ = new ListBox();
	Button �������� = new Button();
	Button ������������� = new Button();
	Button ���������� = new Button();
	ToolTip ��������� = new ToolTip();

	���������������2()
	{
		Text = "��������������� 2";
		TopMost = true;
		ClientSize = new Size(320, 240);
		������.IntegralHeight = false;
		������.AllowDrop = true;
		������.SelectionMode = SelectionMode.MultiExtended;
		��������.Text = "��������";
		�������������.Text = "�������������";
		����������.Text = "�������...";
		������.Parent = this;
		��������.Parent = this;
		�������������.Parent = this;
		����������.Parent = this;
		���������.SetToolTip(������, "������ ������");
		���������.SetToolTip(��������, "������� ����� �� �������� ����� � ����");
		���������.SetToolTip(�������������, "�������������� ����� � HTML");
		���������.SetToolTip(����������, "����������...");
		������.DragOver += new DragEventHandler(������_DragOver);
		������.DragDrop += new DragEventHandler(������_DragDrop);
		������.KeyDown += new KeyEventHandler(������_KeyDown);
		��������.Click += new EventHandler(��������_Click);
		�������������.Click += new EventHandler(�������������_Click);
		����������.Click += new EventHandler(����������_Click);
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
			MessageBox.Show(e.Message);
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
			MessageBox.Show(e.Message);
		}
		if (sw != null)
			sw.Close();
	}

	protected override void OnResize(EventArgs e)
	{
		������.Height = ClientSize.Height - ��������.Height;
		������.Width = ClientSize.Width;
		��������.Top = �������������.Top = ����������.Top = ������.Bottom;
		��������.Width = �������������.Width = ClientSize.Width / 3;
		����������.Width = ClientSize.Width - 2 * ��������.Width;
		�������������.Left = ��������.Right;
		����������.Left = �������������.Right;
	}

	static bool IsFileDrop(IDataObject d)
	{
		foreach (string str in d.GetFormats())
		{
			if (str == DataFormats.FileDrop)
				return true;
		}
		return false;
	}

	void ������_DragOver(object sender, DragEventArgs e)
	{
		e.Effect = IsFileDrop(e.Data) ? DragDropEffects.All : DragDropEffects.None;
	}

	void ����������_Click(object sender, EventArgs e)
	{
		MessageBox.Show
		(
			"������� ��� �������������� ����� � HTML � ������� �� �� �������� ����� � ����\n" +
			"�������������: ���������� ����������� ����� (�����) � ������ � ������� ������ �������� ��� ������ �������������\n\n" +
			"����������:\n" +
			"1) �������� Delete ����� ������� ������ ����� �� ������\n" +
			"2) Web-���������, �������������� ������ ����������, ������� ������� ������ mystyles.css, ������� ����� ������� � ������� ��������� �����",
			"��������������� 2"
		);
	}

	void ��������_Click(object sender, EventArgs e)
	{
		foreach (string path in ������.Items)
			�����������(path);
		������.Items.Clear();
	}

	void �������������_Click(object sender, EventArgs e)
	{
		foreach (string path in ������.Items)
			����������������(path);
		������.Items.Clear();
	}

	void �������������(string �����)
	{
		������.Items.AddRange(Directory.GetFiles(�����));
		string[] subDirs = Directory.GetDirectories(�����);
		foreach (string subDir in subDirs)
			�������������(subDir);
	}

	void ������_DragDrop(object sender, DragEventArgs e)
	{
		string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
		foreach (string path in paths)
		{
			if (File.Exists(path))
				������.Items.Add(path);
			else if(Directory.Exists(path))
				�������������(path);
		}
	}

	void ������_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			object[] selectedItems = new object[������.SelectedItems.Count];
			������.SelectedItems.CopyTo(selectedItems, 0);
			foreach (object obj in selectedItems)
				������.Items.Remove(obj);
		}
	}

	[STAThread]
	static void Main() 
	{
		Application.Run(new ���������������2());
	}
}
