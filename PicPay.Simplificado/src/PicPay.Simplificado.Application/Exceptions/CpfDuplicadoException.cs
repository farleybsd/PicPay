namespace PicPay.Simplificado.Application.Exceptions
{
    public class CpfDuplicadoException : Exception
    {
        public CpfDuplicadoException()
            : base("CPF já cadastrado.")
        {
        }

        public CpfDuplicadoException(string message)
            : base(message)
        {
        }
    }
}