using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    public class TVShowService
    {
        private readonly string _userID;
        //private ApplicationUser _user;

        public TVShowService(string userID)
        {
            _userID = userID;
        }

        public bool CreateTVShow(TVShowCreate model)
        {
            var entity =
                new TVShow()
                {
                    UserId = _userID,
                    CrimeID = model.CrimeID,
                    Crime = model.Crime,
                    Title = model.Title,
                    Description = model.Description,
                    Channel_OnlineStream = model.Channel_OnlineStream,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TVShows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TVShowListItem> GetTVShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TVShows
                        //.Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new TVShowListItem
                                {
                                    TVShowID = e.TVShowID,
                                    CrimeID = e.CrimeID,
                                    Crime = e.Crime,
                                    Title = e.Title,
                                    Description = e.Description,
                                    Channel_OnlineStream = e.Channel_OnlineStream
                                    //CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public TVShowDetail GetTVShowByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TVShows
                        .Single(e => e.TVShowID == id); /*&& e.UserId == _userID);*/
                return
                    new TVShowDetail
                    {
                        TVShowID = entity.TVShowID,
                        CrimeID = entity.CrimeID,
                        Crime = entity.Crime,
                        Title = entity.Title,
                        Description = entity.Description,
                        Channel_OnlineStream = entity.Channel_OnlineStream,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateTVShow(TVShowEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TVShows
                        .Single(e => e.TVShowID == model.TVShowID); /*&& e.UserId == _userID);*/
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Channel_OnlineStream = model.Channel_OnlineStream;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTVShow(int TVShowID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TVShows
                        .Single(e => e.TVShowID == TVShowID); /*&& e.UserId == _userID);*/

                ctx.TVShows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
