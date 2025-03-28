namespace PicPay.Simplificado.Infrastructure.Data.Context
{
    public class PicPaySimplificadoContextFactory : IDesignTimeDbContextFactory<PicPaySimplificadoContext>
    {
        public PicPaySimplificadoContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../PicPay.Simplificado.Api");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PicPaySimplificadoContext>();

            var connectionString = configuration.GetConnectionString("Picpay");

            optionsBuilder.UseSqlServer(connectionString);

            return new PicPaySimplificadoContext(optionsBuilder.Options);
        }
    }
}