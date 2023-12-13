using Alena.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<ProductModel> products { get; set; }
    public DbSet<CategoryModel> categories { get; set; }
}

