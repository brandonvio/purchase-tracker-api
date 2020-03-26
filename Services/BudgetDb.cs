using System;
using Microsoft.EntityFrameworkCore;
using PurchaseTracker.Api.Models;

namespace PurchaseTracker.Api.Services
{
    public class BudgetDb : DbContext
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");

        public BudgetDb(DbContextOptions<BudgetDb> options)
            : base(options)
        {
        }

        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel
                {
                    CategoryId = 1,
                    CategoryName = "Housing"
                },
                new CategoryModel
                {
                    CategoryId = 2,
                    CategoryName = "Transportation"
                },
                new CategoryModel
                {
                    CategoryId = 3,
                    CategoryName = "Food"
                },
                new CategoryModel
                {
                    CategoryId = 4,
                    CategoryName = "Utilities"
                }, new CategoryModel
                {
                    CategoryId = 5,
                    CategoryName = "Medical & Healthcare"
                }, new CategoryModel
                {
                    CategoryId = 6,
                    CategoryName = "Saving, Investing, & Debt Payments"
                }
            );

            modelBuilder.Entity<PurchaseModel>().HasData(
                new PurchaseModel
                {
                    PurchaseId = 1,
                    PurchaseAmount = 99.99M,
                    PurchaseDate = DateTime.Parse("1/1/2020"),
                    Memo = "Less than last month. Yay!",
                    PayeeName = "Electricity Company",
                    CategoryId = 4
                },
                new PurchaseModel
                {
                    PurchaseId = 2,
                    PurchaseAmount = 99.99M,
                    PurchaseDate = DateTime.Parse("2/1/2020"),
                    Memo = "Tacos!",
                    PayeeName = "Fuzzies!",
                    CategoryId = 3
                },
                new PurchaseModel
                {
                    PurchaseId = 3,
                    PurchaseAmount = 1200.00M,
                    PurchaseDate = DateTime.Parse("1/1/2020"),
                    Memo = "Rent.",
                    PayeeName = "Property Mangement Company",
                    CategoryId = 1
                },
                new PurchaseModel
                {
                    PurchaseId = 4,
                    PurchaseAmount = 99.99M,
                    PurchaseDate = DateTime.Parse("1/1/2020"),
                    Memo = "Kid doctor appointment.",
                    PayeeName = "Mercy Hostpital",
                    CategoryId = 5
                }
            );
        }
    }

    
}