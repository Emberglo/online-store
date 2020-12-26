using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ListsService
    {
        private readonly ListsRepository _repo;

        public ListsService(ListsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<List> GetAll()
        {
            return _repo.GetAll();
        }

        internal IEnumerable<List> GetListsByProfile(string profileId, string userId)
        {
            return _repo.getListsByProfile(profileId).ToList().FindAll(b => b.CreatorId == userId);
        }

        public List Create(List newList)
        {
            newList.Id = _repo.Create(newList);
            return newList;
        }

        internal List Edit(List editedList, string userId)
        {
            List oldList = _repo.GetOne(editedList.Id);
            if (oldList == null) { throw new Exception("Incorrect ID"); }
            if (oldList.CreatorId != userId)
            {
                throw new Exception("Not your list");
            }
            _repo.Edit(editedList);
            return _repo.GetOne(editedList.Id);
        }

        internal string Delete(int id, string userId)
        {
            List oldList = _repo.GetOne(id);
            if (oldList == null) { throw new Exception("Incorrect ID"); }
            if (oldList.CreatorId != userId)
            {
                throw new Exception("Not your list");
            }
            if (_repo.Remove(id))
            {
                return "Great Success";
            }
            return "Delete Failed";
        }

    }
}