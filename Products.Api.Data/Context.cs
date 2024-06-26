﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Products.Api.Data.Models;
using Products.Api.Entities;

namespace Products.Api.Data
{
    public class Context : DbContext
    {

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Products.Api.Data.Models.Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=<Your-Server>;Database=Product-mgt-db;User Id=<Your-User>;Password=<Your-Password>;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
            }
        }
    }
}
