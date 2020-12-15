// 18 06 2020 Created by Tony Horsham 14:32


using System.Collections.Generic;
using FRTForm.Utilities;

namespace FRTForm.Models
{
    /// <summary>
    /// An application will have named forms and code to launch those forms.
    /// This interface means that the implementation of the forms is up to the developer.
    /// </summary>
    public interface IFormSpecs
    {
        public string FormId { get; }
        public List<IFormElement> Elements { get; }
        public IFormProcessor FormProcessor { get; }

        public IFormSpecs Clone();
    }
}