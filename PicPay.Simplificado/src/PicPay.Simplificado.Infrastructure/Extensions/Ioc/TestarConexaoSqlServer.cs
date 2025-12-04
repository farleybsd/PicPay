namespace PicPay.Simplificado.Infrastructure.Extensions.Ioc
{
    public static class TestarConexaoSqlServer
    {
        public static bool Testar(IServiceProvider serviceProvider)
        {
            Console.WriteLine("🔧 [SQL Server] Iniciando teste de conexão...");

            using var scope = serviceProvider.CreateScope();

            try
            {
                var db = scope.ServiceProvider.GetRequiredService<PicPaySimplificadoContext>();

                Console.WriteLine("🔎 [SQL Server] Tentando conectar...");

                bool conectado = db.Database.CanConnect();

                if (conectado)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ [SQL Server] Conexão estabelecida com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ [SQL Server] Falha ao conectar ao banco!");
                    Console.ResetColor();
                }

                return conectado;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ [SQL Server] Erro ao tentar conectar:");
                Console.WriteLine($"Mensagem: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine("➡️ InnerException:");
                    Console.WriteLine(ex.InnerException.Message);
                }

                Console.ResetColor();
                return false;
            }
        }
    }
}
