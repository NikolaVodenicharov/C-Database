using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services.Interfaces
{
    public interface IReplyService
    {
        Reply Create();
        void Delete(int replyId);
    }
}
