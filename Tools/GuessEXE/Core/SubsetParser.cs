using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace GuessEXE.Core
{
    class SubsetParser
    {
        List<string[]> defs = new List<string[]>();

        public SubsetParser(string prefix, TextReader tr)
        {
            string line;
            while ((line = tr.ReadLine()) != null)
            {
                if (line.StartsWith(prefix))
                {
                    string[] l = line.Substring(prefix.Length).Split(',');
                    defs.Add(l);
                }
            }
            tr.Close();
        }

        public List<string> parse(string mainKey, string[] entries)
        {
            List<string> result = new List<string>();
            foreach (string[] def in defs)
            {
                string m = def[1];
                bool final = false, sub = false, super = false, match = false;
                if (m.StartsWith("!"))
                {
                    final = true;
                    m = m.Substring(1);
                }
                switch (m[0])
                {
                    case '>': super = true; break;
                    case '<': sub = true; break;
                    case '~': match = true; super = true; sub = true; break;
                    case '=': break;
                    default:
                        throw new Exception("Unparsable definition: " + def[1]);
                }
                if (new Regex("^"+m.Substring(1)+"$").IsMatch(mainKey))
                {
                    bool isSub=false, isSuper = false, isMatch=false;
                    for (int i = 2; i < def.Length; i++)
                    {
                        bool found = false;
                        for (int j = 0; j < entries.Length; j++)
                        {
                            if (new Regex("^" + def[i] + "$").IsMatch(entries[j])) found = true;
                        }
                        if (!found)
                        {
                            isSub = true;
                        } else {
                            isMatch = true;
                        }
                    }
                    for(int i=0; i< entries.Length; i++) {
                        bool found = false;
                        for (int j = 2; j < def.Length; j++)
                        {
                            if (new Regex("^" + def[j] + "$").IsMatch(entries[i])) found = true;
                        }
                        if (!found) {
                            isSuper = true;
                        } else {
                            isMatch = true;
                        }
                    }
                    // if superset and subset, it is wrong

                    if (isMatch || !match)
                    {
                        if (super || !isSuper)
                        {
                            if (sub || !isSub)
                            {
                                result.Add(def[0]);
                                if (final) break;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
