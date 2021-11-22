// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using CustomValidationUsingDelegates;

var imageType = new ImageType
{
    Value = "Face",
    CustomValidationRules = new Func<object, bool>[] {ImageMustBeFace}
};

var validationContext = new ValidationContext(imageType);
var validationResults = new List<ValidationResult>();
var isValid = Validator.TryValidateObject(imageType, validationContext, validationResults, true);

Console.WriteLine(isValid ? "Success" : "Failure");

static bool ImageMustBeFace(object inputObject)
{
    return inputObject is string and "Face";
}