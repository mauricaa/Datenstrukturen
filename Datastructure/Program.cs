using Common;
using Datastucture;

namespace Datastucture
{
    class Program
    {
        static void Main()
        {
            VerketteteListe<Person> list = new VerketteteListe<Person>();

            Person person1 = new Person("name1");
            Person person2 = new Person("name2");

            list.Addlast(person1);
            list.Addlast(person2);

            bool result = list.CheckForObject(person1);

            Console.WriteLine(result);
        }
    }
}