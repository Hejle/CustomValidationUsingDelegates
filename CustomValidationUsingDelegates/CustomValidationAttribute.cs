using System.ComponentModel.DataAnnotations;

namespace CustomValidationUsingDelegates;

public class CustomValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        
        if (validationContext.ObjectInstance is ICustomValidationField {CustomValidationRules: { }} customValidationField)
        {
            if (customValidationField.CustomValidationRules.Any(validationRule => !validationRule.Invoke(value)))
            {
                return new ValidationResult(
                    $"{validationContext.DisplayName} could not be validated with custom rules");
            }
        }
        return ValidationResult.Success;
    }
}