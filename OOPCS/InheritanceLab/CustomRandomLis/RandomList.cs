
namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            int randomIndex = random.Next(0,this.Count);
            string value = this[randomIndex];

            this.RemoveAt(randomIndex);
            return value;
        }
    }
}
