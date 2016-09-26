using System;

namespace NcsDummy.Classes.Checksums
{
	public class Mod36
	{
		public const int BSU_REFERENZ_NEW = 31;

		public const int BSUTIME = -10;

		public const int CARB_MODE_9_CVN = 4;

		public const int CHECKSUMME = 27;

		public const int FG = 34;

		public const int GM = 1;

		public const int NUMBER_UNUSED_BYTE = 15;

		public const int REFERENZ = 29;

		public const int SA = 2;

		public const int VALUE_UNUSED_BYTE = 34;

		public const int VN = 3;

		public static char Parse(string text, int offset)
		{
			bool flag = offset < 0;
			if (flag)
			{
				offset *= -1;
			}
			int num = offset;
			for (int i = 0; i < text.Length; i++)
			{
				num += Mod36.CharacterToValue(text[i]) * ((i % 2 == 0 ^ flag) ? 3 : 1);
			}
			num %= 36;
			return Mod36.ValueToCharacter(num);
		}

		public static bool TryParse(string text, int offset, out char character)
		{
			character = '\0';
			bool result;
			try
			{
				character = Mod36.Parse(text, offset);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private static int CharacterToValue(char character)
		{
			if (character >= '0' && character <= '9')
			{
				return (int)(character - '0');
			}
			if (character >= 'A' && character <= 'Z')
			{
				return (int)(character - '7');
			}
			if (character >= 'a' && character <= 'z')
			{
				return (int)(character - 'W');
			}
			throw new Exception("Invalid character for checksum calculation.");
		}

		private static char ValueToCharacter(int value)
		{
			if (value >= 0 && value <= 9)
			{
				return (char)(value + 48);
			}
			if (value >= 10 && value <= 35)
			{
				return (char)(value + 55);
			}
			throw new Exception("Invalid value for checksum calculation.");
		}
	}
}
