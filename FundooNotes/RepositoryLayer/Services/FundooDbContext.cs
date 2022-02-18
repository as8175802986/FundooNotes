using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.User;
using CommonLayer.Note;
using RepositoryLayer.Entities;

namespace RepositoryLayer.Services
{
    public class FundooDbContext : DbContext
    {
        public FundooDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<Label> Label { get; set; }
        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>()
            .HasIndex(u => u.email)
            .IsUnique();

            //modelBuilder.Entity<Note>()
            //.HasOne(u => u.User)
            //.WithMany()
            //.HasForeignKey(u => u.Userid);
        }
    }
}
