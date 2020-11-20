// 07 07 2020 Created by Tony Horsham 09:21
// Copyright T & D H Family Trust

using System;
using FlexResForm.Enums;

namespace FlexResForm.Models
{
    public class CloseElement : IFormElement
    {
        public CloseElement(string name)
        {
            Name = name;
            Value = null;
            // by default Visible and Enabled
            // Enabled but not Visible does not make sense
            //   and is irrelevant
            NotVisible = false;
            NotEnabled = NotVisible;
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.Close;
        public string Name { get; }
        public string Value { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (CloseElement)this.MemberwiseClone();
        }

        protected bool Equals(CloseElement other)
        {
            return Name == other.Name && Value == other.Value && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((CloseElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CloseElement) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value, NotVisible, NotEnabled, ErrorMsg);
        }

        public static bool operator ==(CloseElement left, CloseElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CloseElement left, CloseElement right)
        {
            return !Equals(left, right);
        }
    }
}