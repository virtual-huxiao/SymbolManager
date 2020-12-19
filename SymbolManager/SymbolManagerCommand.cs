using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Operations;

namespace SymbolManager
{
	class SymbolManagerCommand : IOleCommandTarget
	{

		private IWpfTextView m_view;
		//这个是负责编辑文本的功能
		private IEditorOperations m_edit;

		public SymbolManagerCommand(IWpfTextView view, IEditorOperations edit)
		{
			m_view = view;
			m_edit = edit;
		}

		internal IOleCommandTarget Next { get; set; }
		int IOleCommandTarget.QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
		{
			Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
			return Next.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
		}

		//命令触发执行器
		int IOleCommandTarget.Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
		{
			Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
			if (pguidCmdGroup == GuidList.guidSymbolManagerPackageCmdSet)
			{
				switch (nCmdID)
				{
					case PkgCmdIDList.addSemicolonAtEndOfLineID:   //向行添加分号
						addSemicolonAtEndOfLine();
						break;

					case PkgCmdIDList.addSemicolonThenToNextLineID://插入分号并换行
						addSemicolonThenToNextLine();
						break;

					case PkgCmdIDList.addBrace4JSStandardID:       //实现插入{},但是{与插入行同行
						addBrace4JSStandard();
						break;

					case PkgCmdIDList.addBrace4CPPStandardID:      //实现插入{},{和}各占新的一行
						addBrace4CPPStandard();
						break;
						
					case PkgCmdIDList.insertPlusID:	
						insert("+");
						break;

					case PkgCmdIDList.insertMinusID:
						insert("-");
						break;

					case PkgCmdIDList.insertMultipliedID:
						insert("*");
						break;

					case PkgCmdIDList.insertDividedID:
						insert("/");
						break;

					case PkgCmdIDList.insertEqualID:
						insert("=");
						break;

					case PkgCmdIDList.insertPerCentID:
						insert("%");
						break;

					case PkgCmdIDList.insertUnderscoreID:
						insert("_");
						break;

					case PkgCmdIDList.insertAmpersandID:
						insert("&");
						break;

					case PkgCmdIDList.insertEllipsisID:
						insert("...");
						break;

					case PkgCmdIDList.insertVerticalBarID:
						insert("|");
						break;

					case PkgCmdIDList.insertOrID:
						insert("||");
						break;

					case PkgCmdIDList.insertAndID:
						insert("&&");
						break;

					case PkgCmdIDList.insertXorID:
						insert("^");
						break;

					case PkgCmdIDList.insertTildeID:
						insert("~");
						break;

					default:
						return Next.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
				}

				return VSConstants.S_OK;
			}

			return Next.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
		}

		//向行添加分号
		private void addSemicolonAtEndOfLine()
		{
			m_edit.MoveToEndOfLine(false);
			m_edit.InsertText(";");
		}

		//插入分号并换行
		private void addSemicolonThenToNextLine()
		{
			addSemicolonAtEndOfLine();
			m_edit.OpenLineBelow();
		}


		//实现插入{},但是{与插入行同行
		private void addBrace4JSStandard()
		{
			m_edit.MoveToEndOfLine(false);
			m_edit.InsertText("{");
			m_edit.OpenLineBelow();
			m_edit.InsertText("}");
			m_edit.DecreaseLineIndent();
			m_edit.MoveLineUp(false);
			m_edit.MoveToEndOfLine(false);
			m_edit.OpenLineBelow();
		}

		//实现插入{},{和}各占新的一行
		private void addBrace4CPPStandard()
		{
			m_edit.MoveToEndOfLine(false);
			m_edit.OpenLineBelow();
			m_edit.InsertText("{");
			m_edit.DecreaseLineIndent();
			m_edit.OpenLineBelow();
			m_edit.InsertText("}");
			m_edit.DecreaseLineIndent();
			m_edit.OpenLineAbove();

		}

		//插入指定符号
		private void insert(String symbol)
		{
			m_edit.InsertText(symbol);
		}
	}
}
