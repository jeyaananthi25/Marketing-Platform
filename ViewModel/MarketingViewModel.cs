using MarketingApp.Models;

namespace MarketingApp.ViewModel
{
    public class MarketingViewModel
    {
        public CreateAccount CreateAccount { get; set; }
        public Address Address { get; set; }
        public MarketingViewModel()
        {
            CreateAccount = new CreateAccount();
            Address = new Address();
        }
    }
}
