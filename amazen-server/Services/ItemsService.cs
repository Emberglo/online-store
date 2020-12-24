using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ItemsService
    {
        private readonly ItemsRepository _repo;

        public ItemsService(ItemsRepository repo)
        {
            _repo = repo;
        }



        internal IEnumerable<Item> GetItemsByProfile(string profileId, string userId)
        {
            return _repo.getItemsByProfile(profileId).ToList().FindAll(b => b.CreatorId == userId);
        }
    }
}