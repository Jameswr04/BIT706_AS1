using Assessment_1;
using System;
using System.Windows;


class Program
{
    [STAThread]
    static void Main()
    {
        var app = new Application();
        var mainWindow = new MainWindow();
        app.Run(mainWindow);
    }
}
