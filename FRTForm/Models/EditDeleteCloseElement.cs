// 18 08 2020 Created by Tony Horsham 15:56


using System;
using FRTForm.Enums;

namespace FRTForm.Models
{
    public class EditDeleteCloseElement :IFormElement
    {
        public EditDeleteCloseElement(string name)
        {
            Name = name;
            Value = null;
            // by default Visible and Enabled
            // N.B. Visible and Enabled not relevant
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.EditDeleteClose;
        public string Name { get; }
        public string Value { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (EditDeleteCloseElement)this.MemberwiseClone();
        }

        protected bool Equals(EditDeleteCloseElement other)
        {
            return Name == other.Name && Value == other.Value && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((EditDeleteCloseElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EditDeleteCloseElement) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value, NotVisible, NotEnabled, ErrorMsg);
        }

        public static bool operator ==(EditDeleteCloseElement left, EditDeleteCloseElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EditDeleteCloseElement left, EditDeleteCloseElement right)
        {
            return !Equals(left, right);
        }
    }
}