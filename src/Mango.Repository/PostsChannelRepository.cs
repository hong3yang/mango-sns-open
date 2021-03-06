﻿using System.Collections.Generic;
using Mango.Framework.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;

namespace Mango.Repository
{
    public class PostsChannelRepository
    {
        private EFDbContext _dbContext = null;
        public PostsChannelRepository()
        {
            _dbContext = new EFDbContext();
        }
        /// <summary>
        /// 获取帖子频道信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Models.PostsChannelModel> GetPostsChannels()
        {
            var query = from c in _dbContext.m_PostsChannel
                        orderby c.SortCount ascending
                        select new Models.PostsChannelModel() {
                            AppendTime=c.AppendTime.Value,
                            ChannelId=c.ChannelId.Value,
                            ChannelName=c.ChannelName,
                            IsManager=c.IsManager.Value,
                            IsShow=c.IsShow.Value,
                            Remarks=c.Remarks,
                            SortCount=c.SortCount.Value
                        };
            return query;
        }
    }
}
