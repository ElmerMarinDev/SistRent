using Microsoft.EntityFrameworkCore;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.DataBase
{
    public class AppDBContext(DbContextOptions<AppDBContext>options):DbContext(options)
    { 

        public DbSet<Contract> Contract { get; set; }     
        public DbSet<ContractStatus> ContractStatus { get; set; }      
        public DbSet<Payment> Payment { get; set; }        
        public DbSet<PaymentMethod> PaymentMethod { get; set; }       
        public DbSet<Property> Property { get; set; }        
        public DbSet<Role> Role { get; set; }        
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; } 
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasKey(u => u.IdUser);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.IdRole);

            modelBuilder.Entity<Property>()
                .HasKey(p => p.IdProperty);

            modelBuilder.Entity<Room>()
                .HasKey(r => r.IdRoom);

            modelBuilder.Entity<RoomType>()
                .HasKey(rt => rt.IdRoomType);

            modelBuilder.Entity<Contract>()
                .HasKey(c => c.IdContract);

            modelBuilder.Entity<ContractStatus>()
                .HasKey(cs => cs.IdContractStatus);

            modelBuilder.Entity<Payment>()
                .HasKey(p => p.IdPayment);

            modelBuilder.Entity<PaymentMethod>()
                .HasKey(pm => pm.IdPaymentMethod);

        }

    }
}
