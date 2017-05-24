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
            for(int i = 0; i < variables.Count; i++)
            {
                string vname = "",vval="", cvar = variables[i];

                for(int x = 0; x < cvar.Split(':').Length; i++)
                {
                    if (x == 0)
                    {
                        vname = cvar.Split(':')[0];
                    } else if (x > 0)
                    {
                        string apnd_ = "";

                        try
                        {
                            if(cvar.Split(':')[cvar.Split(':').Length-1] == ":" && x ==cvar.Split(':').Length - 1)
                            {
                                apnd_ = ":";
                            }
                        }
                        catch
                        {

                        }


                        vval += cvar.Split(':')[x] + apnd_;
                    }

                }



                if (raw.Contains("$(" + vname+")"))
                {

                    raw.Replace("$(" + vname + ")",vval);
                }
            }


           
            

            return final;

        }
    }
}
