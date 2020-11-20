// 26 08 2020 Created by Tony Horsham 14:57
// Copyright T & D H Family Trust

using System;
using FlexResForm.Enums;

namespace FlexResForm.Models
{
    public class TextAreaElement :IFormElement
    {
        public TextAreaElement(string name, string label, string icon)
        {
            Name = name;
            Label = label;
            Icon = icon;
            // by default Visible and Enabled
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.TextArea;
        public string Name { get; }
        public string Value { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public string RightIcon { get; set; }// option to show an icon to RHS of textarea
        public string Placeholder { get; set; }
        public bool DisplayLabel { get; set; }// arguably redundant
        public bool LabelStacked { get; set; }
        public bool DisplayIcon { get; set; }
        public bool IconStacked { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (TextAreaElement)this.MemberwiseClone();
        }

        protected bool Equals(TextAreaElement other)
        {
            return Name == other.Name && Value == other.Value && Label == other.Label && Icon == other.Icon && RightIcon == other.RightIcon && Placeholder == other.Placeholder && DisplayLabel == other.DisplayLabel && LabelStacked == other.LabelStacked && DisplayIcon == other.DisplayIcon && IconStacked == other.IconStacked && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((TextAreaElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TextAreaElement) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Value);
            hashCode.Add(Label);
            hashCode.Add(Icon);
            hashCode.Add(RightIcon);
            hashCode.Add(Placeholder);
            hashCode.Add(DisplayLabel);
            hashCode.Add(LabelStacked);
            hashCode.Add(DisplayIcon);
            hashCode.Add(IconStacked);
            hashCode.Add(NotVisible);
            hashCode.Add(NotEnabled);
            hashCode.Add(ErrorMsg);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TextAreaElement left, TextAreaElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TextAreaElement left, TextAreaElement right)
        {
            return !Equals(left, right);
        }
    }
}