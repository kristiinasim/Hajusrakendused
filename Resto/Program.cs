using System;
using System.IO;
using System.Xml.Linq;

namespace Resto
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\krist\Documents\GitHub\Hajusrakendused\Resto\Restaurant.xml");
            XElement restoMenu = XElement.Load(sr);


            Console.WriteLine("Would you like to sort the foods? Pick the tag of the ingredients you don't want to see");
            Console.WriteLine("Tags: L - contains lactose; G - contains gluten; V - contains non-vegan ingredients");

            string read = Console.ReadLine();

            var foodtype = restoMenu.Element("food").Attribute("type");
            Console.WriteLine(foodtype);

            var foods = restoMenu.Elements("food");
            foreach (var food in foods)
            {
                var tags = food.Element("tags").Value;
                if(tags.Contains(read))
                {
                    continue;
                }

                Console.WriteLine(String.Format(
                    " {0}, {1}, {2}, {3}",
              food.Element("name").Value,
              food.Element("price").Value,
              food.Element("description").Value,
              tags

              )) ;
            }

            var drinktype = restoMenu.Element("drink").Attribute("type");
            Console.WriteLine(drinktype);

            var drinks = restoMenu.Elements("drink");
            foreach (var drink in drinks)
            {
                Console.WriteLine(String.Format(
                    " {0}, {1}, {2}",
              //food.Attribute("type").Value,
              drink.Element("name").Value,
              drink.Element("price").Value,
              drink.Element("size").Value
              

               ));


            }
            Console.WriteLine();
            
        }
        }
    }

