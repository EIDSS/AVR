namespace AUM.Administrator
{
  using System;
  using System.ComponentModel;
  using System.Runtime.InteropServices;
  using System.Windows.Forms;


  public partial class RichEditWithSmartCursorAndScroll : RichTextBox
  {
    private int m_hScrollPosition;
    private int m_vScrollPosition;
    private int m_currentSelectionStart;
    private int m_currentSelectionLength;
    private const int SbHorz = 0;
    private const int SbVert = 1;

    public RichEditWithSmartCursorAndScroll()
    {
      InitializeComponent();
    }

    [DllImport("user32.dll")]
    private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

    [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
    private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    private static extern int GetScrollPos(IntPtr hwnd, int nBar);

    private void ScrollTo(int scrollBar)
    {
      var position = ChoosePosition(scrollBar);
      SetScrollPos(Handle, scrollBar, position, true);
      PostMessage(Handle, 0x115, 4 + 0x10000*position, 0);
    }

    private int ChoosePosition(int scrollBar)
    {
      switch (scrollBar)
      {
        case SbHorz:
          return m_hScrollPosition;
        case SbVert:
          return m_vScrollPosition;
        default:
          throw new InvalidEnumArgumentException();
      }
    }

    public void RememberCurrentState()
    {
      RememberScrollPositions();
      RememberSelection();    
    }

    public void RestoreState()
    {
      RestoreSelection();
      RestoreScrollPositions();
    }

    private void RestoreScrollPositions()
    {
      if (ScrollBars == RichTextBoxScrollBars.Both
          || ScrollBars == RichTextBoxScrollBars.Horizontal
          || ScrollBars == RichTextBoxScrollBars.ForcedHorizontal)
      {
        ScrollTo(SbHorz);
      }
      if (ScrollBars == RichTextBoxScrollBars.Both
          || ScrollBars == RichTextBoxScrollBars.Vertical
          || ScrollBars == RichTextBoxScrollBars.ForcedVertical)
      {
        ScrollTo(SbVert);
      }
    }

    private void RestoreSelection()
    {
      SelectionStart = m_currentSelectionStart;
      SelectionLength = m_currentSelectionLength;
    }

    private void RememberSelection()
    {
      m_currentSelectionStart = SelectionStart;
      m_currentSelectionLength = SelectionLength;
    }

    private void RememberScrollPositions()
    {
      if (ScrollBars == RichTextBoxScrollBars.Both
          || ScrollBars == RichTextBoxScrollBars.Horizontal
          || ScrollBars == RichTextBoxScrollBars.ForcedHorizontal)
      {
        m_hScrollPosition = GetScrollPos(Handle, SbHorz);
      }
      if (ScrollBars == RichTextBoxScrollBars.Both
          || ScrollBars == RichTextBoxScrollBars.Vertical
          || ScrollBars == RichTextBoxScrollBars.ForcedVertical)
      {
        m_vScrollPosition = GetScrollPos(Handle, SbVert);
      }
    }
  }
}
