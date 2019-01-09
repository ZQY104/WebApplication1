using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class WebApplication1ScheduleContext : DbContext
    {
        public WebApplication1ScheduleContext (DbContextOptions<WebApplication1ScheduleContext> options) : base(options)
        { }

        public DbSet<WebApplication1.Models.Schedule> Schedule { get; set; }
        public DbSet<WebApplication1.Models.User> User { get; set; }
    }
}
