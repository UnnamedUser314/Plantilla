﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models.Entity;

namespace RestAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //Add models here
        public DbSet<DicatadorEntity> Dictadors { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ProductoEntity> Productos { get; set; }
        public DbSet<PedidoEntity> Pedidos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
