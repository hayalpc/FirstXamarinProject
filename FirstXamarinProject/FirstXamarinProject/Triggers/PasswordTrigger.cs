using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirstXamarinProject.Triggers
{
    public class PasswordTrigger : TriggerAction<Entry>
    {
        Entry firstEntry;

        public Entry FirstEntry { get => firstEntry; set => firstEntry = value; }

        protected override void Invoke(Entry sender)
        {
            if (sender.Text.Equals(FirstEntry.Text))
            {
                sender.TextColor = Color.AliceBlue;
            }
            else
            {
                sender.TextColor = Color.Red;
            }
        }
    }
}
