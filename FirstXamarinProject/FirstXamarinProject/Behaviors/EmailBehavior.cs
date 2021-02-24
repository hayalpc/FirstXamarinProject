using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FirstXamarinProject.Behaviours
{
    public class EmailBehavior : Behavior<Entry>
    {
        public const string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(EmailBehavior), false, BindingMode.OneTime, null);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextchanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextchanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextchanged(object sender, TextChangedEventArgs args)
        {
            IsValid = Regex.IsMatch(args.NewTextValue, emailRegex);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
