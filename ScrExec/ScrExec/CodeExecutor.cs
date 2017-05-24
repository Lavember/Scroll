using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ScrExec
{
    class ScrollCodeExecutor
    {
        public string ExecutablePath = "If you're seeing this there was something really bad in the code you cheater >:3 ";




        public ScrollCodeExecutor(string file)
        {
            ExecutablePath = file;

        }

        public void ExecuteAllCode()
        {
            try
            {
                string[] lines = File.ReadAllLines(ExecutablePath);
                StringCollection variables = new StringCollection();
                ScrollStringConverter strConvert = new ScrollStringConverter();



                // Preanalyze lines: determine variables, NOT instructions.
                foreach (string line in lines)
                {
                    string[] spaces = line.Split(' ');
                    bool defVAR = false;



                    string varVAL = "";

                    if (spaces.Length > 2)
                    {
                        varVAL = "";
                        for (int i = 3; i < spaces.Length; i++)
                        {
                            varVAL += spaces[i];
                        }
                    }



                    foreach (string space in spaces)
                    {
                        defVAR = (space == "var");

                        if (defVAR == true && spaces.Length > 2)
                        {
                            variables.Add(spaces[1] + ":" + varVAL);
                        }


                    }

                }

                // Run the code
                foreach (string line in lines)
                {
                    // Query for instructions.
                    string[] ssepared = line.Split(' ');

                    for(int i = 0; i < ssepared.Length; i++)
                    {

                        if (i == 0)
                        {
                            if (ssepared[i] == "write")
                            {
                                // Identify the string after the statement.
                                if (ssepared.Length > 1)
                                {
                                    string STR_RAW = "";
                                    for (int x = 1; x < ssepared.Length; x++)
                                    {
                                        STR_RAW += ssepared[x] + " ";
                                    }
                                    string newstring = strConvert.ResultantString(STR_RAW, variables);
                                    Console.WriteLine(newstring);
                                }
                                else
                                {
                                    throw new Exception("write operation without string operation:~~");
                                }

                            } else if(ssepared[i] == "var" || ssepared[i] == "")
                            {

                            }
                            else
                            {
                                throw new Exception("Unknow statement " + ssepared[i]);
                            }
                        }
                        
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("Error :(\nError: " + err.Message);
            }
        }

    }
}
