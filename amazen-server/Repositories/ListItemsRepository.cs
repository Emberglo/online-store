using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
    public class ListItemsRepository
    {
        private readonly IDbConnection _db;

        public ListItemsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal ListItem GetOne(int id)
        {
            string sql = "SELECT * FROM listitems WHERE id = @id";
            return _db.QueryFirstOrDefault<ListItem>(sql, new { id });
        }

        internal IEnumerable<Item> GetItemsByListId(int listId)
        {
            string sql = "SELECT l.*, li.id AS ListItemId, p.* FROM listitems li JOIN items i ON i.id = li.itemId JOIN profiles p ON p.id = i.creatorId WHERE companyId = @companyId;";
            return _db.Query<ListItemViewModel, Profile, ListItemViewModel>(sql, (item, profile) => { item.Creator = profile; return item; }, new { listId }, splitOn: "id");
        }

        public int Create(ListItem newListItem)
        {
            string sql = "INSERT INTO listitems (listId, itemId, creatorId) VALUES (@ListId, @ItemId, @CreatorId); SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newListItem);
        }

        internal bool Remove(int id)
        {
            string sql = "DELTE FROM listitems WHERE id = @id";
            int valid = _db.Execute(sql, new { id });
            return valid > 0;
        }

    }
}