using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voters.Models
{
    public class Models
    {

    }

    public class UserItem
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class VoteItem
    {
        public ulong UserBelong { get; set; }
        public string Topic { get; set; }
        public string Desc { get; set; }
        public ulong OverdueTime { get; set; }
        public ulong CreateTime { get; set; }
        public uint  VoteAble { get; set; }
        public long MultiNum { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
    }

    public class ItemItem
    {
        public long VoteId { get; set; }
        public long Score { get; set; }
        public string DescPicUrl { get; set; }
        public string Desc { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}

