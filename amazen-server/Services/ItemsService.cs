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

        public IEnumerable<Item> GetAll()
        {
            return _repo.GetAll();
        }

        internal IEnumerable<Item> GetItemsByProfile(string profileId, string userId)
        {
            return _repo.getItemsByProfile(profileId).ToList().FindAll(i => i.CreatorId == userId || i.IsAvailable);
        }

        public Item Create(Item newItem)
        {
            newItem.Id = _repo.Create(newItem);
            return newItem;
        }

        internal Item Edit(Item editedItem, string userId)
        {
            Item oldItem = _repo.GetOne(editedItem.Id);
            if (oldItem == null) { throw new Exception("Incorrect ID"); }
            if (oldItem.CreatorId != userId)
            {
                throw new Exception("Not your item");
            }
            _repo.Edit(editedItem);
            return _repo.GetOne(editedItem.Id);
        }

        internal string Delete(int id, string userId)
        {
            Item oldItem = _repo.GetOne(id);
            if (oldItem == null) { throw new Exception("Incorrect ID"); }
            if (oldItem.CreatorId != userId)
            {
                throw new Exception("Not your item");
            }
            if (_repo.Remove(id))
            {
                return "Great Success";
            }
            return "Delete Failed";
        }
    }
}