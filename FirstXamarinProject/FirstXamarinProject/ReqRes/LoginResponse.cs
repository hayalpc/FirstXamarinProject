using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.ReqRes
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
