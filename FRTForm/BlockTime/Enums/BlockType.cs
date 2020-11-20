namespace FlexResForm.BlockTime.Enums
{
    /// <summary>
    /// Note there are no overlapping blocks
    /// Also different users will see different block types for the same block
    ///   e.g. Once one client has attempted to make a booking, others will see it as unavailable
    /// </summary>
    public enum BlockType
    { 
        //TODO could be a struct loaded from the db for customisation
        // Id, Name, StylingStr, ChildTypeIds (List<int> of Ids - 'link' table in db)
        // N.B. ChildTypeIds have provider and client variants

        // 'hard' blocks persisted - rest calculated
        // Provider has complete control over 'hard' blocks
        NotAvailable,
        Requested,
        Booked,
        Declined, // persisted but only shown in Schedule view
        // Buffer is the padding between Bookings (& Requested)
        //  will show up as NotAvailable for other clients
        // not persisted
        Buffer,
        NotTakingBookings,
        // not persisted - calculated
        Available
    }
}