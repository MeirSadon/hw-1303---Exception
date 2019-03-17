using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_1303___Exception
{
    class MyProtectedUniqueList : IComparable<string>, IEnumerable
    {
        private List<string> words = new List<string>();
        public string SecretWord { get; }

        public MyProtectedUniqueList(string secretWord)
        {
            SecretWord = secretWord;
        }
        public void Add(string newWord)
        {
            bool correctWord = false; // create new boolean to check if the word is good.

            do
            {
                try //check if throw ecxeption.
                {
                    if (newWord == null || newWord == "") //check if the word isn't null or empty.
                        throw new ArgumentNullException("Your New Word Is Empty... Enter New Word: "); //if so, throw new exception.
                    foreach (string word in words)// check if the word is in use in the list.
                    {
                        if (newWord == word)
                            throw new InvalidOperationException("Your New Word Is Already In Use... Try New Word: ");
                    }
                        words.Add(newWord); //if the word is good so add it to the list.
                    correctWord = true; // and change the boolean to true.
                }
                catch (ArgumentNullException e)
                {
                    Console.Write(e.Message); // print the message of the exception(null or empty word).
                    newWord = Console.ReadLine();// give the user new chance to add new word.
                }
                catch (InvalidOperationException e)
                {
                    Console.Write(e.Message); // print the message of the exception(already in use).
                    newWord = Console.ReadLine();  // give the user new chance to add new word.e();
                }
            } while (correctWord == false); //check if the problem resloved.
            PrintTheList();
        }
        public void Remove(string wordToRemove)
        {
            bool correctWord = false; // create new boolean to check if the word is good.

            do
            {
                try //check if throw ecxeption.
                {
                    if (wordToRemove == null || wordToRemove == "") //check if the word isn't null or empty.
                        throw new ArgumentNullException("Your Word That You Want To Remove Is Empty... Enter New Word To Remove: "); //if so, throw new exception.
                    for (int i = 0; i < words.Count; i++) // check if the word is in use in the list.
                    {
                        if (wordToRemove == words[i])
                        {
                            words.Remove(wordToRemove); //if the word is good so remove from the list.
                            PrintTheList();
                            return;
                        }
                    }
                    throw new ArgumentException("Your Word Is Not Exist at This List... Enter New Word To Remove: ");
                }
                catch (ArgumentNullException e)
                {
                    Console.Write(e.Message); // print the message of the exception(null or empty word).
                    wordToRemove = Console.ReadLine();// give the user new chance to remove word from list.
                }
                catch (ArgumentException e)
                {
                    Console.Write(e.Message); // print the message of the exception(already in use).
                    wordToRemove = Console.ReadLine();  // give the user new chance to remove word from list.;
                }
            } while (correctWord == false); //check if the problem resloved.
        }
        public void RemoveAta(int indexToRemove)
        {
            bool correctIndex = false;
            do
            {
                try
                {
                    if (indexToRemove < 0 || indexToRemove > words.Count)
                        throw new ArgumentOutOfRangeException("Your Index That You Want To Remove Is Out Of The Range Of Your List... Enter New Index: ");
                    words.RemoveAt(indexToRemove); //remove the word[indextoRemove]
                    correctIndex = true; //the problem is resloved
                    PrintTheList();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.Write(e.Message); // print the message of the exception(out of the range).
                    indexToRemove = Convert.ToInt32(Console.ReadLine());  // give the user new chance to remove word from list.;
                }
            } while (correctIndex == false); //check if the problem resloved.
        }
        public void Clear(string secretWord)
        {
            bool isSecretWord = false;
            do
            {
                try
                {
                    if (secretWord == SecretWord)
                    {
                        words.Clear();
                        PrintTheList();
                        isSecretWord = true;
                    }
                    else
                        throw new AccessViolationException("Your Secret Word Is Uncorrect!... Enter Try Another Word: ");
                }
                catch (AccessViolationException e)
                {
                    Console.Write(e.Message); // print the message of the exception(Uncorrect secret word).
                    secretWord = Console.ReadLine();  // give the user new chance to send new secret word.;
                }
            } while (isSecretWord == false);
        }
        public void Sort(string secretWord)
        {
            bool isSecretWord = false;
            do
            {
                try
                {
                    if (secretWord == SecretWord)
                    {
                        words.Sort();
                        PrintTheList();
                        isSecretWord = true;
                    }
                    else
                        throw new AccessViolationException("Your Secret Word Is Uncorrect!... Enter Try Another Word: ");

                }
                catch (AccessViolationException e)
                {
                    Console.Write(e.Message); // print the message of the exception(Uncorrect secret word).
                    secretWord = Console.ReadLine();  // give the user new chance to send new secret word.;
                }
            } while (isSecretWord == false);
            }

        public override string ToString()
        {
            string result = $"In My Protected List Have {words.Count} Words! \n";
            for (int i = 0; i < words.Count; i++)
            {
                result += $"Word Number {i + 1} Is: {words[i]} \n";
            }
            return result;

        }
        private void PrintTheList() // Print The List.
        {
            foreach (string word in words)
                Console.WriteLine(word);  
            Console.WriteLine();          
        }

        public int CompareTo(string other)
        {
                return CompareTo(words.ToString()); // return what the compareto of words would give.
        }
        
        public IEnumerator GetEnumerator()
        {
            return words.GetEnumerator(); // return what the enumerator of words would give.
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return words.GetEnumerator(); // return what the enumerator of words would give.
        }
    }
}
