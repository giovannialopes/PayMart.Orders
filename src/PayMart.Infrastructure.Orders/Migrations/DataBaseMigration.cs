using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PayMart.Infrastructure.Orders.DataAcess;

namespace PayMart.Infrastructure.Orders.Migrations;

public class DataBaseMigration
{
    public async static Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var db = serviceProvider.GetRequiredService<DbOrder>();

        await db.Database.MigrateAsync();

    }
}
