using Common;
using Datastucture;

namespace Datastucture
{
    class Program
    {
        static void Main()
        {
            VerketteteListe list = new VerketteteListe();

            Person person1 = new Person("name");
            Person person2 = new Person("name");

            list.Addlast(person1);
            list.Addlast(person2);

            bool result = list.CheckForObject(person1);

            Console.WriteLine(result);
        }
    }
}