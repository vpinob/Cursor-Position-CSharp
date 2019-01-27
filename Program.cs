using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace App
{
    class Program
    {
        //Sets the console show state.
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int Handle, int showState);
        
        //Get console handle
        [DllImport("kernel32.dll")]
        private static extern int GetConsoleWindow();

        //Invokes the method Tick() and continues to invoke it once per timer interval. 
        private static TimerCallback TimerCallback1;
       
        private static int win;
        
        //Timer1
        private static System.Threading.Timer Timer1;

        public static void Main()
        {
            try
            {
                //Hide console
                win = GetConsoleWindow();
                ShowWindow(win, 0);

                TimerCallback1 = new TimerCallback(Tick);
                //Create a 100 mSec Timer tick
                Timer1 = new System.Threading.Timer(TimerCallback1, null, 0, 100);
                //Forever loop
                for (; ; );
                // Collect all generations of memory.
                GC.Collect();
            }
            catch (Exception){ }
        }

        //Set the Cursor in a random position..
        //Get the screen resolution..
        public static void Tick(Object obj)
        {
            Cursor.Position = new Point(new Random().Next() % Screen.PrimaryScreen.Bounds.Width,
                new Random().Next() % Screen.PrimaryScreen.Bounds.Height);
        }
    }
}
