﻿namespace SocialNetwork.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property)]
    public class ValidPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueAsString = (string)value;
            var length = valueAsString.Length;

            if (length < 6 || 50 < length)
            {
                this.ErrorMessage = "Invalid password length!";
                return false;
            }

            if (!Regex.IsMatch(valueAsString, @"[A-Z]+"))
            {
                this.ErrorMessage = "Password does not contain an uppercase letter!";
                return false;
            }

            if (!Regex.IsMatch(valueAsString, @"[a-z]+"))
            {
                this.ErrorMessage = "Password does not contain a lowercase letter!";
                return false;
            }

            if (!Regex.IsMatch(valueAsString, @"\d+"))
            {
                this.ErrorMessage = "Password does not contain a digit!";
                return false;
            }

            if (!Regex.IsMatch(valueAsString, @"[!@#$%^&*()_+<>?]+"))
            {
                this.ErrorMessage = "Password does not contain a special symbol!";
                return false;
            }

            return true;
        }
    }
}
