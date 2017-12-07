using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public DateTime ValidTo { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
