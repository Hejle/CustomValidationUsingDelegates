namespace CustomValidationUsingDelegates;

public interface ICustomValidationField
{
    Func<object, bool>[] CustomValidationRules { get; set; }
}