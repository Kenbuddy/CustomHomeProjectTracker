namespace DesignTechHomesTest.Models
{
    public class ErrorViewModel
    {
        #region Properties

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? ErrorMessage { get; set; }

        #endregion

        #region Constructor

        public ErrorViewModel() {}

        public ErrorViewModel(string? requestId, string? message)
        {
            RequestId = requestId;
            ErrorMessage = message;
        }

        #endregion
    }
}
