namespace BankingSystem.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; } //use decimal for fractional accuracy
    }
}
