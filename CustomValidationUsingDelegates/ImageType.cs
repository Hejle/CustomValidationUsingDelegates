using System.ComponentModel.DataAnnotations;

namespace CustomValidationUsingDelegates;

public class ImageType : ICustomValidationField
{
    [Required]
    [CustomValidation]
    public string? Value { get; set; }

    public Func<object, bool>[]? CustomValidationRules { get; set; }
}