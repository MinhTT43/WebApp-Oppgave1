using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeasonLine.Model;

namespace SeasonLine.DAL
{
    [Route("[controller]/[action]")]
    public class BestillingController
    {
        private readonly BestillingContext _db;

        public BestillingController(BestillingContext db)
        {
            _db = db;
        }

        // TODO: Refaktoriser koden til en egen klasse
        public Kunder LagKunde(Bestilling InnBestilling)
        {
            var nyKunde = new Kunder
            {
                Fornavn = InnBestilling.Fornavn,
                Etternavn = InnBestilling.Etternavn,
                Epost = InnBestilling.Epost,
                Telefon = InnBestilling.Telefon,
            };
            return nyKunde;
        }

        // TODO: Refaktoriser koden til en egen klasse
        public Bestillinger LagBestilling(Bestilling InnBestilling)
        {
            var NyBestilling = new Bestillinger
            {
                AntallBarn = InnBestilling.AntallBarn,
                AntallVokse = InnBestilling.AntallVokse,
                AntallLugarer = InnBestilling.AntallLugarer
            };

            return NyBestilling;
        }



        public List<Bestilling> HentAlle()
        {
            List<Kunder> KundeList = _db.AlleKunder.ToList();
            List<Bestillinger> BestillingListe = _db.AlleBestillinger.ToList();
            List<Reiser> ReiseListe = _db.AlleReiser.ToList();
            List<Bestilling> alleBestillinger = new List<Bestilling>();

            foreach (var kunde in KundeList)
            {
                foreach (var bestilling in BestillingListe)
                {
                    foreach (var reise in ReiseListe)
                    {
                        var enBestilling = new Bestilling
                        {
                            Fornavn = kunde.Fornavn,
                            Etternavn = kunde.Etternavn,
                            Telefon = kunde.Telefon,
                            Epost = kunde.Epost,
                            Ankomst = reise.Ankomst,
                            AvreiseSted = reise.AvreiseSted,
                            AvreiseKlokkeslett = reise.AvreiseKlokkeslett,
                            AvreiseDato = reise.AvreiseDato,
                            AntallBarn = bestilling.AntallBarn,
                            AntallVokse = bestilling.AntallVokse,
                            AntallLugarer = bestilling.AntallLugarer,
                            PrisBarn = reise.PrisBarn,
                            PrisLugar = reise.PrisLugar,
                            PrisVoksen = reise.PrisVoksen,
                        };
                        alleBestillinger.Add(enBestilling);
                    }
                }
            }
            return alleBestillinger;
        }
    }
}
