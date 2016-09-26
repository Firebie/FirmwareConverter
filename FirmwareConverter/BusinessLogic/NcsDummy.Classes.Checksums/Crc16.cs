using System;

namespace NcsDummy.Classes.Checksums
{
	public class Crc16
	{
		private const ushort POLYNOMIAL = 40961;

		private ushort[] _crctable = new ushort[256];

		private ushort[] CrcTable
		{
			get
			{
				return this._crctable;
			}
		}

		public Crc16()
		{
			this.CreateCrcTable();
		}

		private void CreateCrcTable()
		{
			ushort num = 0;
			while ((int)num < this.CrcTable.Length)
			{
				ushort num2 = 0;
				ushort num3 = num;
				for (byte b = 0; b < 8; b += 1)
				{
					if (((num2 ^ num3) & 1) != 0)
					{
						num2 = (ushort)(num2 >> 1 ^ 40961);
					}
					else
					{
						num2 = (ushort)(num2 >> 1);
					}
					num3 = (ushort)(num3 >> 1);
				}
				this.CrcTable[(int)num] = num2;
				num += 1;
			}
		}

		public ushort CalculateCrc(byte b, ushort crc)
		{
			byte b2 = (byte)(crc ^ (ushort)b);
			return (ushort)(crc >> 8 ^ (int)this.CrcTable[(int)b2]);
		}

		public ushort CalculateCrc(byte[] bytes, ushort crc)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				crc = this.CalculateCrc(bytes[i], crc);
			}
			return crc;
		}

		public ushort CalculateCrc(byte[] bytes)
		{
			return this.CalculateCrc(bytes, 0);
		}
	}
}
