﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VapeForLife.DBContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VapeForLifeEntities : DbContext
    {
        public VapeForLifeEntities()
            : base("name=VapeForLifeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aroma> aromas { get; set; }
        public virtual DbSet<aroma_languages_relation> aroma_languages_relation { get; set; }
        public virtual DbSet<@base> bases { get; set; }
        public virtual DbSet<base_languages_relation> base_languages_relation { get; set; }
        public virtual DbSet<language> languages { get; set; }
        public virtual DbSet<manufacturer> manufacturers { get; set; }
        public virtual DbSet<manufacturer_aroma_relation> manufacturer_aroma_relation { get; set; }
        public virtual DbSet<manufacturer_base_relation> manufacturer_base_relation { get; set; }
        public virtual DbSet<manufacturer_languages_relation> manufacturer_languages_relation { get; set; }
        public virtual DbSet<manufacturer_nicotine_relation> manufacturer_nicotine_relation { get; set; }
        public virtual DbSet<nicotine> nicotines { get; set; }
        public virtual DbSet<unit> units { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
