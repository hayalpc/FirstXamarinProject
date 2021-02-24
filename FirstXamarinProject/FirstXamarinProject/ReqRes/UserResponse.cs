using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.ReqRes
{
    public class UserResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string Error { get; set; }
        public Support Support { get; set; }
        public User Data { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
