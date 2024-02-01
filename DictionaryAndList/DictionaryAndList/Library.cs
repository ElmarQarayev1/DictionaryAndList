using System;
using DictionaryAndList.Exceptions;

namespace DictionaryAndList
{
	public class Library
	{
          
        public List<string> booksName = new List<string>();

	    const int BookLimit=100;
       
        public void AddBook(string name)
        {
            if (booksName.Count < BookLimit)
            {
                if (!booksName.Contains(name))
                {
                    booksName.Add(name);
                }
                else
                {
                    throw new DublicateBookException();
                }
            }
            else
            {
                throw new IsFullOfBooksLimit();
            }
        }

        public bool RemoveBook(string name)
        {
		if (booksName.Remove(name))
	    {    	
			return true;
		}
		else
		    return false;
		}          
	}
}

