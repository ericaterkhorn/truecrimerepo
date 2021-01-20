using System;
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
        public PerpetratorDetail GetPerpetratorByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Perpetrators
                        .Single(e => e.PerpetratorID == id); /*&& e.OwnerId == _userId*/
                return
                    new PerpetratorDetail
                    {
                        PerpetratorID = entity.PerpetratorID,
                        CrimeID = entity.CrimeID,
                        Crime = entity.Crime,
                        Name = entity.Name,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdatePerpetrator(PerpetratorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Perpetrators
                        .Single(e => e.PerpetratorID == model.PerpetratorID); /*&& e.OwnerId == _userId);*/

                entity.Name = model.Name;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePerpetrator(int perpetratorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Perpetrators
                        .Single(e => e.PerpetratorID == perpetratorID); /*&& e.OwnerId == _userId);*/

                ctx.Perpetrators.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
