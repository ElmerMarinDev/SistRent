using Microsoft.EntityFrameworkCore;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.DataBase
{
    public class AppDBContext(DbContextOptions<AppDBContext>options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<ContractStatus> ContractStatus { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

    }
}
