using DAL.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SampleData
    {
        public static void InitDataBase(CVTContext context)
        {
            if (!context.Persons.Any())
            {
                context.Persons.AddRange(
                    new Person() { Name = "Иван", Surname = "Иванов", MiddleName = "Иванович", Position = "Директор", BirthDate = Convert.ToDateTime("1986-04-20"), Organization = "ООО Макси" },
                    new Person() { Name = "Сергей", Surname = "Сергеев", MiddleName = "Сергеевич", Position = "Менеджер", BirthDate = Convert.ToDateTime("1991-01-20"), Organization = "ООО Макси" },
                    new Person() { Name = "Ольга", Surname = "Иванова", MiddleName = "Ивановна", Position = "Бухгалтер", BirthDate = Convert.ToDateTime("1987-12-11"), Organization = "ИП Иванова" },
                    new Person() { Name = "Мария", Surname = "Сергеева", Position = "Продавец", BirthDate = Convert.ToDateTime("1995-06-20"), Organization = "ООО Макси" });

                context.SaveChanges();
            }

            if (!context.Contacts.Any())
            {
                List<Person> personList = context.Persons.ToList();

                int firstPersonIndex = personList.First().Id;

                int lastPersonIndex = personList.Last().Id;

                context.Contacts.AddRange(
                    new ContactInfo() { Type = 1, Value = "8-999-999-99-99", PersonId = firstPersonIndex },
                    new ContactInfo() { Type = 2, Value = "email@email.ru", PersonId = firstPersonIndex },
                    new ContactInfo() { Type = 3, Value = "mySkype", PersonId = firstPersonIndex },
                    new ContactInfo() { Type = 4, Value = "352-522-623", PersonId = firstPersonIndex },
                    new ContactInfo() { Type = 1, Value = "8-999-888-77-99", PersonId = firstPersonIndex },
                    new ContactInfo() { Type = 3, Value = "loginSkype", PersonId = lastPersonIndex },
                    new ContactInfo() { Type = 1, Value = "8-999-777-77-99", PersonId = lastPersonIndex });

                context.SaveChanges();
            }
        }
    }
}
