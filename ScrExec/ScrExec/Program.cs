using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrExec
{
    class Program
    {
        static void Main(string[] args)
        {

            // Gather file to exec;
            foreach(string arg in args)
            {
                //Console.WriteLine(arg);
            }
            
            string exeFile;

            if(args.Length >= 1)
            {
                exeFile = args[0];
                ScrollCodeExecutor executor = new ScrollCodeExecutor(exeFile);
                executor.ExecuteAllCode();
            }
            else
            {
                showHelp();
                return;
            }


           


        }

        static void showHelp()
        {
            Console.WriteLine("Use:\n\nScrExec <file>");
        }

     
    }
}
