using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolManager
{
	static class GuidList
	{
		public const string guidMySymbolManagerPackageString = "aecebe3c-dd98-4d0a-bb9f-54a5e1b39858";

		public const string guidSymbolManagerPackageCmdSetString = "b0ac23f3-f7de-4267-ac5d-3a4aca3dd993";

		public static Guid guidSymbolManagerPackageCmdSet = new Guid(guidSymbolManagerPackageCmdSetString);
	}
}
