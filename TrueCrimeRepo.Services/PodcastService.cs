using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCrimeRepo.Data;
using TrueCrimeRepo.Models;

namespace TrueCrimeRepo.Services
{
    public class PodcastService
    {
        private readonly string _userID;
        //private ApplicationUser _user;

        public PodcastService(string userID)
        {
            _userID = userID;
        }

        public bool CreatePodcast(PodcastCreate model)
        {
            var entity =
                new Podcast()
                {
                    UserId = _userID,
                    CrimeID = model.CrimeID,
                    Crime = model.Crime,
                    Title = model.Title,
                    PodcastEpisodeTitle = model.PodcastEpisodeTitle,
                    Description = model.Description,
                    WebsiteUrl = model.WebsiteUrl,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Podcasts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<PodcastListItem> GetPodcasts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Podcasts
                        //.Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new PodcastListItem
                                {
                                    PodcastID = e.PodcastID,
                                    CrimeID = e.CrimeID,
                                    Crime = e.Crime, 
                                    Title = e.Title,
                                    PodcastEpisodeTitle = e.PodcastEpisodeTitle,
                                    Description = e.Description,
                                    WebsiteUrl = e.WebsiteUrl,
                                }
                        );

                return query.ToArray();
            }
        }

        public PodcastDetail GetPodcastByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Podcasts
                        .Single(e => e.PodcastID == id); /*&& e.UserId == _userID);*/
                return
                    new PodcastDetail
                    {
                        PodcastID = entity.PodcastID,
                        CrimeID = entity.CrimeID,
                        Crime = entity.Crime,
                        Title = entity.Title,
                        PodcastEpisodeTitle = entity.PodcastEpisodeTitle,
                        Description = entity.Description,
                        WebsiteUrl = entity.WebsiteUrl,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdatePodcast(PodcastEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Podcasts
                        .Single(e => e.PodcastID == model.PodcastID); /*&& e.UserId == _userID);*/

                entity.Title = model.Title;
                entity.PodcastEpisodeTitle = model.PodcastEpisodeTitle;
                entity.Description = model.Description;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePodcast(int PodcastID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Podcasts
                        .Single(e => e.PodcastID == PodcastID); /*&& e.UserId == _userID);*/

                ctx.Podcasts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
