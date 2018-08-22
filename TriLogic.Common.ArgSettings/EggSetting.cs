using System;
using System.Collections.Generic;
using System.Text;

namespace Trilogic.Common.Settings
{
    public class ArgSetting: AppSetting
    {
        internal ArgSetting(string[] arg)
        {
            if (arg==null || arg.Length < 1)
                throw new ArgException("invalid arg array");

            Key = arg[0];

            if (string.IsNullOrEmpty(key))
                throw new ArgException("invalid arg array");

            if (arg.Length > 1)
                Value = arg[1];
        }

        internal ArgSetting(string key, string value)
            : base(key,value)
        {
        }
    }
}
