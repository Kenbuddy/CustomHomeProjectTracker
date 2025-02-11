using DesignTechHomesTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DesignTechHomesTest.Utilities
{
    public class LogHelper<T>
    {
        #region Properties

        public ILogger<T> Logger { get; }

        #endregion

        #region Constructors

        public LogHelper(ILogger<T> logger)
        {
            Logger = logger;
        }

        #endregion

        #region Methods

        public IActionResult LogErrorAndRedirectToErrorPage(Exception ex, string userFriendlyMessage, string? requestId = null)
        {
            var processedMessage = ProcessMessage(userFriendlyMessage, requestId);
            Logger.LogError(ex, processedMessage);

            var errorModel = new ErrorViewModel
            {
                RequestId = requestId,
                ErrorMessage = userFriendlyMessage
            };

            return new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<ErrorViewModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = errorModel
                }
            };
        }

        #endregion

        #region Private Methods

        private string ProcessMessage(string userFriendlyMessage, string? requestId)
        {
            userFriendlyMessage = userFriendlyMessage ?? string.Empty;
            requestId = requestId ?? string.Empty;

            //if (userFriendlyMessage != string.Empty) userFriendlyMessage = $"Message: {userFriendlyMessage}";
            if (requestId != string.Empty) userFriendlyMessage = $"Request ID: {requestId}  Message: {userFriendlyMessage}";

            return userFriendlyMessage;
        }

        #endregion
    }
}

