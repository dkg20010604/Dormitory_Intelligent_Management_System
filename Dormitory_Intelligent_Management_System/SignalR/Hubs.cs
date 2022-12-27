﻿using Microsoft.AspNetCore.SignalR;

namespace Dormitory_Intelligent_Management_System.SignalR
{
    public class Hubs : Hub
    {
        /// <summary>
        /// 向全体连接用户发送数据
        /// </summary>
        /// <param name="data">数据（前端对应函数的参数，大多只是作为提醒内容）</param>
        /// <returns></returns>
        public async Task SendMessage(string data)
        {
            await Clients.All.SendAsync("前端函数名", data);
        }
        /// <summary>
        /// 加入特定的群组
        /// </summary>
        /// <param name="groups">群组列表</param>
        /// <returns>无返回值</returns>
        public async Task JoinGroup(List<string> groups)//可传入学号，经过查询判断加入那些组
        {
            foreach (var group in groups)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, group);
            }
        }
        /// <summary>
        /// 向特定的群组发送消息
        /// </summary>
        /// <param name="groups">群组列表</param>
        /// <param name="data">要发送的数据</param>
        /// <returns>无返回值</returns>
        public async Task SendGroup(List<string> groups, string data)
        {
                await Clients.Groups(groups).SendAsync("TSMethorName", data);
        }

    }
}
