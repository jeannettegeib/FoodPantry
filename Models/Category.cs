using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPantry.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OnePerson { get; set; }
        public int TwoPeople { get; set; }
        public int ThreeToFourPeople { get; set; }
        public int FiveToSixPeople { get; set; }
        public int SevenToEightPeople { get; set; }
        public int NinePlusPeople { get; set; }
        public List<Item> Items { get; set; }
    
    }
}
