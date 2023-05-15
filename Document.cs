namespace doweb
{
    public class Document
    {
        public Document(string name, int number)
        {
            Name = name;
            Number = number;
            DateAdd = DateTime.Now;
            DateUpdate = DateTime.Now;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string? Name { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
