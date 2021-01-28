using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Contracts;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    public class CrimeService : ICrimeService
    {
        // Put UserId in all the models

        private readonly string _userID;
        //private ApplicationUser _user;

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
                    //Year = model.Year,
                    //PerpetratorID = model.PerpetratorID,
                    Perpetrator = model.Perpetrator,
                    Location = model.Location,
                    //IsSolved = model.IsSolved,
                    IsCrimeSolved = model.IsCrimeSolved,
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
                        //.Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new CrimeListItem
                                {
                                    CrimeID = e.CrimeID,
                                    Title = e.Title,
                                    Description = e.Description,
                                    //Year = e.Year,
                                    //PerpetratorID = e.PerpetratorID,
                                    Perpetrator = e.Perpetrator,
                                    Location = e.Location,
                                    //IsSolved = e.IsSolved,
                                    IsCrimeSolved = e.IsCrimeSolved,
                                    Podcasts = e.Podcasts,
                                    TVShows = e.TVShows,
                                    Books = e.Books,
                                }
                        );

                return query.ToArray();
            }
        }
        public CrimeDetail GetCrimeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeID == id);/*&& e.UserId == _userID);*/
                return
                    new CrimeDetail
                    {
                        CrimeID = entity.CrimeID,
                        Title = entity.Title,
                        Description = entity.Description,
                        //Year = entity.Year,
                        Perpetrator = entity.Perpetrator,
                        //Perpetrator = entity.Perpetrator.ToString(),
                        Location = entity.Location,
                        //IsSolved = entity.IsSolved,
                        IsCrimeSolved = entity.IsCrimeSolved,
                        Podcasts = entity.Podcasts,
                        TVShows = entity.TVShows,
                        Books = entity.Books
                    };
            }
        }
        public bool UpdateCrime(CrimeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeID == model.CrimeID); /*&& e.UserId == _userID);*/

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Perpetrator = model.Perpetrator;
                entity.Location = model.Location;
                //entity.IsSolved = model.IsSolved;
                entity.IsCrimeSolved = model.IsCrimeSolved;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCrime(int crimeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeID == crimeID); /*&& e.UserId == _userID);*/

                ctx.Crimes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

        
