namespace PicPay.Simplificado.Domain.ValueObjects;

public class Password
{
    public string PasswordHash { get; private set; }
    public string Salt { get; private set; }

    public Password(string plainPassword)
    {
        Salt = GenerateSalt();
        PasswordHash = HashPassword(plainPassword, Salt);
    }

    private Password()
    { } // Necessário para o EF Core

    private string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    private string HashPassword(string password, string salt)
    {
        using var deriveBytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000);
        return Convert.ToBase64String(deriveBytes.GetBytes(32));
    }

    public bool Verify(string passwordToCheck)
    {
        var hashToCheck = HashPassword(passwordToCheck, Salt);
        return hashToCheck == PasswordHash;
    }
}