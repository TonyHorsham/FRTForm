// 29 11 2020 Created by Tony Horsham 13:15

using System;
using FRTForm.Enums;

namespace FRTForm.Models
{
    public class SubmitElement : IFormElement
    {
        public SubmitElement(string name, string submitButtonText)
        {
            Name = name;
            SubmitButtonText = submitButtonText;
            Value = null;
            // by default Visible and Enabled
            // N.B. Visible and Enabled only apply to the Submit button
            //    Close always visible and enabled
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        public bool Equals(IFormElement? other)
        {
            throw new System.NotImplementedException();
        }

        public FormElementType Type => FormElementType.Submit;
        public string Name { get; }
        public string SubmitButtonText { get; set; }
        public string Value { get; set; }// no sensible use, so always null
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (SubmitElement)this.MemberwiseClone();
        }

        protected bool Equals(SubmitElement other)
        {
            return Name == other.Name && SubmitButtonText == other.SubmitButtonText && Value == other.Value && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubmitElement)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, SubmitButtonText, Value, NotVisible, NotEnabled, ErrorMsg);
        }

        public static bool operator ==(SubmitElement left, SubmitElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubmitElement left, SubmitElement right)
        {
            return !Equals(left, right);
        }
    }
}