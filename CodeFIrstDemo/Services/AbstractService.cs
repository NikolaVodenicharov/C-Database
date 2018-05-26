using Forum.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services
{
    public abstract class AbstractService
    {
        private ForumDbContext context;

        public AbstractService(ForumDbContext context)
        {
            this.context = context;
        }

        protected ForumDbContext GetContext {
            get
            {
                return this.context;
            }
        }
    }
}
