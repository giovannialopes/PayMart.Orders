using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Orders.Entities;

namespace PayMart.Infrastructure.Orders.DataAcess;

public class DbOrder : DbContext
{
    public DbOrder(DbContextOptions options) : base(options) { }

    public DbSet<Order> Tb_Order { get; set; }

}
