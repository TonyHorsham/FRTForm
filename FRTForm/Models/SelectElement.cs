// 23 08 2020 Created by Tony Horsham 15:29
// Copyright T & D H Family Trust

using System;
using System.Collections.Generic;
using FlexResForm.Enums;

namespace FlexResForm.Models
{
    public class SelectElement : IFormElement
    {
        // ***************************************************************************************
        //N.B. did not work out how to use data binding with InputSelect so implemented as html select
        // ***************************************************************************************
        public SelectElement(string name, string label, string icon)
        {
            Name = name;
            Options = new Dictionary<int, string>();
            Label = label;
            Icon = icon; // material-icons name
            // by default Visible and Enabled
            NotVisible = false;
            NotEnabled = false;
            ErrorMsg = null;
        }

        
        public FormElementType Type => FormElementType.Select;
        public string Name { get; }
        public string Value { get; set; }
        // currently only Block and Service used, both have Id and CalendarId
        // in future likely to include Location, but that only has LocationId (could be changed to Id)
        // SO is possible to create ISelectListItem to use instead of object
        public Dictionary<int, string> Options { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public bool DisplayLabel { get; set; }// arguably redundant
        public bool LabelStacked { get; set; }
        public bool DisplayIcon { get; set; }
        public bool IconStacked { get; set; }
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }
        public IFormElement Clone()
        {
            return (SelectElement)this.MemberwiseClone();
        }

        protected bool Equals(SelectElement other)
        {
            return Name == other.Name && Value == other.Value && Equals(Options, other.Options) && Label == other.Label && Icon == other.Icon && DisplayLabel == other.DisplayLabel && LabelStacked == other.LabelStacked && DisplayIcon == other.DisplayIcon && IconStacked == other.IconStacked && NotVisible == other.NotVisible && NotEnabled == other.NotEnabled && ErrorMsg == other.ErrorMsg;
        }

        public bool Equals(IFormElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != this.GetType()) return false;
            return Equals((SelectElement)other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SelectElement) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Value);
            hashCode.Add(Options);
            hashCode.Add(Label);
            hashCode.Add(Icon);
            hashCode.Add(DisplayLabel);
            hashCode.Add(LabelStacked);
            hashCode.Add(DisplayIcon);
            hashCode.Add(IconStacked);
            hashCode.Add(NotVisible);
            hashCode.Add(NotEnabled);
            hashCode.Add(ErrorMsg);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(SelectElement left, SelectElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SelectElement left, SelectElement right)
        {
            return !Equals(left, right);
        }
    }
}