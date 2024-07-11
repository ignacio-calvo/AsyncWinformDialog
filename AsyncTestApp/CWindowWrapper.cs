using System;
using System.Windows.Forms;

public class CWindowWrapper : IWin32Window
{
    private IntPtr _hwnd;

    public CWindowWrapper(IntPtr handle)
    {
        _hwnd = handle;
    }

    public IntPtr Handle => _hwnd;
}
