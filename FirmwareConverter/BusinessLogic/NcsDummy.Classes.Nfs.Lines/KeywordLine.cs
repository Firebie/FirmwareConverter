using NcsDummy.Classes.Checksums;
using System;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace NcsDummy.Classes.Nfs.Lines
{
	public class KeywordLine : NfsLine
	{
		private bool _checksumchanged;

		private string _keyword;

		private string _value;

		private int _valueposition;

		private int _checksumposition;

		public override bool ChecksumChanged
		{
			get
			{
				return this._checksumchanged;
			}
		}

		private string Keyword
		{
			get
			{
				return this._keyword;
			}
		}

		private string Value
		{
			get
			{
				return this._value;
			}
		}

		private int ValuePosition
		{
			get
			{
				return this._valueposition;
			}
		}

		private int ChecksumPosition
		{
			get
			{
				return this._checksumposition;
			}
		}

		public KeywordLine(byte[] bytes, long position, int linenr) : base(bytes, position)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = new string[3];
			int[] array2 = new int[3];
			array2[0] = 1;
			int[] array3 = array2;
			int num = 0;
			bool flag = false;
			for (int i = 1; i < base.Bytes.Length; i++)
			{
				if (base.Bytes[i] == 32 || base.Bytes[i] == 9 || base.Bytes[i] == 13 || base.Bytes[i] == 10)
				{
					if (!flag && i != 1)
					{
						array[num] = stringBuilder.ToString().Trim();
						stringBuilder = new StringBuilder();
						num++;
					}
					flag = true;
				}
				else
				{
					if (num > 2)
					{
						throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid number of fields.", linenr, i + 1));
					}
					if (flag)
					{
						array3[num] = i;
					}
					flag = false;
					stringBuilder.Append((char)base.Bytes[i]);
				}
			}
			if (array3[2] == 0)
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid number of fields.", linenr, base.Bytes.Length));
			}
			if (array[2] == null)
			{
				array[2] = stringBuilder.ToString().Trim();
			}
			if (array[2].Length != 1)
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid checksum length.", linenr, array3[2] + 1));
			}
			this._keyword = array[0];
			this._value = array[1];
			this._valueposition = array3[1];
			this._checksumposition = array3[2];
			char checksum = this.GetChecksum(this.Keyword, this.Value, linenr);
			if (array[2][0] != checksum)
			{
				this._checksumchanged = true;
				base.Bytes[this.ChecksumPosition] = (byte)checksum;
			}
		}

		public void SetCrc(ushort newcrc, int linenr)
		{
			if (this.Keyword == "CHECKSUMME" && this.Value != null)
			{
				ushort num;
				if (!ushort.TryParse(this.Value, NumberStyles.HexNumber, null, out num))
				{
					throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid checksum.", linenr, this.ValuePosition + 1));
				}
				if (num != newcrc)
				{
					this._checksumchanged = true;
					this._value = newcrc.ToString("X4");
					for (int i = 0; i < this.Value.Length; i++)
					{
						base.Bytes[this.ValuePosition + i] = (byte)this.Value[i];
					}
					base.Bytes[this.ChecksumPosition] = (byte)this.GetChecksum(this.Keyword, this.Value, linenr);
				}
			}
		}

		private char GetChecksum(string keyword, string value, int linenr)
		{
			int offset = 0;
			try
			{
				Mod36 mod = new Mod36();
				FieldInfo field = mod.GetType().GetField(keyword);
				if (field.FieldType == typeof(int))
				{
					offset = (int)field.GetValue(mod);
				}
			}
			catch
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Unknown keyword ({2}).", linenr, 2, keyword));
			}
			char result;
			if (!Mod36.TryParse(value, offset, out result))
			{
				throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid field character.", linenr, this.ValuePosition + 1));
			}
			return result;
		}
	}
}
