// 21 11 2020 Created by Tony Horsham 16:12

using FRTForm.BlockTime.Models;

namespace Demo.FormClasses.Models
{
    public readonly struct TestUser : IUser
    {
        public TestUser(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public string UserId { get; }
        public string UserName { get; }
    }
}