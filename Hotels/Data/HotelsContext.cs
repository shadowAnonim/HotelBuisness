using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Data;

public partial class HotelsContext : DbContext
{
    public HotelsContext()
    {
    }

    public HotelsContext(DbContextOptions<HotelsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arrive> Arrives { get; set; }

    public virtual DbSet<ArrivedGuest> ArrivedGuests { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientType> ClientTypes { get; set; }

    public virtual DbSet<Departure> Departures { get; set; }

    public virtual DbSet<DeparturedGuest> DeparturedGuests { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomPrice> RoomPrices { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=./Data/Hotels");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arrive>(entity =>
        {
            entity.ToTable("Arrive");

            entity.HasIndex(e => e.Id, "IX_Arrive_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("Booking_id");
            entity.Property(e => e.Date).HasColumnType("DATETIME");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Departure_date");
            entity.Property(e => e.RoomId).HasColumnName("Room_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.Arrives).HasForeignKey(d => d.BookingId);

            entity.HasOne(d => d.Room).WithMany(p => p.Arrives)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ArrivedGuest>(entity =>
        {
            entity.ToTable("Arrived_guest");

            entity.HasIndex(e => e.Id, "IX_Arrived_guest_Id").IsUnique();

            entity.Property(e => e.ArrivalId).HasColumnName("Arrival_id");
            entity.Property(e => e.GusetId).HasColumnName("Guset_id");

            entity.HasOne(d => d.Arrival).WithMany(p => p.ArrivedGuests).HasForeignKey(d => d.ArrivalId);

            entity.HasOne(d => d.Guset).WithMany(p => p.ArrivedGuests).HasForeignKey(d => d.GusetId);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.HasIndex(e => e.Id, "IX_Booking_Id").IsUnique();

            entity.Property(e => e.Accept).HasColumnType("BOOLEAN");
            entity.Property(e => e.ArrivalDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Arrival_date");
            entity.Property(e => e.BookingDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Booking_date");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Departure_date");
            entity.Property(e => e.RoomId).HasColumnName("Room_id");
            entity.Property(e => e.Total).HasColumnType("DECIMAL (10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.Id, "IX_Category_Id").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (2, 50)");
            entity.Property(e => e.PeopleCount).HasColumnName("People_count");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.HasIndex(e => e.Id, "IX_Client_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientName)
                .HasColumnType("VARCHAR (3, 150)")
                .HasColumnName("Client_name");
            entity.Property(e => e.TypeId).HasColumnName("Type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Clients).HasForeignKey(d => d.TypeId);
        });

        modelBuilder.Entity<ClientType>(entity =>
        {
            entity.ToTable("Client_type");

            entity.HasIndex(e => e.Id, "IX_Client_type_Id").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (3, 20)");
        });

        modelBuilder.Entity<Departure>(entity =>
        {
            entity.ToTable("Departure");

            entity.HasIndex(e => e.Id, "IX_Departure_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("Booking_id");
            entity.Property(e => e.Date).HasColumnType("DATETIME");
            entity.Property(e => e.RoomId).HasColumnName("Room_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.Departures).HasForeignKey(d => d.BookingId);

            entity.HasOne(d => d.Room).WithMany(p => p.Departures)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DeparturedGuest>(entity =>
        {
            entity.ToTable("Departured_guest");

            entity.HasIndex(e => e.Id, "IX_Departured_guest_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartureId).HasColumnName("Departure_id");
            entity.Property(e => e.GuestId).HasColumnName("Guest_id");

            entity.HasOne(d => d.Departure).WithMany(p => p.DeparturedGuests)
                .HasForeignKey(d => d.DepartureId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Guest).WithMany(p => p.DeparturedGuests)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.ToTable("Guest");

            entity.HasIndex(e => e.Id, "IX_Guest_Id").IsUnique();

            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR (3, 150)")
                .HasColumnName("Full_name");
            entity.Property(e => e.Phone).HasColumnType("VARCHAR (5, 20)");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("Hotel");

            entity.HasIndex(e => e.Id, "IX_Hotel_Id").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (3, 30)");
            entity.Property(e => e.RegionId).HasColumnName("Region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Hotels).HasForeignKey(d => d.RegionId);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.HasIndex(e => e.Id, "IX_Region_Id").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (3, 100)");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.HasIndex(e => e.Id, "IX_Room_Id").IsUnique();

            entity.Property(e => e.CategotyId).HasColumnName("Categoty_id");
            entity.Property(e => e.HotelId).HasColumnName("Hotel_id");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (2, 10)");
            entity.Property(e => e.StateId).HasColumnName("State_id");

            entity.HasOne(d => d.Categoty).WithMany(p => p.Rooms).HasForeignKey(d => d.CategotyId);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms).HasForeignKey(d => d.HotelId);

            entity.HasOne(d => d.State).WithMany(p => p.Rooms).HasForeignKey(d => d.StateId);
        });

        modelBuilder.Entity<RoomPrice>(entity =>
        {
            entity.ToTable("RoomPrice");

            entity.HasIndex(e => e.Id, "IX_RoomPrice_Id").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.Date).HasColumnType("DATETIME");
            entity.Property(e => e.HotelId).HasColumnName("Hotel_id");
            entity.Property(e => e.Price).HasColumnType("DECIMAL (10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.RoomPrices)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Hotel).WithMany(p => p.RoomPrices)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State");

            entity.HasIndex(e => e.Id, "IX_State_Id").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (2, 15)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
