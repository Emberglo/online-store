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

        public IEnumerable<Item> GetAll()
        {
            string sql = populateCreator;
            return _db.Query<Item, Profile, Item>(sql, (Item, profile) => { Item.Creator = profile; return Item; }, splitOn: "id");
        }

        internal Item GetOne(int id)
        {
            string sql = "SELECT * FROM items WHERE id = @id";
            return _db.QueryFirstOrDefault<Item>(sql, new { id });
        }

        internal IEnumerable<Item> getItemsByProfile(string profileId)
        {
            string sql = "SELECT item.*, p.* FROM items item JOIN profiles p ON item.creatorId = p.id WHERE item.creatorId = @profileId; ";
            return _db.Query<Item, Profile, Item>(sql, (item, profile) => { item.Creator = profile; return item; }, new { profileId }, splitOn: "id");
        }

        public int Create(Item newItem)
        {
            string sql = "INSERT INTO items (name, description, price, isAvailable, creatorId) VALUES (@Name, @Description, @Price, @isAvailable, @CreatorId);";
            return _db.ExecuteScalar<int>(sql, newItem);
        }

        internal void Edit(Item editedItem)
        {
            string sql = "UPDATE items SET description = @Description, name = @Name, price = @Price, isAvailable = @isAvailable WHERE id = @Id;";
            _db.Execute(sql, editedItem);
        }

        internal bool Remove(int id)
        {
            string sql = "DELETE FROM items WHERE id = @Id";
            int exists = _db.Execute(sql, new { id });
            return exists > 0;
        }
    }
}