using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_1303___Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            MyProtectedUniqueList myList = new MyProtectedUniqueList("meir");

            myList.Add(null); //try to add Null.
            myList.Add("");//try to add empty string.
            myList.Add("c"); // try to add same string.
            myList.Add("c"); 
            myList.Add("d");
            myList.Add("e");
            myList.Add("b");
            myList.Add("a");

            myList.Remove(null); //try to remove null.
            myList.Remove(""); //try to remove empty string.
            myList.Remove("da"); // try to remove uncorrect word.
            myList.Remove("d");
            
            myList.RemoveAta(-1); //try to remove out the range.
            myList.RemoveAta(2);
            
            myList.Clear("mei"); //try clear the list with uncorrect secret word.

            myList.Sort("meirrr"); //try to sort the list with uncorrect secret word.

            foreach (string word in myList) // use foreach on mylist (even it class)
                Console.WriteLine(word + "\n");

            Console.WriteLine(myList); //to string of my list.
        }
    }
}
