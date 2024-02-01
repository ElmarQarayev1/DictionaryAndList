using System.Text.RegularExpressions;
using DictionaryAndList.Exceptions;

namespace DictionaryAndList;

class Program
{
    static void Main(string[] args)
    { 

        //Dictionary<string, DateTime> fennDate = new Dictionary<string, DateTime>();
        //fennDate.Add("riyaziyyat",new DateTime(2024, 2 ,10));
        //fennDate.Add("az dili", new DateTime(2024, 2 ,25));
        //fennDate.Add("fizika", new DateTime(2024, 4, 12));

        //foreach (var item in fennDate)
        //{
        //    var diff = item.Value - DateTime.Now;
        //    Console.WriteLine(item.Key+": "+item.Value.ToString("dd.MM.yyyy")+"  Qalan gun: "+diff.Days);
        //}

        Library library = new Library();
      
        library.AddBook("Qurur ve qerez");
        library.AddBook("Yuz ilin tenhaligi");
        library.AddBook("Sicanlar və adamlar");
        library.AddBook("Sefiller");
        library.AddBook("Çerpeleng ucuran");

        string opt;
        do
        {
            ShowMenu();
            opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    AddBook(library);
                    break;
                case "2":
                    RemoveBook(library);
                    break;
                case "3":
                    AllBooks(library);
                    break;
                case "4":
                    SearchBook(library);
                    break;
                default:
                    Console.WriteLine("Secim yanlisdir!");
                    break;
            }
        } while (opt != "0");

                 Console.ReadLine();
    }

   static void ShowMenu()
   {
        Console.WriteLine("1.Kitab elave et");
        Console.WriteLine("2.Kitab sil");
        Console.WriteLine("3.Butun kitablara bax");
        Console.WriteLine("4.Kitab axtar");
        Console.WriteLine("0.Cix");
        Console.WriteLine("Secim edin: ");
   }

   static void AddBook(Library library)
   {
        Name:
        Console.WriteLine("Elave etmek istediyiniz kitabin adini qeyd edin:");
        string name = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto Name;
        }
        try
        {
            library.AddBook(name.Trim());
        }
        catch (DublicateBookException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IsFullOfBooksLimit e)
        {
            Console.WriteLine(e.Message);

        }
   }

   static void RemoveBook(Library library)
   {
        NameR:
        Console.WriteLine("silmek istediyiniz kitabin adini qeyd edin:");
        string nameR = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(nameR))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto NameR;
        }
        if (library.RemoveBook(nameR.Trim()))
        {
            Console.WriteLine("kitab silindi!");
        }
        else
        {
            Console.WriteLine("kitab tapilmadi!");
        }
   }
   static void AllBooks(Library library)
   {
        Console.WriteLine("butun kitablar:");

        foreach (var book in library.booksName)
        {
            Console.WriteLine(book);
        }

   }
   static void SearchBook(Library library)
   {
        NameS:
        Console.WriteLine("axtaracaginiz kitabi qeyd edin:");
        string nameS = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(nameS))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto NameS;
        }
        bool foundCheck = false;
        foreach (var item in library.booksName)
        {

            if (item.ToLower().Contains(nameS.ToLower()))
            {
                Console.WriteLine($"axtardiginiz kitab: {item}");
                foundCheck = true;
                break;

            }
        }
        if (!foundCheck)
        {
            Console.WriteLine("Kitab tapilmadi!");
        }



       // Console.WriteLine("bu tip bir axtarisda ola biler:");
        //if (library.booksName.Contains(nameS))
        //{
        //    Console.WriteLine($"kitab tapildi-{nameS}");
        //}
        //else
        //{
        //    Console.WriteLine("kitab tapilmadi!");
        //}
   }

}

