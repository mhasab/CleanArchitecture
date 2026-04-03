namespace Application.Features.Leave.Common.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; } = true;

        public string? Message { get; set; }

        public List<string> Errors { get; set; } = new();

        public void AddError(string error)
        {
            IsValid = false;
            Errors.Add(error);
        }
    }
}