namespace dev_week.src.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Document { get; set; }
        public bool Active { get; set; }
        public List<Contract> Contracts { get; set; }    

        public Person()
        {
            Contracts = new List<Contract>();
        }            
    }
}