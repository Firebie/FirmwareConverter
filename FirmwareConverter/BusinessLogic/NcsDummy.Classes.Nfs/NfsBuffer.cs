using System;

namespace NcsDummy.Classes.Nfs
{
	public class NfsBuffer
	{
		private byte[] _bytes;

		private int _index;

		public NfsBuffer()
		{
			this._bytes = new byte[1024];
			this._index = 0;
		}

		public bool Read(byte character)
		{
			if (this._index >= this._bytes.Length)
			{
				throw new Exception("Not a valid NFS file.");
			}
			this._bytes[this._index] = character;
			this._index++;
			return character == 10;
		}

		public void Clear()
		{
			this._index = 0;
		}

		public byte[] GetBytes()
		{
			byte[] array = new byte[this._index];
			Array.Copy(this._bytes, array, this._index);
			return array;
		}
	}
}
