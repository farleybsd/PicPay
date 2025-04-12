namespace PicPay.Simplificado.Service.Validates;

public class AuthorizeSettingsValidate : IValidateOptions<AuthorizeSettings>
{
    public ValidateOptionsResult Validate(string? name, AuthorizeSettings options)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(options.BaseAddress))
            errors.Add("BaseAddress not found");

        return errors.Count > 0 ?
                                ValidateOptionsResult.Fail(string.Join(';', errors))
                                : ValidateOptionsResult.Success;
    }
}