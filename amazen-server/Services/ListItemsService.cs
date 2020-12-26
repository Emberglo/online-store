using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ListItemsService
    {
        private readonly ListItemsRepository _repo;

        public ListItemsService(ListItemsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Item> GetItemsByListId(int listId)
        {
            return _repo.GetItemsByListId(listId);
        }

        public ListItem Create(ListItem newListItem)
        {
            newListItem.Id = _repo.Create(newListItem);
            return newListItem;
        }

        internal string Delete(int id, string userId)
        {
            ListItem oldListItem = _repo.GetOne(id);
            if (oldListItem == null) { throw new Exception("Bad ID"); }
            if (oldListItem.CreatorId != userId)
            {
                throw new Exception("Not Your List Item");
            }
            if (_repo.Remove(id))
            {
                return "Great Success";
            }
            return "Delete Failed";
        }

    }
}