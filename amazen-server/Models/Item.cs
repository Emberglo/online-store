namespace amazen_server.Models
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        public Profile Creator { get; set; }
    }

    public class ListItemViewModel : Item
    {
        public int ListItemId { get; set; }
    }
}