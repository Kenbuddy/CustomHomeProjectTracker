using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesignTechHomesTest.Utilities
{
    public static class DiagnosticUtils
    {
        public static List<string> GetModelStateErrors(ControllerBase controller, string? actionName = null)
        {
            if (controller is null) throw new ArgumentNullException(nameof(controller));

            var modelStateErrors = new List<string>();

            var heading = $"ModelState errors for controller '{controller.GetType()}'";
            if (!string.IsNullOrEmpty(actionName)) heading += $",  Action Name = {actionName}";
            Debug.WriteLine(heading);

            foreach (var key in controller.ModelState.Keys)
            {
                var errors = controller.ModelState[key].Errors;
                foreach (var error in errors)
                {
                    var msg = $"Key: {key}, Error: {error.ErrorMessage}";
                    Debug.WriteLine(msg);
                    modelStateErrors.Add(msg);
                }
            }

            return modelStateErrors;
        }
    }
}
