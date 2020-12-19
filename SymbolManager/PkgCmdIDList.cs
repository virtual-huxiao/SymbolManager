using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolManager
{
	static class PkgCmdIDList
	{
		public const uint addSemicolonAtEndOfLineID    = 0x1100; //向行添加分号
		public const uint addSemicolonThenToNextLineID = 0x1101; //插入分号并换行
		public const uint addBrace4JSStandardID        = 0x1102; //实现插入{},但是{与插入行同行
		public const uint addBrace4CPPStandardID       = 0x1103; //实现插入{},{和}各占新的一行

		public const uint insertPlusID                 = 0x1104; //实现插入+
		public const uint insertMinusID                = 0x1105; //实现插入-
		public const uint insertMultipliedID           = 0x1106; //实现插入*
		public const uint insertDividedID              = 0x1107; //实现插入/
		public const uint insertEqualID                = 0x1108; //实现插入=
		public const uint insertPerCentID              = 0x1109; //实现插入%
		public const uint insertUnderscoreID           = 0x1110; //实现插入_
		public const uint insertAmpersandID            = 0x1111; //实现插入&
		public const uint insertEllipsisID             = 0x1112; //实现插入...
		public const uint insertVerticalBarID          = 0x1113; //实现插入|
		public const uint insertOrID                   = 0x1114; //实现插入||
		public const uint insertAndID                  = 0x1115; //实现插入&&
		public const uint insertXorID                  = 0x1116; //实现插入^
		public const uint insertTildeID                = 0x1117; //实现插入~

	}
}
