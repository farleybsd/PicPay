namespace PicPay.Simplificado.Api.Validators;

public static class SimpleValidator
{
    public static bool TryValidate(object obj, out Dictionary<string, string[]> errors)
    {
        errors = new Dictionary<string, string[]>();

        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(obj);

        bool isValid = Validator.TryValidateObject(obj, context, validationResults, true);

        if (!isValid)
        {
            errors = validationResults
                .GroupBy(v => v.MemberNames.FirstOrDefault() ?? "")
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage ?? "").ToArray()
                );
        }

        return isValid;
    }
}