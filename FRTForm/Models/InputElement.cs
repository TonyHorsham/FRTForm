// 11 06 2020 Created by Tony Horsham 13:53
// Copyright T & D H Family Trust

using System;
using FRTForm.Enums;

namespace FRTForm.Models
{
    public class InputElement :IFormElement
    {
        public readonly InputType InputType;
        public readonly int Min;
        public readonly int Max;
        //TODO specify if display label, icon (and readonly property for each), or none

        public InputElement(InputType inputType, string name, string label,
            string placeholder, int min, int max, bool required)
        {
            Name = name;
            InputType = inputType;
            Label = label;
            Placeholder = placeholder;
            Min = min;
            Max = max;
            Required = required;
            Value = null;
            ExpectedValue = null;
            // by default input elements Visible and Enabled
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.Input;
        public string Name { get; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public bool Required { get; set; }
        public string Value { get; set; }
        // used for Code and ConfirmEmail
        public string ExpectedValue { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (InputElement)this.MemberwiseClone();
        }

        protected bool Equals(InputElement other)
        {
            return InputType == other.InputType && Min == other.Min && Max == other.Max && Name == other.Name && Label == other.Label && Placeholder == other.Placeholder && Required == other.Required && Value == other.Value && ExpectedValue == other.ExpectedValue && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((InputElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InputElement) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add((int) InputType);
            hashCode.Add(Min);
            hashCode.Add(Max);
            hashCode.Add(Name);
            hashCode.Add(Label);
            hashCode.Add(Placeholder);
            hashCode.Add(Required);
            hashCode.Add(Value);
            hashCode.Add(ExpectedValue);
            hashCode.Add(NotVisible);
            hashCode.Add(NotEnabled);
            hashCode.Add(ErrorMsg);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(InputElement left, InputElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InputElement left, InputElement right)
        {
            return !Equals(left, right);
        }
    }
}