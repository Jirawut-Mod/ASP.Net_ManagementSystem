using Microsoft.EntityFrameworkCore;
using Word_of_ModJirawut.Models;

namespace Word_of_ModJirawut.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options) :base(options){ 
        
        }
        public DbSet<Project> Projects { get; set; }
    }
}
