using System;
using System.IO;
using System.Text;

namespace NcsDummy.Classes.Nfs.Lines
{
	public abstract class NfsLine
	{
		private byte[] _bytes;

		private long _position;

		protected byte[] Bytes
		{
			get
			{
				return this._bytes;
			}
		}

		private long Position
		{
			get
			{
				return this._position;
			}
		}

		public abstract bool ChecksumChanged
		{
			get;
		}

		public NfsLine(byte[] bytes, long position)
		{
			this._bytes = bytes;
			this._position = position - (long)bytes.Length;
		}

		public void Write(Stream stream)
		{
			long position = stream.Position;
			if (stream.Position != this.Position)
			{
				stream.Position = this.Position;
			}
			stream.Write(this.Bytes, 0, this.Bytes.Length);
			if (stream.Position != position)
			{
				stream.Position = position;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.Bytes.Length; i++)
			{
				stringBuilder.Append((char)this.Bytes[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
