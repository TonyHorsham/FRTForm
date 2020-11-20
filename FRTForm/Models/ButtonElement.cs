// 07 07 2020 Created by Tony Horsham 09:35


using System;
using FRTForm.Enums;

namespace FRTForm.Models
{
    public class ButtonElement : IFormElement
    {
        public ButtonElement(string name, string value, string buttonType,
            string buttonClass)
        {
            Name = name;
            Value = value;
            ButtonType = buttonType;
            ButtonClass = buttonClass;
            // by default Visible and Enabled
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.Button;
        public string Name { get; }
        public string ButtonType { get; }
        public string ButtonClass { get; }
        public string Value { get; set; }
        public bool ConfirmationRequired { get; set; }// launch ConfirmationForm
        public string ActionName { get; set; }// ConfirmationForm.ActionName
        public string ActionDescription { get; set; }// ConfirmationForm.ActionDescription
        public bool CloseForm { get; set; }// if true the action should close the form
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (ButtonElement) this.MemberwiseClone();
        }

        protected bool Equals(ButtonElement other)
        {
            return Name == other.Name && ButtonType == other.ButtonType && ButtonClass == other.ButtonClass && Value == other.Value && ConfirmationRequired == other.ConfirmationRequired && ActionName == other.ActionName && ActionDescription == other.ActionDescription && CloseForm == other.CloseForm && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((ButtonElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ButtonElement) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(ButtonType);
            hashCode.Add(ButtonClass);
            hashCode.Add(Value);
            hashCode.Add(ConfirmationRequired);
            hashCode.Add(ActionName);
            hashCode.Add(ActionDescription);
            hashCode.Add(CloseForm);
            hashCode.Add(NotVisible);
            hashCode.Add(NotEnabled);
            hashCode.Add(ErrorMsg);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(ButtonElement left, ButtonElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ButtonElement left, ButtonElement right)
        {
            return !Equals(left, right);
        }
    }
}