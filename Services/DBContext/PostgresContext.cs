using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.DBContext;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChecksEmployee> ChecksEmployees { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountsOrder> DiscountsOrders { get; set; }

    public virtual DbSet<DiscountsProduct> DiscountsProducts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesOrder> EmployeesOrders { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientsProduct> IngredientsProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("amount_type", new[] { "kilo", "liter", "piece" })
            .HasPostgresEnum("dough", new[] { "thick", "middle", "big" })
            .HasPostgresEnum("employee", new[] { "manager", "Technologist", "receiver", "Baker", "courier" })
            .HasPostgresEnum("employee_status", new[] { "work", "fired" })
            .HasPostgresEnum("order_extradition", new[] { "delivery", "pickUp" })
            .HasPostgresEnum("status", new[] { "new", "accepted", "in_work", "done", "in_delivery", "paid" })
            .HasPostgresEnum("work_shift_type", new[] { "5/2", "2/2", "piece-rate" });

        modelBuilder.Entity<ChecksEmployee>(entity =>
        {
            entity.HasKey(e => new { e.Checkid, e.Checkdate }).HasName("checks_employees_pkey");

            entity.ToTable("checks_employees");

            entity.HasIndex(e => e.Checkid, "checks_employees_checkid_key").IsUnique();

            entity.Property(e => e.Checkid)
                .ValueGeneratedOnAdd()
                .HasColumnName("checkid");
            entity.Property(e => e.Checkdate).HasColumnName("checkdate");
            entity.Property(e => e.Absentdays).HasColumnName("absentdays");
            entity.Property(e => e.Changedays).HasColumnName("changedays");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Employeeid)
                .ValueGeneratedOnAdd()
                .HasColumnName("employeeid");
            entity.Property(e => e.Replacementdays).HasColumnName("replacementdays");
            entity.Property(e => e.Salaryperwork)
                .HasColumnType("money")
                .HasColumnName("salaryperwork");
            entity.Property(e => e.Taxfee)
                .HasColumnType("money")
                .HasColumnName("taxfee");
            entity.Property(e => e.Workdays).HasColumnName("workdays");

            entity.HasOne(d => d.Employee).WithMany(p => p.ChecksEmployees)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("checks_employees_employeeid_fkey");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => new { e.Couponid, e.Promocode }).HasName("coupons_pkey");

            entity.ToTable("coupons");

            entity.HasIndex(e => e.Couponid, "coupons_couponid_key").IsUnique();

            entity.HasIndex(e => e.Promocode, "coupons_promocode_key").IsUnique();

            entity.Property(e => e.Couponid)
                .ValueGeneratedOnAdd()
                .HasColumnName("couponid");
            entity.Property(e => e.Promocode).HasColumnName("promocode");
            entity.Property(e => e.Maxuses).HasColumnName("maxuses");
            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnName("userid");
            entity.Property(e => e.Validfrom).HasColumnName("validfrom");
            entity.Property(e => e.Validto).HasColumnName("validto");

            entity.HasOne(d => d.User).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("coupons_userid_fkey");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Discountid).HasName("discounts_pkey");

            entity.ToTable("discounts");

            entity.Property(e => e.Discountid).HasColumnName("discountid");
            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.Discount1)
                .HasColumnType("money")
                .HasColumnName("discount");
            entity.Property(e => e.Validfrom).HasColumnName("validfrom");
            entity.Property(e => e.Validto).HasColumnName("validto");
        });

        modelBuilder.Entity<DiscountsOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discounts_orders_pkey");

            entity.ToTable("discounts_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discountid)
                .ValueGeneratedOnAdd()
                .HasColumnName("discountid");
            entity.Property(e => e.Orderid)
                .ValueGeneratedOnAdd()
                .HasColumnName("orderid");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountsOrders)
                .HasForeignKey(d => d.Discountid)
                .HasConstraintName("discounts_orders_discountid_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.DiscountsOrders)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("discounts_orders_orderid_fkey");
        });

        modelBuilder.Entity<DiscountsProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discounts_products_pkey");

            entity.ToTable("discounts_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discountid)
                .ValueGeneratedOnAdd()
                .HasColumnName("discountid");
            entity.Property(e => e.Productid)
                .ValueGeneratedOnAdd()
                .HasColumnName("productid");
            entity.Property(e => e.Productname).HasColumnName("productname");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountsProducts)
                .HasForeignKey(d => d.Discountid)
                .HasConstraintName("discounts_products_discountid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.DiscountsProductProducts)
                .HasPrincipalKey(p => p.Productid)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("discounts_products_productid_fkey");

            entity.HasOne(d => d.ProductnameNavigation).WithMany(p => p.DiscountsProductProductnameNavigations)
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.Productname)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("discounts_products_productname_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Telephone, "employees_telephone_key").IsUnique();

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Firstworkdate).HasColumnName("firstworkdate");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Lastworkdate).HasColumnName("lastworkdate");
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<EmployeesOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_orders_pkey");

            entity.ToTable("employees_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Employeeid)
                .ValueGeneratedOnAdd()
                .HasColumnName("employeeid");
            entity.Property(e => e.Orderid)
                .ValueGeneratedOnAdd()
                .HasColumnName("orderid");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeesOrders)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("employees_orders_employeeid_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.EmployeesOrders)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employees_orders_orderid_fkey");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Ingredientid).HasName("ingredients_pkey");

            entity.ToTable("ingredients");

            entity.Property(e => e.Ingredientid).HasColumnName("ingredientid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<IngredientsProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredients_products_pkey");

            entity.ToTable("ingredients_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Ingredientid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ingredientid");
            entity.Property(e => e.Productid)
                .ValueGeneratedOnAdd()
                .HasColumnName("productid");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientsProducts)
                .HasForeignKey(d => d.Ingredientid)
                .HasConstraintName("ingredients_products_ingredientid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.IngredientsProducts)
                .HasPrincipalKey(p => p.Productid)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("ingredients_products_productid_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Completingdate).HasColumnName("completingdate");
            entity.Property(e => e.Cost)
                .HasColumnType("money")
                .HasColumnName("cost");
            entity.Property(e => e.Createdate).HasColumnName("createdate");
            entity.Property(e => e.Preparationdate).HasColumnName("preparationdate");
            entity.Property(e => e.Promocode).HasColumnName("promocode");
            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnName("userid");

            entity.HasOne(d => d.PromocodeNavigation).WithMany(p => p.Orders)
                .HasPrincipalKey(p => p.Promocode)
                .HasForeignKey(d => d.Promocode)
                .HasConstraintName("orders_promocode_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("orders_userid_fkey");
        });

        modelBuilder.Entity<OrdersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_products_pkey");

            entity.ToTable("orders_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Orderid)
                .ValueGeneratedOnAdd()
                .HasColumnName("orderid");
            entity.Property(e => e.Productid)
                .ValueGeneratedOnAdd()
                .HasColumnName("productid");
            entity.Property(e => e.Productname).HasColumnName("productname");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersProducts)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("orders_products_orderid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.OrdersProductProducts)
                .HasPrincipalKey(p => p.Productid)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orders_products_productid_fkey");

            entity.HasOne(d => d.ProductnameNavigation).WithMany(p => p.OrdersProductProductnameNavigations)
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.Productname)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orders_products_productname_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => new { e.Productid, e.Name }).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Name, "products_name_key").IsUnique();

            entity.HasIndex(e => e.Productid, "products_productid_key").IsUnique();

            entity.Property(e => e.Productid)
                .ValueGeneratedOnAdd()
                .HasColumnName("productid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "users_phone_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Gamepoints).HasColumnName("gamepoints");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
