using FirstXamarinProject.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.ReqRes
{
    public class DataResponse<TModel> where TModel : new()
    {
        public bool IsSuccess { get; set; } = false;
        public string Error { get; set; }
        public TModel Data { get; set; }

    }
}
