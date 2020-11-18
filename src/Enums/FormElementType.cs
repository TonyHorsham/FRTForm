// 18 06 2020 Created by Tony Horsham 15:35
// Copyright T & D H Family Trust

namespace FRTForm.src.Enums
{
    public enum FormElementType
    {
        //20AUG20 all except Panel and Text have a model + in FormElementComponent
        SubmitAndClose,
        EditDeleteClose,
        Close,
        Title,// 'full' width text, unless specify width and justification
        //TODO 20AUG20 - Input does not cover all InputType options - a lot of work required in FormElementComponent
        Input,// can specify a required value (confirm email/sms code)
        Text,// NOT implemented - use disabled Input (Text or Select)
        Panel,// NOT implemented - use disabled TextArea Input
        Button,
        BlockTime,
        Select,
        TextArea // NOT implemented yet
    }
}