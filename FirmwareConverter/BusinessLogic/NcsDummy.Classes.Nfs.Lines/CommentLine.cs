using System;

namespace NcsDummy.Classes.Nfs.Lines
{
	public class CommentLine : NfsLine
	{
		public override bool ChecksumChanged
		{
			get
			{
				return false;
			}
		}

		public CommentLine(byte[] bytes, long position, int linenr) : base(bytes, position)
		{
		}
	}
}
