namespace CrudOperation.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } = string.Empty; // Or make it nullable if required

        // Add ShowRequestId to determine if the RequestId should be shown in the view
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
