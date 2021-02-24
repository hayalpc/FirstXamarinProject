using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.Models
{
    public class Message
    {
        string topic, content;

        public string Topic { get => topic; set => topic = value; }
        public string Content { get => content; set => content = value; }
    }
}
