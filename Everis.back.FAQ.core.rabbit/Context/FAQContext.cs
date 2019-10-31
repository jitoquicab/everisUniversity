using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Everis.back.FAQ.core.models.EntityModel;

namespace Everis.back.FAQ.core.rabbit.Context
{
    public class FAQContext : DbContext
    {
        private static long InstanceCount;

        public FAQContext(DbContextOptions<FAQContext> options) : base(options)
            => Interlocked.Increment(ref InstanceCount);

        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
