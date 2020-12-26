using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
    public class ListsRepository
    {
        private readonly IDbConnection _db;

        private readonly string populateCreator = "SELECT list.*, profile.* FROM lists list INNER JOIN profiles profile ON list.creatorId = profile.id ";

        public ListsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<List> GetAll()
        {
            string sql = populateCreator;
            return _db.Query<List, Profile, List>(sql, (List, profile) => { List.Creator = profile; return List; }, splitOn: "id");
        }

        internal List GetOne(int id)
        {
            string sql = "SELECT * FROM lists WHERE id = @id";
            return _db.QueryFirstOrDefault<List>(sql, new { id });
        }

        internal IEnumerable<List> getListsByProfile(string profileId)
        {
            string sql = "SELECT list.*, p.* FROM lists list JOIN profiles p ON list.creatorId = p.id WHERE list.creatorId = @profileId; ";
            return _db.Query<List, Profile, List>(sql, (list, profile) => { list.Creator = profile; return list; }, new { profileId }, splitOn: "id");
        }

        public int Create(List newList)
        {
            string sql = "INSERT INTO lists (name, creatorId) VALUES (@Name, @CreatorId);";
            return _db.ExecuteScalar<int>(sql, newList);
        }

        internal void Edit(List editedList)
        {
            string sql = "UPDATE lists SET name = @Name WHERE id = @Id;";
            _db.Execute(sql, editedList);
        }

        internal bool Remove(int id)
        {
            string sql = "DELETE FROM lists WHERE id = @Id";
            int exists = _db.Execute(sql, new { id });
            return exists > 0;
        }

    }
}