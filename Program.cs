using System;
using System.Data.Entity.Validation;
using Pavilions;
using LoaderImages;

namespace Imageload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            string dirPath = "";

            try
            {
                foreach (var m in PavilionEntities.GetContext().Malls_)
                {
                    dirPath = $"C:\\Users\\user\\Desktop\\Учебная практика июнь 2023\\Картинки ТЦ\\{i}.jpg";
                    m.MallPicture = Loaderimages.LoadPhoto(dirPath);
                    i++;
                }

                i = 1;
                foreach (var e in PavilionEntities.GetContext().Employees_)
                {
                    dirPath = $"C:\\Users\\user\\Desktop\\Учебная практика июнь 2023\\Картинки Сотрудники\\{i}.jpg";
                    e.EmployeePhoto = Loaderimages.LoadPhoto(dirPath);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                PavilionEntities.GetContext().SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                    Console.WriteLine("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.WriteLine(err.ErrorMessage + "");
                    }
                }
            }

        }
    }
}
