using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerMarket.Model.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<Cart> Carts { get; set; }
    }
}
