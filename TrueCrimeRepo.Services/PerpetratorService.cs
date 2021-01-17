﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    public class PerpetratorService
    {
        private readonly string _userID;

        public PerpetratorService(string userID)
        {
            _userID = userID;
        }

        public bool CreatePerpetrator(PerpetratorCreate model)
        {
            var entity =
                new Perpetrator()
                {
                    UserId = _userID,
                    CrimeID = model.CrimeID,
                    Crime = model.Crime,
                    Name = model.Name,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Perpetrators.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PerpetratorListItem> GetPerpetrators()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Perpetrators
                        //.Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new PerpetratorListItem
                                {
                                    PerpetratorID = e.PerpetratorID,
                                    Name = e.Name,
                                    CrimeID = e.CrimeID,
                                    Crime = e.Crime
                                    //CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
