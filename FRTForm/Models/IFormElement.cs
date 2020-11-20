// 16 06 2020 Created by Tony Horsham 15:58


using System;
using FRTForm.Enums;

namespace FRTForm.Models
{
    /// <summary>
    /// Interface to hold details of form elements
    /// N.B. Name MUST be unique within any IFormSpecs
    /// </summary>
    public interface IFormElement : IEquatable<IFormElement>
    {
        public FormElementType Type { get; }
        public string Name { get; }
        public string Value { get; set; }
        //TODO NotVisible is actually not rendered
        // hidden elements are not supported
        //YAGNI - deal with it when needed
        public bool NotVisible { get; set; }
        public bool NotEnabled { get; set; }
        public string ErrorMsg { get; set; }

        public IFormElement Clone();
    }
}