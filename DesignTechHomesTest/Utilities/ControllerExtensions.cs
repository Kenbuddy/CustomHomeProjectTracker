using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesignTechHomesTest.Utilities
{
    public static class ControllerExtensions
    {
        public static string GetRequestId(this ControllerBase controller)
        {
            return Activity.Current?.Id ?? controller.HttpContext.TraceIdentifier;
        }

    }
}