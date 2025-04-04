namespace PicPay.Simplificado.Application.Exceptions
{
    public class CNPJDuplicadoException : Exception
    {
        public CNPJDuplicadoException()
            : base("CNPJ já cadastrado.")
        {
        }

        public CNPJDuplicadoException(string message)
            : base(message)
        {
        }
    }
}