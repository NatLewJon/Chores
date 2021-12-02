using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChorseBackend.Models;

namespace ChorseBackend.Data
{
    public class ChorseBackendContext : DbContext
    {
        public ChorseBackendContext (DbContextOptions<ChorseBackendContext> options)
            : base(options)
        {
        }

        public DbSet<ChorseBackend.Models.Client> Client { get; set; }
    }
}
