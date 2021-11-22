using System.ComponentModel.DataAnnotations;

namespace CustomValidationUsingDelegates;

public class ImageTypeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((value as string) is "Face" or "Leg" or "Arm" or "Foot")
        {
            return ValidationResult.Success;
        }
        return new ValidationResult($"{value} in Image Type is neither Face, Leg, Arm or Foot");
    }
}