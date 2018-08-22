using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Trilogic.Common.Settings 
{
    public class ArgSettings : AppSettings<ArgSetting>
    {
        private static char[] argSplitter = { '=',':' };

        public ArgSettings(Dictionary<string, ArgSetting> storage)
            : base(storage)
        {
            store = storage;
        }

        public ArgSettings()
            : base()
        {
        }

        #region Argument Parsing
        public static ArgSettings ParseSettings(string[] args)
        {
            ArgSettings s = new ArgSettings();
            s.ParseArgs(args);
            return s;
        }

        public void ParseArgs(string[] args)
        {
            string[] arg = new string[2];


            if (store.Count > 0)
                store.Clear();

            if (args == null || args.Length < 1)
                return;

            for (int i = 0; i < args.Length; i++)
            {
                arg[0] = string.Empty;
                arg[1] = string.Empty;

                // locate the first split char (if any)
                int idx = args[i].IndexOfAny(argSplitter);

                if (idx < 0)
                {
                    arg[0] = args[i];
                }
                else if (idx == 0)
                {
                    throw new ArgException("invalid argument key");
                }
                else
                {
                    arg[0] = args[i].Substring(0, idx).TrimEnd();

                    if (idx + 1 < args[0].Length)
                        arg[1] = args[i].Substring(idx + 1).Trim();
                }

                if (arg[0].StartsWith("/") || arg[0].StartsWith("-"))
                {
                    if (arg[0].Length < 2)
                        throw new ArgException("invalid argument");
                    arg[0] = arg[0].Substring(1).TrimEnd();
                }

                ArgSetting s = new ArgSetting(arg);
                store.Add(GetKey(s.Key), s);
            }
        }
        #endregion
    }
}
