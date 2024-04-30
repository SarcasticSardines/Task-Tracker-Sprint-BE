using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tasksprintbe.Models;

namespace tasksprintbe.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<TaskModel> TaskInfo { get; set; }
        public DbSet<CommentModel> CommentInfo { get; set; }
        public DbSet<BoardModel> BoardInfo { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}