using System;
using System.Windows.Forms;
using WinForms;

namespace Project.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}