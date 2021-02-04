using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shiftin.Models;
using ShiftIn.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shiftin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ForumPost> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShiftIn.Models.ForumCategory> ForumCategory { get; set; }
        public DbSet<ShiftIn.Models.Interest> Interest { get; set; }
        public DbSet<ShiftIn.Models.Car> Car { get; set; }
    }
}
