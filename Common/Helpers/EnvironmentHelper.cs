using Common.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public class EnvironmentHelper : IEnvironmentHelper
    {
        public string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
