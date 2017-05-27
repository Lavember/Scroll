using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrExec
{
    class ScrollStringConverter
    {
        public string ResultantString(string raw,StringCollection variables)
        {
            string final = raw;

            // Replace \b \n with proper chars.
            final = final.Replace("\\b", "\b");
            final = final.Replace("\\n", "\n");


            // Replace variables.
            foreach(string variable in variables)
            {
                string vname = "", vval = "",vatrb="";
                string[] vArguments = variable.Split(':'); // Split var.name:var.val

                vatrb = variable[variable.Length - 1] == ':' ? ":" : "";


                int vargI = 0;
                foreach(string vArgument in vArguments)
                {
                    if(vargI == 0)
                    {
                        // If index is pointing to the name
                        vname = vArgument;
                    }
                    else
                    {
                        vval += vArgument;
                        if(vargI == vArguments.Length - 1) // If the index is the last.
                        {
                            
                            vval += vatrb;
                        }
                    }

                    vargI++;
                }

                final = final.Replace("$(" + vname + ")", vval);

            }


           
            

            return final;

        }
    }
}
