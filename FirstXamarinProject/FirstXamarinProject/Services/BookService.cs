using FirstXamarinProject.Database;
using FirstXamarinProject.Extensions;
using FirstXamarinProject.ReqRes;
using FirstXamarinProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.Services
{
    public class BookService
    {

        public static bool Delete(int id)
        {
            return App.DbService.Delete<Book>(id).Result > 0;
        }

        public static DataResponse<BookVM> Add(BookVM bookVM)
        {
            var response = new DataResponse<BookVM>();
            response.IsSuccess = false;
            response.Data = bookVM;
            try
            {
                var model = new Book
                {
                    Name = bookVM.Name,
                    Author = bookVM.Author,
                    Description = bookVM.Description,
                    Category = bookVM.Category,
                    Year = bookVM.Year,
                    Page = bookVM.Page,
                    Image = bookVM.Image,
                    CreateDate = DateTime.Now,
                };
                bookVM.Id = App.DbService.Add(model).Result;
                if (bookVM.Id > 0)
                    response.IsSuccess = true;
                else
                    response.Error = "Ekleme işlemi başarısız";
            }
            catch (Exception exp)
            {
                response.Error = $"Bir hata oluştu({exp.Message})";
            }

            return response;
        }

        public static DataResponse<BookVM> Update(BookVM bookVM)
        {
            var response = new DataResponse<BookVM>();
            response.IsSuccess = false;
            response.Data = bookVM;
            try
            {
                var model = new Book
                {
                    Id = bookVM.Id,
                    Name = bookVM.Name,
                    Author = bookVM.Author,
                    Description = bookVM.Description,
                    Category = bookVM.Category,
                    Year = bookVM.Year,
                    Page = bookVM.Page,
                    Image = bookVM.Image,
                    UpdateDate = DateTime.Now,
                };
                bookVM.Id = App.DbService.Update(model).Result;
                if (bookVM.Id > 0)
                    response.IsSuccess = true;
                else
                    response.Error = "Ekleme işlemi başarısız";
            }
            catch (Exception exp)
            {
                response.Error = $"Bir hata oluştu({exp.Message})";
            }

            return response;
        }

        public static DataResponse<List<BookVM>> GetList(int page)
        {
            var list = App.DbService.GetTable<Book>().OrderByDescending(x => x.Id).Skip(page * 5).Take(5).ToListAsync().Result;
            var response = new DataResponse<List<BookVM>>();
            if (list != null)
            {
                response.Data = list.Convert<List<BookVM>>();
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Error = "NotFound";
            }
            return response;
        }
    }
}
