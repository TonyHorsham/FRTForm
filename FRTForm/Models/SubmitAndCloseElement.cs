// 07 07 2020 Created by Tony Horsham 09:21
// Copyright T & D H Family Trust

using System;
using FRTForm.Enums;

namespace FRTForm.Models
{
    public class SubmitAndCloseElement : IFormElement
    {
        public SubmitAndCloseElement(string name, string submitButtonText)
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

        public FormElementType Type => FormElementType.SubmitAndClose;
        public string Name { get; }
        public string SubmitButtonText { get; set; }
        public string Value { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (SubmitAndCloseElement)this.MemberwiseClone();
        }

        protected bool Equals(SubmitAndCloseElement other)
        {
            return Name == other.Name && SubmitButtonText == other.SubmitButtonText && Value == other.Value && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((SubmitAndCloseElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubmitAndCloseElement) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, SubmitButtonText, Value, NotVisible, NotEnabled, ErrorMsg);
        }

        public static bool operator ==(SubmitAndCloseElement left, SubmitAndCloseElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubmitAndCloseElement left, SubmitAndCloseElement right)
        {
            return !Equals(left, right);
        }
    }
}