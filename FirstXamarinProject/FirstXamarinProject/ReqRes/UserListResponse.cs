using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.ReqRes
{
    public class UserListResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string Error { get; set; }
        public Support Support { get; set; }
        public List<User> Data { get; set; }
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
    }

}
