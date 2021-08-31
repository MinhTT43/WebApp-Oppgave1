using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SeasonLine.Model
{

    public class Kunder
    {
        [Key]
        public int KId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telefon { get; set; }
        public string Epost { get; set; }
        public virtual List<Bestillinger> RelaterteBestillinger { get; set; }
    }

    public class Bestillinger
    {
        [Key]
        public int BestId { get; set; }
        public virtual Reiser Tur { get; set; }
        public int AntallBarn { get; set; }
        public int AntallVokse { get; set; }
        public int AntallLugarer { get; set; }
        public virtual List<Kunder> RelaterteKunder { get; set; }
    }

    public class Reiser
    {
        [Key]
        public int ReiseID { get; set; }
        public string Ankomst { get; set; }
        public string AvreiseSted { get; set; }
        public string AvreiseKlokkeslett { get; set; }
        public string AvreiseDato { get; set; }
        public int PrisBarn { get; set; }
        public int PrisVoksen { get; set; }
        public int PrisLugar { get; set; }
    }

    public class BestillingContext : DbContext
    {
        public BestillingContext(DbContextOptions<BestillingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunder> AlleKunder { get; set; }
        public DbSet<Reiser> AlleReiser { get; set; }
        public DbSet<Bestillinger> AlleBestillinger { get; set; }

    }
}
