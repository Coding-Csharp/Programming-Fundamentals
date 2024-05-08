namespace PresentationLayer.Models
{
    public partial class Client
    {
        public Client()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Age = 0;
        }
    }
    public partial class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
    }
}