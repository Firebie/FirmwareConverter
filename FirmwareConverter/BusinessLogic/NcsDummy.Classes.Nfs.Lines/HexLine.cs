using System;
using System.Globalization;

namespace NcsDummy.Classes.Nfs.Lines
{
	public class HexLine : NfsLine
	{
		private bool _checksumchanged;

		private byte[] _crcbytes = new byte[0];

		public override bool ChecksumChanged
		{
			get
			{
				return this._checksumchanged;
			}
		}

		public byte[] CrcBytes
		{
			get
			{
				return this._crcbytes;
			}
		}

		public HexLine(byte[] bytes, long position, int linenr) : base(bytes, position)
		{
			int num = base.Bytes.Length;
			if (num < 11)
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid hexadecimal string length.", linenr, 2));
			}
			num--;
			if (base.Bytes[num] == 10)
			{
				num--;
				if (base.Bytes[num] == 13)
				{
					num--;
				}
			}
			if (num % 2 != 0)
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid hexadecimal string length.", linenr, 2));
			}
			if ((num = num / 2 - 5) < 0)
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid hexadecimal string length.", linenr, 2));
			}
			bool flag = false;
			byte b = 255;
			for (int i = 0; i < num + 5; i++)
			{
				byte b2;
				if (!byte.TryParse(string.Format("{0}{1}", (char)base.Bytes[i * 2 + 1], (char)base.Bytes[i * 2 + 2]), NumberStyles.HexNumber, null, out b2))
				{
					throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid hexadecimal character.", linenr, i * 2 + 2));
				}
				if (i == num + 4)
				{
					b = (byte)~b;
					if (b2 != b)
					{
						this._checksumchanged = true;
						string text = b.ToString("X2");
						base.Bytes[i * 2 + 1] = (byte)text[0];
						base.Bytes[i * 2 + 2] = (byte)text[1];
					}
				}
				else
				{
					if (i == 0 && num != (int)b2)
					{
						throw new Exception(string.Format("Syntax error near line {0}, column {1}. Byte count does not match data length.", linenr, 2));
					}
					b = (byte)((int)(b2 + b) % 256);
					if (i == 3 && (b2 == 0 || b2 == 16))
					{
						flag = true;
						this._crcbytes = new byte[num];
					}
					else if (flag)
					{
						this._crcbytes[i - 4] = b2;
					}
				}
			}
		}
	}
}
