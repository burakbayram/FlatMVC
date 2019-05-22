using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlatContext : DbContext
    {
        public FlatContext():base("YeniCon")
        {
           
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<General> General { get; set; }
        public virtual DbSet<WhatWeDo> WhatWeDos { get; set; }
        public virtual DbSet<WorkCategory> WorkCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            #region TableSettings
            mb.Entity<Work>().HasKey(x => x.Id).ToTable("Works");

            mb.Entity<WorkCategory>().HasKey(x => x.Id);

            mb.Entity<Contact>().HasKey(x => x.Id);

            mb.Entity<WhatWeDo>().HasKey(x => x.Id);

            mb.Entity<General>().HasKey(x => x.Id);

            mb.Entity<WorkCategory>().Property(x => x.Name).IsRequired().HasMaxLength(50);

          //  mb.Entity<WorkCategory>().HasIndex(x => x.Name).IsUnique();
            #endregion

            mb.Entity<Work>()
                .HasMany(work => work.Categories)
                .WithMany(category => category.Works);

            base.OnModelCreating(mb);
        }
    }
}
