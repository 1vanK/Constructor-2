/*
	������������ �����
*/


using System.Net.Sockets;


class ����� : Socket
{
	bool ��������� = false;

	public �����() : base (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
	{
	}

	public bool ���������
	{
		get
		{
			return ���������;
		}
	}

	public void ����������()
	{
		��������� = true;
		Dispose(true);
	}
}
