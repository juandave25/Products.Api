using Microsoft.EntityFrameworkCore;
using Products.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Products.Api.Data
{
    public class Context :DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
