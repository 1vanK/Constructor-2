using System.Text.RegularExpressions;


class ���� : �����������
{
	public override bool ������������������������(������� �������, bool ctrl, bool alt, bool shift)
	{
		return base.������������������������(�������, ctrl, alt, shift);
	}

	public override string ����������������(������ ������, bool ���������������)
	{
		Match match;
		string �������� = ������.ToString();
		if (��������.StartsWith("�������� ������ � �����"))
		{
			�������������.��������(������);
			if (����������["���"] != null)
				return "���� ���;���� ��� ���.����;���� ���.����";
			return null;
		}
		return base.����������������(������, ���������������);
	}

	public override string �����������������(string �������)
	{
		return base.�����������������(�������);
	}
}
