using System.ComponentModel.Composition;
using System.Diagnostics;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;

namespace SymbolManager
{
	[Export(typeof(IVsTextViewCreationListener))]
	[ContentType("text")]
	[TextViewRole(PredefinedTextViewRoles.Editable)]
	internal sealed class SymbolManagerTextAdornmentTextViewCreationListener : IVsTextViewCreationListener
	{
#pragma warning disable 649, 169

		[Import]
		IVsEditorAdaptersFactoryService AdaptersFactory = null;

		[Import]
		private IEditorOperationsFactoryService factory = null;



		public void VsTextViewCreated(IVsTextView textViewAdapter)
		{
			var wpfTextView = AdaptersFactory.GetWpfTextView(textViewAdapter);
			var edit = factory.GetEditorOperations(wpfTextView);
			SymbolManagerCommand filter = new SymbolManagerCommand(wpfTextView, edit);
			IOleCommandTarget next;
			if (ErrorHandler.Succeeded(textViewAdapter.AddCommandFilter(filter, out next)))
				filter.Next = next;
		}


	}
}
