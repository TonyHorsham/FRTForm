// 19 09 2020 Created by Tony Horsham 14:06


namespace FRTForm.Parameters
{
    /// <summary>
    ///  Generally just 'passed through' rather than any values used in the project
    ///  Other than IApplicationSettings.AppFormSpecsDictionary, the list of form specifications.
    /// 
    ///  22SEP20 Decision that any form element that needs extra properties (e.g. has a custom component), 
    ///  should be accommodated in the interface, to avoid the need to cast to access the properties.
    /// </summary>
    public interface IAllParams
    {
        public IAppParams AppParams { get; }

        
    }
}