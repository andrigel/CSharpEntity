using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entityes;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            Random rand = new Random();
            if (!context.author.Any())
            {
                context.author.Add(new Author { Name = "Стивен", Surname = "Кинг" });
                context.author.Add(new Author { Name = "Роберт", Surname = "Гэлбрейт" });
                context.author.Add(new Author { Name = "Коллин", Surname = "Маккалоу" });
                context.author.Add(new Author { Name = "Джеймс", Surname = "Боуэн" });
                context.author.Add(new Author { Name = "Джордж", Surname = "Оруэлл" });
                context.author.Add(new Author { Name = "Джордан", Surname = "Белфорт" });
                context.author.Add(new Author { Name = "Кассанда", Surname = "Клэр" });
                context.SaveChanges();
            }
            if (!context.book.Any())
            {
                context.book.Add(new Book { Name ="Город потеряных душ",Price = 200, Author = context.author.Find(7) });
                context.book.Add(new Book { Name = "Волк с Уолл-стритт", Price = 150, Author = context.author.Find(6) });
                context.book.Add(new Book { Name = "Страна радости", Price = 400, Author = context.author.Find(1) });
                context.book.Add(new Book { Name = "Мир глазами кота Боба", Price = 200, Author = context.author.Find(4) });
                context.book.Add(new Book { Name = "Зов кукушки", Price = 150, Author = context.author.Find(2) });
                context.book.Add(new Book { Name = "Поющие в терновнике", Price = 100, Author = context.author.Find(3) });
                context.book.Add(new Book { Name = "1984", Price = 200, Author = context.author.Find(5) });
                context.book.Add(new Book { Name = "Оно", Price = 300, Author = context.author.Find(1) });
                context.SaveChanges();
            }
            if(!context.reader.Any())
            {
                context.reader.Add(new Reader { Name = "Валентина", Surname = "Кравчук", Patronymic = "Анатолійович", Region = "Львівська", District = "Львів", Telephone = "0502019324", TicketNumber = 33146 });
                context.reader.Add(new Reader { Name = "Алла", Surname = "Мірошниченко", Patronymic = "Янович", Region = "Донецька", District = "Донецьк", Telephone = "0938543557", TicketNumber = 29275 });
                context.reader.Add(new Reader { Name = "Олег", Surname = "Пономаренко", Patronymic = "Миколайович", Region = "Київська", District = "Київ", Telephone = "0503099380", TicketNumber = 64181 });
                context.reader.Add(new Reader { Name = "Олексій", Surname = "Іванченко", Patronymic = "Олександрович", Region = "Луганська", District = "Луганськ", Telephone = "0505083359", TicketNumber = 76851 });
                context.reader.Add(new Reader { Name = "Олексій", Surname = "Таращук", Patronymic = "Іванович", Region = "Миколаївська", District = "Миколаїв", Telephone = "0506489765", TicketNumber = 75678 });
                context.reader.Add(new Reader { Name = "Іван", Surname = "Кравчук", Patronymic = "Валентинович", Region = "Дніпропетровська", District = "Дніпропетровськ", Telephone = "0637827497", TicketNumber = 48074 });
                context.reader.Add(new Reader { Name = "Василь", Surname = "Шинкаренко", Patronymic = "Євгенович", Region = "Закарпатська", District = "Ужгород", Telephone = "0671756456", TicketNumber = 76558 });
                context.SaveChanges();
            }
            if (!context.log.Any())
            {
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.log.Add(new Log { Reader = context.reader.Find(rand.Next(1, 8)), Book = context.book.Find(rand.Next(1, 8)), DateOfIssue = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)), DateOfReturn = new DateTime(rand.Next(2011, 2020), rand.Next(1, 12), rand.Next(1, 30)) });
                context.SaveChanges();
            }

        }
    }
}