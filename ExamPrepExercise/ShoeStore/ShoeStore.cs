using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public string Name { get; }
        public int StorageCapacity { get; }
        public List<Shoe> Shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Count >= StorageCapacity)
                return "No more space in the storage room.";

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
            => Shoes.RemoveAll(s => s.Material == material);

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.Where(s => s.Type.ToLower() == type.ToLower()).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(s => s.Size == size);
        }

        public string StockList(double size, string type)
        {
            var sb = new StringBuilder();
            Shoe[] foundShoes = Shoes.Where(s => s.Size == size && s.Type == type).ToArray();
            if(foundShoes.Count() > 0)
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach(Shoe shoe in foundShoes)
                {
                    sb.AppendLine(shoe.ToString());
                }
                return sb.ToString().TrimEnd();
            }
            return "No matches found!";
        }
    }
}
