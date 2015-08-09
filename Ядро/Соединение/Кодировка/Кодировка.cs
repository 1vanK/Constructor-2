/*
	������� ��� �������� ������� �������
*/


using System.Text;
using System.IO;


static class ���������
{
	const int �������������� = 1251;

	static void Main()
	{
		Encoding ��������� = Encoding.GetEncoding(��������������);
		StreamWriter sw = new StreamWriter("Cp" + �������������� + ".txt", false, Encoding.ASCII);
		sw.WriteLine("char[] cp" + �������������� + " = new char[256]");
		sw.WriteLine("{");
		for (int i = 0; i < 16; i++)
		{
			sw.Write("\t");
			for (int j = 0; j < 16; j++)
			{
				byte ���� = (byte)(i * 16 + j);
				char ������ = ���������.GetChars(new byte[] { ���� })[0];
				string ��� = ((int)������).ToString("X4");
				sw.Write("'\\u" + ��� + "',");
				if (j != 15)
					sw.Write(" ");
			}
			sw.WriteLine();
		}
		sw.WriteLine("};");
		sw.Close();
	}
}

