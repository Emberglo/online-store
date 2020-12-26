namespace amazen_server.Models
{
    public class List
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        public Profile Creator { get; set; }
    }
}