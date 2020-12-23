﻿using System;
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
        private ApplicationUser _user;

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
                    Title = model.Title,
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
                        .Where(e => e.UserId == _userID)
                        .Select(
                            e =>
                                new PodcastListItem
                                {
                                    PodcastID = e.PodcastID,
                                    Title = e.Title,
                                    Description = e.Description,
                                    WebsiteUrl = e.WebsiteUrl,
                                    CreatedUtc = e.CreatedUtc
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
                        .Single(e => e.PodcastID == id && e.UserId == _userID);
                return
                    new PodcastDetail
                    {
                        PodcastID = entity.PodcastID,
                        Title = entity.Title,
                        Description = entity.Description,
                        WebsiteURL = entity.WebsiteUrl,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
