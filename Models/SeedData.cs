﻿using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                    SeedMembershipTypes(context);

                if (!context.Roles.Any())
                    SeedRoles(context);

                if (!context.Customers.Any())
                    SeedCustomers(userManager);

                if (!context.Genre.Any())
                    SeedGenres(context);

                if (!context.Books.Any())
                    SeedBooks(context);

                private static void SeedBooks(ApplicationDbContext context)
                {
                    context.Books.AddRange(
                        // Generate 10 books with random data for testing purposes 
                        new Book {
                    G
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien"
        
                    );
                }

                private static void SeedGenres(ApplicationDbContext context)
                {
                    context.Genre.AddRange(
                        new Genre
                        {
                            Id = 1,
                            Name = "Romance"
                        },
                        new Genre
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new Genre
                        {
                            Id = 3,
                            Name = "Sci-Fi"
                        },
                        new Genre
                        {
                            Id = 4,
                            Name = "Criminal"
                        },
                        new Genre
                        {
                            Id = 5,
                            Name = "Biography"
                        },
                        new Genre
                        {
                            Id = 6,
                            Name = "Horror"
                        }
                    );
                }

                private static void SeedCustomers(UserManager<Customer> userManager)
                {
                    var hasher = new PasswordHasher<Customer>();

                    var customer1 = new Customer
                    {
                        Name = "Kate Brown",
                        Email = "kate.brown@gmail.com",
                        NormalizedEmail = "kate.brown@gmail.com",
                        UserName = "kate.brown@gmail.com",
                        NormalizedUserName = "kate.brown@gmail.com",
                        MembershipTypeId = 1,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, "test")
                    };


                    userManager.CreateAsync(customer1).Wait();
                    userManager.AddToRoleAsync(customer1, "user").Wait();

                    var customer2 = new Customer
                    {
                        Name = "David Green",
                        Email = "david.green@gmail.com",
                        NormalizedEmail = "david.green@gmail.com",
                        UserName = "david.green@gmail.com",
                        NormalizedUserName = "david.green@gmail.com",
                        MembershipTypeId = 1,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, "test")
                    };


                    userManager.CreateAsync(customer2).Wait();
                    userManager.AddToRoleAsync(customer2, "storemanager").Wait();

                    var customer3 = new Customer
                    {
                        Name = "John Smith",
                        Email = "john.smith@gmail.com",
                        NormalizedEmail = "john.smith@gmail.com",
                        UserName = "john.smith@gmail.com",
                        NormalizedUserName = "john.smith@gmail.com",
                        MembershipTypeId = 1,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, "test")
                    };


                    userManager.CreateAsync(customer3).Wait();
                    userManager.AddToRoleAsync(customer3, "owner").Wait();
                }

                private static void SeedRoles(ApplicationDbContext context)
                {
                    context.Roles.AddRange(
                        new IdentityRole
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "User",
                            NormalizedName = "user"
                        },
                        new IdentityRole
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "StoreManager",
                            NormalizedName = "storemanager"
                        },
                        new IdentityRole
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Owner",
                            NormalizedName = "owner"
                        }
                    );

                    context.SaveChanges();
                }

                private static void SeedMembershipTypes(ApplicationDbContext context)
                {
                    context.MembershipTypes.AddRange(
                        new MembershipType
                        {
                            Id = 1,
                            Name = "Pay as You Go",
                            SignUpFee = 0,
                            DurationInMonths = 0,
                            DiscountRate = 0
                        },
                        new MembershipType
                        {
                            Id = 2,
                            Name = "Monthly",
                            SignUpFee = 30,
                            DurationInMonths = 1,
                            DiscountRate = 10
                        },
                        new MembershipType
                        {
                            Id = 3,
                            Name = "Quaterly",
                            SignUpFee = 90,
                            DurationInMonths = 3,
                            DiscountRate = 15
                        },
                        new MembershipType
                        {
                            Id = 4,
                            Name = "Yearly",
                            SignUpFee = 300,
                            DurationInMonths = 12,
                            DiscountRate = 20
                        }
                    );

                    context.SaveChanges();
                }
        }
    }
}