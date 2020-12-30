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
        private ApplicationUser _user;

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
                        .Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new TVShowListItem
                                {
                                    TVShowID = e.TVShowID,
                                    CrimeID = e.CrimeID,
                                    Title = e.Title,
                                    Description = e.Description,
                                    Channel_OnlineStream = e.Channel_OnlineStream
                                    //CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
