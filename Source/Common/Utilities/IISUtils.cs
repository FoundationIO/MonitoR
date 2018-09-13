using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
#pragma warning disable S101 // Types should be named in camel case
    public static class IISUtils
#pragma warning restore S101 // Types should be named in camel case
    {
        public static List<string> GetWebsiteList()
        {
            var result = new List<string>();
            var manager = ServerManager.OpenRemote(System.Environment.MachineName);
            foreach (var currentSite in manager.Sites)
            {
                result.Add(currentSite.Name);
            }
            return result;
        }

        public static List<string> GetApplicationPoolList()
        {
            var result = new List<string>();
            var manager = ServerManager.OpenRemote(System.Environment.MachineName);

            foreach (var currentApppPool in manager.ApplicationPools)
            {
                result.Add(currentApppPool.Name);
            }
            return result;
        }
    }
}
