using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirstXamarinProject.Models
{
    public class User
    {
        int id;
        string email, first_name, last_name, avatar;
        Rectangle layoutBounds = new Rectangle(0.5, 0.5, 0.8, 0.8);

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public ImageSource AvatarSource
        {
            get
            {
                return ImageSource.FromUri(new Uri(Avatar));
            }
        }
        public string Full_name
        {
            get
            {
                return $"{First_name} {Last_name}";
            }
        }

        public Rectangle LayoutBounds
        {
            get => layoutBounds;
            set => layoutBounds = value;
        }
    }
}
