using Microsoft.EntityFrameworkCore;

namespace JWork.UI.Administracion.DataBase.Models
{
   public class DatabaseInicializar
    {
        private readonly JWorkContext _context;
        public DatabaseInicializar(JWorkContext context)
        {
            _context = context;
        }

        public async Task InitializarAsync()
        {
            try
            {
                var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    Console.WriteLine("Migraciones pendientes:");
                    foreach (var migration in pendingMigrations)
                    {
                        Console.WriteLine($"- {migration}");
                    }

                    await _context.Database.MigrateAsync();  // Aplicar las migraciones
                }
                else
                {
                    Console.WriteLine("No hay migraciones pendientes.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error aplicando las migraciones: {ex.Message}");
            }
        }

    }
}
