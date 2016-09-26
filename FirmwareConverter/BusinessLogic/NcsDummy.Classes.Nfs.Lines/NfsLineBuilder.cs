using System;

namespace NcsDummy.Classes.Nfs.Lines
{
	public class NfsLineBuilder
	{
		public static NfsLine BuildLine(byte[] bytes, long position, int linenr)
		{
			if (bytes.Length > 0)
			{
				if (bytes[0] == 58)
				{
					return new HexLine(bytes, position, linenr);
				}
				if (bytes[0] == 59 || bytes[0] == 35)
				{
					return new CommentLine(bytes, position, linenr);
				}
				if (bytes[0] == 36)
				{
					return new KeywordLine(bytes, position, linenr);
				}
			}
			throw new Exception(string.Format("Syntax error near line {0}, column {1}. Invalid line start character.", linenr, 1));
		}
	}
}
