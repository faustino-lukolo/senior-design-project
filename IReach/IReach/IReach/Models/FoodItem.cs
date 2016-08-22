using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace IReach.Models
{
    public class FoodItem
    {
        public FoodItem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Servings { get; set; }
    }
}
