﻿using System;
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

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=./Data/Hotels");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.HasIndex(e => e.Id, "IX_Booking_Id").IsUnique();

            entity.Property(e => e.ArrivalDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Arrival_date");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Departure_date");
            entity.Property(e => e.RoomId).HasColumnName("Room_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings).HasForeignKey(d => d.RoomId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.Id, "IX_Category_Id").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (2, 50)");
            entity.Property(e => e.PeopleCount).HasColumnName("People_count");
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
