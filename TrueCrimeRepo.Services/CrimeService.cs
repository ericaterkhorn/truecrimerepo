using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    public class CrimeService
    {
        private readonly string _userID;
        private ApplicationUser _user;

        public CrimeService(string userID)
        {
            _userID = userID;
        }
        public bool CreateCrime(CrimeCreate model)
        {
            var entity =
                new Crime()
                {
                    UserId = _userID,
                    Title = model.Title,
                    Description = model.Description,
                    Year = model.Year,
                    Perpetrator = model.Perpetrator,
                    Location = model.Location,
                    IsSolved = model.IsSolved,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Crimes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CrimeListItem> GetCrimes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Crimes
                        .Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new CrimeListItem
                                {
                                    //CrimeID = e.CrimeID,
                                    Title = e.Title,
                                    Description = e.Description,
                                    Year = e.Year,
                                    Perpetrator = e.Perpetrator,
                                    Location = e.Location,
                                    IsSolved = e.IsSolved,
                                    
                                }
                        );

                return query.ToArray();
            }
        }

    }
}
