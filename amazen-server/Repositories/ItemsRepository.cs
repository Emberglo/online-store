using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
    public class ItemsRepository
    {
        private readonly IDbConnection _db;

        private readonly string populateCreator = "SELECT item.*, profile.* FROM items item INNER JOIN profiles profile ON item.creatorId = profile.id ";

        public ItemsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Item> getItemsByProfile(string profileId)
        {
            string sql = "SELECT item.*, p.* FROM items item JOIN profiles p ON item.creatorId = p.id WHERE item.creatorId = @profileId; ";
            return _db.Query<Item, Profile, Item>(sql, (item, profile) => { item.Creator = profile; return item; }, new { profileId }, splitOn: "id");
        }
    }
}