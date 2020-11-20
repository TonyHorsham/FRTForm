// 11 06 2020 Created by Tony Horsham 13:59
// Copyright T & D H Family Trust

namespace FRTForm.Enums
{
    public enum InputType
    {
        //TODO all will need to be dealt with in FormElementComponent
        // first group of types match HTML5 <input type="xxx">
        //
        Text,
        Email,// supported in all recent browser versions except Opera Mini
        Tel,// supported in all recent browser versions except Opera Mini
        Number,// supported in all recent browser versions except Opera Mini
        Password, // not supported on Opera Mini, some Android browsers

        Time // specific to Calendar and includes Duration
    }
}