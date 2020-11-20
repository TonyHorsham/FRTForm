// 11 07 2020 Created by Tony Horsham 14:04
// Copyright T & D H Family Trust

using System;
using FlexResForm.Enums;

namespace FlexResForm.Models
{
    public class TitleElement : IFormElement
    {
        public TitleElement(string name, string value)
        {
            Name = name;
            Value = value;
            // by default Visible and Enabled
            NotVisible = false;
            NotEnabled = true;// never enabled
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.Title;
        public string Name { get; }
        public string Value { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }// should never be changed, but need as prop to implement the interface
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (TitleElement)this.MemberwiseClone();
        }

        protected bool Equals(TitleElement other)
        {
            return Name == other.Name && Value == other.Value && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((TitleElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TitleElement) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NotVisible.GetHashCode();
                hashCode = (hashCode * 397) ^ NotEnabled.GetHashCode();
                hashCode = (hashCode * 397) ^ (ErrorMsg != null ? ErrorMsg.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(TitleElement left, TitleElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TitleElement left, TitleElement right)
        {
            return !Equals(left, right);
        }
    }
}