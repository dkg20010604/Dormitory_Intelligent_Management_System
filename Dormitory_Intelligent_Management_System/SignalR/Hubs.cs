using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using Model.DbModels;
using SqlSugar;
using SqlSugar.IOC;

namespace Dormitory_Intelligent_Management_System.SignalR
{
    public class UserId : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.GetHttpContext().Request.Cookies["userid"];
        }
    }
    /// <summary>
    /// </summary>
    public class Hubs : Hub
    {
        /// <summary>
        /// 向全体连接用户发送数据
        /// </summary>
        /// <param name="data">数据（前端对应函数的参数，大多只是作为提醒内容）</param>
        /// <returns></returns>
        public async Task SendMessage(string data)
        {
            await Clients.All.SendAsync("getmessagr", data);
        }

        /// <summary>
        /// 加入群组
        /// </summary>
        /// <param name="id">学号或工号</param>
        /// <param name="power">身份: 1:学生 2:老师 3:后勤 4:超管</param>
        /// <returns></returns>
        public async Task JoinGroup(string id, int power)
        {
            //若是学生
            if (power == 1)
            {
                var user = await DbScoped.SugarScope.Queryable<students_info>().Includes(s => s.class_Info, c => c.major_Info).Includes(s => s.live_Info).InSingleAsync(id);
                //加入班级群
                await Groups.AddToGroupAsync(Context.ConnectionId, "Stu_Class_" + user.class_id.ToString());
                //加入专业群
                await Groups.AddToGroupAsync(Context.ConnectionId, "Stu_Major_" + user.class_Info.major_id.ToString());
                //加入学院群
                await Groups.AddToGroupAsync(Context.ConnectionId, "Stu_College_" + user.class_Info.major_Info.college_id.ToString());
                //加入房间组
                await Groups.AddToGroupAsync(Context.ConnectionId, "Room_" + user.live_Info.room_id.ToString());
                //是舍长，加入本楼舍长群
                if (user.live_Info.role)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Role_" + user.live_Info.build_id.ToString());
                }
                //院宿检部加入本院宿检部群
                if (SqlFunc.JsonArrayAny(user.powers,1))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "College_Manage_" + user.class_Info.major_Info.college_id.ToString());
                }
                //校宿检部加入校宿检部群
                if (SqlFunc.JsonArrayAny(user.powers, 2))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Fiele_Inspect");
                }
            }
            //若是老师
            else if (power == 2)
            {
                var user = await DbScoped.SugarScope.Queryable<teachers>().InSingleAsync(id);
                //加入所有老师群
                await Groups.AddToGroupAsync(Context.ConnectionId, "Teacher_All");
                //加入本院老师群
                await Groups.AddToGroupAsync(Context.ConnectionId, "Teacher_" + user.college_id.ToString());

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
            await Clients.Groups(groups).SendAsync("TSMethodName", data);
        }

        /// <summary>
        /// 向发送者发消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task SendBack(string data)
        {
            await Clients.Caller.SendAsync("methodname", data);
        }

        public override Task OnConnectedAsync()
        {
            var a = Context.UserIdentifier;
            Console.WriteLine(a);
            return base.OnConnectedAsync();
        }
    }
}
