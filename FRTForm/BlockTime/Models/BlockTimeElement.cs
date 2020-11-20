// 20 08 2020 Created by Tony Horsham 17:13
// Copyright T & D H Family Trust

using FlexResForm.Enums;
using FlexResForm.Models;

namespace FlexResForm.BlockTime.Models
{
    public class BlockTimeElement :IFormElement
    {
        public BlockTimeElement(string name, string label, string icon, bool required)
        {
            Name = name;
            Label = label;
            Icon = icon; // material-icons name
            Required = required;
            Value = null;// unlikely to be useful for string <-> DateTimeOffset conversions
            // by default BlockTime elements Visible and Enabled
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        public FormElementType Type => FormElementType.BlockTime;
        public string Name { get; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public bool DisplayLabel { get; set; }// arguably redundant
        public bool LabelStacked { get; set; }
        public bool DisplayIcon { get; set; }
        public bool IconStacked { get; set; }
        public bool Required { get; set; }
        public bool  IsStart { get; set; }//TODO use enum with Start, End and Duration
        public string Value { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (BlockTimeElement)this.MemberwiseClone();
        }

        protected bool Equals(BlockTimeElement other)
        {
            return Name == other.Name && Label == other.Label && Icon == other.Icon && DisplayLabel == other.DisplayLabel && LabelStacked == other.LabelStacked && DisplayIcon == other.DisplayIcon && IconStacked == other.IconStacked && Required == other.Required && IsStart == other.IsStart && Value == other.Value && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((BlockTimeElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BlockTimeElement) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Icon != null ? Icon.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DisplayLabel.GetHashCode();
                hashCode = (hashCode * 397) ^ LabelStacked.GetHashCode();
                hashCode = (hashCode * 397) ^ DisplayIcon.GetHashCode();
                hashCode = (hashCode * 397) ^ IconStacked.GetHashCode();
                hashCode = (hashCode * 397) ^ Required.GetHashCode();
                hashCode = (hashCode * 397) ^ IsStart.GetHashCode();
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NotVisible.GetHashCode();
                hashCode = (hashCode * 397) ^ NotEnabled.GetHashCode();
                hashCode = (hashCode * 397) ^ (ErrorMsg != null ? ErrorMsg.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(BlockTimeElement left, BlockTimeElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BlockTimeElement left, BlockTimeElement right)
        {
            return !Equals(left, right);
        }
    }
}