using System.ComponentModel.DataAnnotations;

namespace api.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RequireOneAttribute(params string[] propertyNames): ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var type = validationContext.ObjectType;

        var hasValue = propertyNames.Any(propName =>
        {
            var property = type.GetProperty(propName);
            var propValue = property?.GetValue(validationContext.ObjectInstance) as string;
            return !string.IsNullOrWhiteSpace(propValue);
        });

        if (hasValue)
            return ValidationResult.Success;

        var fields = string.Join(", ", propertyNames);
        return new ValidationResult(
            $"At least one of the following fields is required: {fields}.",
            propertyNames
        );
    }
}