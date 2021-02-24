using FirstXamarinProject.Helpers;
using FirstXamarinProject.ReqRes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.Services
{
    public class UserService
    {
        public static LoginResponse Login(string email, string password)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password,
                };
                var response = App.RestHelper.Post<LoginRequest, LoginResponse>(Constants.Url, "login", loginRequest);
                response.IsSuccess = response.Token != null;
                return response;
            }
            catch (Exception exp)
            {
                return new LoginResponse { Error = "Exception: " + exp.Message };
            }
        }

        public static UserResponse GetUser(int id)
        {
            try
            {
                var response = App.RestHelper.Get<UserResponse>(Constants.Url, "users/" + id);
                response.IsSuccess = response.Data != null;
                return response;
            }
            catch (Exception exp)
            {
                return new UserResponse { Error = "Exception: " + exp.Message };
            }
        }

        public static UserListResponse GetUsers(int page = 1)
        {
            try
            {
                var response = App.RestHelper.Get<UserListResponse>(Constants.Url, $"users?page={page}");
                response.IsSuccess = response.Data.Count > 0;
                return response;
            }
            catch (Exception exp)
            {
                return new UserListResponse { Error = "Exception: " + exp.Message };
            }
        }
    }
}
