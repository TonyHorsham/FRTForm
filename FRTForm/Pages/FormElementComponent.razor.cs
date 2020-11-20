using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FRTForm.Models;
using FRTForm.Settings;
using FRTForm.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FRTForm.Pages
{
    public partial class FormElementComponent
    {
        // need to pass back to IFormProcessor
        [Parameter] public IAllSettings AllSettings { get; set; }
        [Parameter] public List<IFormElement> Elements { get; set; }
        [Parameter] public IFormProcessor FormProcessor { get; set; }
        [Parameter] public string ElementName { get; set; }
        // this parameter relates to the form, NOT the individual element
        [Parameter] public bool FormDisplayOnly { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> OnCloseCallback { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> OnEditCallback { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> OnDeleteCallback { get; set; }
        [Parameter]//general click events
        public EventCallback<string> OnClickCallback { get; set; }

        private IFormElement _formElement;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            _formElement = Elements.FirstOrDefault(e => e.Name == ElementName);
        }

        async void HandleClick()
        {
            // invoke the call back
            await OnClickCallback.InvokeAsync(ElementName);
        }
        void UpdateElements(ChangeEventArgs c)
        {
            // unable to get onchange to fire with <InputText> but OK with <input />

            // ValidationMessage support is nice because it works with js in the browser
            // However I have not been able to bind to a model.property dynamically
            // Using oninput means the server is called at every keystroke, so no
            // likely performance issues if use own validation (round trip likely to take more time)
            // PLUS intention is to use in browser version, and want to validate using other field values
            _formElement.Value = c.Value.ToString();
            // call method to change the other elements
            FormProcessor.UpdateElementsAsync(Elements, AllSettings, FormDisplayOnly);
        }

        class ElementValidator : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value,
                ValidationContext validationContext)
            {
                return new ValidationResult(" test message");
            }
        }
    }
}
