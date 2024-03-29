﻿using Airports.DAL.Context;
using Airports.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Airports.DAL
{
    internal class AirportRepository:DBRepository<AirportDBModel>
    {

        public override IQueryable<AirportDBModel> Items => base.Items
            .Include(item => item.AirportFrequencesDB)
            .Include(item => item.CountryDB)
            .Include(item => item.NavaidsDB)
            .Include(item => item.RegionDB)
            .Include(item => item.RunwaysDB)
            ;


        public AirportRepository(AirpotsDB _db) : base(_db) { }
    }
}
