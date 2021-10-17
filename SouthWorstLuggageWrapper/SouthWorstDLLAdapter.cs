using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SouthWorstLuggageWrapper
{
    public static class SouthWorstDLLAdapter
    {
        
        // Import the libc and define the method to represent the native function.
        //[DllImport("SouthWorstLuggageEstimationLibrary.dll")]
        //private static extern int AddTwoNumbers(int one, int two);

        [DllImport("SouthWorstLuggageEstimationLibrary.dll", EntryPoint = "MyPrint")]
        static extern void MyPrint(string message);

        // Implement the above DirClbk delegate;
        // this one just prints out the filename that is passed to it.
        public static int DisplayEntry()
        {
            MyPrint("Hello World C# => C++");
            return 0;
        }

    }
}
