using Portal.Common.Enums;
using Portal.Domain.Common;

namespace Portal.Application.Foods.Models
{
    public class FoodAddInfo
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
