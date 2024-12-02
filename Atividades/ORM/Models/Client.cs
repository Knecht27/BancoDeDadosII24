namespace BTecpar.Models
{
    public class Client
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly Birthday { get; set; }
        public List<Adress>? Adresses { get; set; } 
        
    }
}
