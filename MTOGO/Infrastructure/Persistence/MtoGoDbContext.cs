
using Domain.Core.DeliveryManagement;
using Domain.Core.OrderManagement;

using Microsoft.EntityFrameworkCore;
using Domain.Supporting.CustomerManagement;
using Domain.Supporting.RestaurantManagement;
using Domain.Supporting.BonusCalculation;
using Domain.Supporting.AnalyticsAndReporting;
using Domain.Shared.ValueObjects;
using System.Net.NetworkInformation;

namespace Infrastructure.Persistence
{
    public class MtoGoDbContext : DbContext
    {
        
        public DbSet<DeliveryAgent> DeliveryAgents { get; set; }
        public DbSet<DeliveryAssignment> DeliveryAssignments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> payments { get; set; }    
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Bonus> Bonus { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public MtoGoDbContext(DbContextOptions<MtoGoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            // Configure table mappings and relationships if needed
            modelBuilder.Entity<Customer>().ToTable("Customers").OwnsOne(x => x.Address, address =>
            {
                address.Property(a => a.Street).HasColumnName("CustomersStreet");
                address.Property(a => a.PostalCode).HasColumnName("CustomersPostalCode");
                address.Property(a => a.Country).HasColumnName("CustomersCountry");
                address.Property(a => a.City).HasColumnName("CustomersCity");
            });

            modelBuilder.Entity<DeliveryAssignment>().ToTable("DeliveryAssignments").OwnsOne(x => x.Status, status =>
            {
                status.Property(a => a.Status).HasColumnName("DeliveryAssignmentsStatus");
            });

           

            modelBuilder.Entity<Payment>().ToTable("Payment").OwnsOne(x => x.Amount, amount =>
            {
                amount.Property(a => a.Amount).HasColumnName("PaymentAmount");
            });


            modelBuilder.Entity<Bonus>().ToTable("Bonus").OwnsOne(x => x.ApprovalCondition, approvalCondition =>
            {
                approvalCondition.Property(a => a.StartTime).HasColumnName("approvalConditionStartTime");
                approvalCondition.Property(a => a.EndTime).HasColumnName("approvalConditionEndTime");
            });
         
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants");

            // Order
            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.OrderId);  // Primary key
                order.Property(o => o.RestaurantId).IsRequired();
                order.Property(o => o.Status).IsRequired();

                // Configure owned Address value objects for Billing and Shipping
                order.OwnsOne(x => x.TotalAmount, money =>
                {
                    money.Property(a => a.Amount).HasColumnName("OrderAmount");
                    money.Property(a => a.Currency).HasColumnName("OrderCurrency");
                });

                order.OwnsOne(o => o.ShippingAddress, shipping =>
                {
                    shipping.Property(s => s.Street).HasColumnName("ShippingStreet");
                    shipping.Property(s => s.City).HasColumnName("ShippingCity");
                    shipping.Property(s => s.ZipCode).HasColumnName("ShippingZipCode");
                });

                // Configure OrderItems as an owned collection of Order
                order.OwnsMany(o => o.OrderItems, orderItem =>
                {
                    orderItem.WithOwner().HasForeignKey("OrderId");  // Foreign key to Orders table
                    orderItem.Property(i => i.ItemId).HasColumnName("ItemId").IsRequired();
                    orderItem.Property(i => i.Name).HasColumnName("Name").IsRequired();
                    orderItem.Property(i => i.Quantity).HasColumnName("Quantity").IsRequired();

                    // Configure Money as an owned type within OrderItem
                    orderItem.OwnsOne(i => i.UnitPrice, money =>
                    {
                        money.Property(m => m.Amount).HasColumnName("UnitPriceAmount").IsRequired();
                        money.Property(m => m.Currency).HasColumnName("UnitPriceCurrency").IsRequired();
                    });

                    orderItem.ToTable("OrderItems");  // Specify table name for OrderItems
                });
            });


            modelBuilder.Entity<Order>().ToTable("Order").OwnsOne(x => x.TotalAmount, money =>  
            {
                money.Property(a => a.Amount).HasColumnName("OrderAmount");
                money.Property(a => a.Currency).HasColumnName("OrderCurrency");
            });

            modelBuilder.Entity<Order>().ToTable("Order").OwnsOne(x => x.Status, status =>
            {
                status.Property(a => a.Status).HasColumnName("OrderStatus");
            });
            modelBuilder.Entity<Order>().ToTable("Order").OwnsMany(x => x.OrderItems, orderItems =>
            {
               orderItems.Property(a => a.ItemId).HasColumnName("OrderItemId");
               orderItems.Property(a => a.Name).HasColumnName("OrderItemName");
               orderItems.Property(a => a.Quantity).HasColumnName("OrderItemQuantity");
                orderItems.OwnsOne(x => x.UnitPrice, money =>
                {
                    money.Property(a => a.Amount).HasColumnName("OrderItemAmount");
                    money.Property(a => a.Currency).HasColumnName("OrderItemCurrency");
                });

            });
            // without Value Object
            modelBuilder.Entity<DeliveryAgent>().ToTable("DeliveryAssignments");
            modelBuilder.Entity<Dashboard>().ToTable("Dashboard");
        }
    }
}
