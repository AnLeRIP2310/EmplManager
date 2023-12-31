﻿using DAL;
using DAL.Model;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace BUS
{
    public class EmpolyeeManager
    {
        //Lấy tất cả dữ liệu người dùng
        public static List<EmpolyeeInfor> GetAllEmpolyee()
        {
            var query = new InlineQuery();
            string sqlquery = "SELECT users.Id, users.GoogleId, users.Avatar, users.Email, users.DisplayName, users.AtCreate, " +
                "users.UserType, users.Status, dbo.UserInfor.Job, dbo.UserInfor.PhoneNumber, dbo.UserInfor.Department, " +
                "dbo.UserInfor.Gender, dbo.UserInfor.DateOfBirth, dbo.UserInfor.Address " +
                "FROM dbo.Users INNER JOIN dbo.UserInfor ON UserInfor.UserId = Users.Id ";
            var result = query.ExecuteTypedList<EmpolyeeInfor>(sqlquery);
            return result;
        }

        //Lấy dữ liệu người dùng bằng Id
        public static EmpolyeeInfor GetEmpolyeeById(int Id)
        {
            var query = new InlineQuery();
            string sqlquery = $@"SELECT users.Id, users.GoogleId, users.Avatar, users.Email, users.DisplayName, users.AtCreate, 
                users.UserType, users.Status, dbo.UserInfor.Job, dbo.UserInfor.PhoneNumber, dbo.UserInfor.Department, 
                dbo.UserInfor.Gender, dbo.UserInfor.DateOfBirth, dbo.UserInfor.Address 
                FROM dbo.Users INNER JOIN dbo.UserInfor ON UserInfor.UserId = Users.Id WHERE users.Id = {Id}";

            var result = query.ExecuteTypedList<EmpolyeeInfor>(sqlquery);
            return result.FirstOrDefault();
        }

        //Tìm kiếm dữ liệu người dùng bằng DisplayName, Job và Id
        public static List<EmpolyeeInfor> SearchEmpolyee(string SearchContent)
        {
            var query = new InlineQuery();
            string sqlquery = $"SELECT users.Id, users.GoogleId, users.Avatar, users.Email, users.DisplayName, users.AtCreate, users.UserType, " +
                $"users.Status, dbo.UserInfor.Job, dbo.UserInfor.PhoneNumber, dbo.UserInfor.Department, dbo.UserInfor.Gender, " +
                $"dbo.UserInfor.DateOfBirth, dbo.UserInfor.Address FROM dbo.Users INNER JOIN dbo.UserInfor ON UserInfor.UserId = Users.Id " +
                $"WHERE DisplayName LIKE N'%{SearchContent}%' OR Users.Id Like N'%{SearchContent}%' OR Job Like N'%{SearchContent}%' " +
                $"OR users.Email Like N'%{SearchContent}%' OR UserInfor.PhoneNumber Like N'%{SearchContent}%' OR UserInfor.Department Like N'%{SearchContent}%'";

            var result = query.ExecuteTypedList<EmpolyeeInfor>(sqlquery);
            return result;
        }

        //Lọc dữ liệu người dùng bằng Status
        public static List<EmpolyeeInfor> FilterEmpolyeeForStatus(int Status)
        {
            var query = new InlineQuery();
            string sqlquery = $@"SELECT users.Id, users.GoogleId, users.Avatar, users.Email, users.DisplayName, users.AtCreate, 
                        users.UserType, users.Status, dbo.UserInfor.Job, dbo.UserInfor.PhoneNumber, dbo.UserInfor.Department, 
                        dbo.UserInfor.Gender, dbo.UserInfor.DateOfBirth, dbo.UserInfor.Address 
                        FROM dbo.Users INNER JOIN dbo.UserInfor ON UserInfor.UserId = Users.Id WHERE users.Status = {Status}";
            var result = query.ExecuteTypedList<EmpolyeeInfor>(sqlquery);
            return result;
        }

        //Thay đổi trạng thái tài khoản
        public static void ChangeStatusUer(int Status, int Id)
        {
            var query = new InlineQuery();
            string sqlquery = $"UPDATE dbo.Users SET Status = {Status} WHERE Id = {Id}";
            query.Execute(sqlquery);
        }

        //Thay đổi trạng thái tài khoản cho các tài khoản được chọn
        public static void ChangeStatusAllSelectUser(int Status, int[] userId)
        {
            var query = new InlineQuery();
            string userIds = string.Join(",", userId);
            string sqlquery = $"UPDATE dbo.Users SET Status = {Status} WHERE Id IN ({userIds})";
            query.Execute(sqlquery);
        }

        //Xoá tài khoản cho các tài khoản được chọn
        public static void DeleteAlluserSelect(int[] userId)
        {
            var query = new InlineQuery();
            string userIds = string.Join(",", userId);
            string sqlquery = $"DELETE FROM UserInfor WHERE UserId IN ({userIds})";
            query.Execute(sqlquery);
            sqlquery = $"DELETE FROM Users WHERE Id IN ({userIds})";
            query.Execute(sqlquery);
        }

        //Thay đổi quyền tài khoản
        public static void ChangeUserType(int UserType, int UserId)
        {
            var query = new InlineQuery();
            string sqlquery = $"UPDATE dbo.Users SET UserType = {UserType} WHERE Id = {UserId}";
            query.Execute(sqlquery);
        }

        //Xoá tài khoản
        public static bool DeleteUser(int UserId)
        {
            var query = new InlineQuery();
            string sqleury = $"DELETE FROM dbo.UserInfor WHERE UserId = {UserId}";
            query.Execute(sqleury);
            sqleury = $"DELETE FROM Users WHERE Id = {UserId}";
            query.Execute(sqleury);
            return true;
        }

        //Đếm tổng số tài khoản
        public static int CountEmpolyee()
        {
            var qry = new InlineQuery();
            string sqlquery = "SELECT COUNT(dbo.Users.Id) FROM dbo.Users";
            int result = qry.ExecuteScalar<int>(sqlquery);
            return result;
        }

        //Cập nhật dữ liệu tài khoản
        public static bool UpdateEmpolyee(EmpolyeeInfor empolyee)
        {
            var query = new InlineQuery();
            string sqlquery = $@"UPDATE dbo.Users 
                         SET DisplayName = N'{empolyee.DisplayName}', Email = N'{empolyee.Email}', 
                             AtCreate = '{empolyee.AtCreate.ToString("yyyy-MM-dd HH:mm:ss")}', 
                             UserType = {empolyee.UserType}, Status = {empolyee.Status} 
                         WHERE Id = {empolyee.Id}";
            query.Execute(sqlquery);

            sqlquery = $@"UPDATE dbo.UserInfor 
                  SET PhoneNumber = '{empolyee.PhoneNumber}', Job = N'{empolyee.Job}', Department = N'{empolyee.Department}', 
                      Gender = N'{empolyee.Gender}', DateOfBirth = '{empolyee.DateOfBirth.ToString("yyyy-MM-dd")}', 
                      Address = N'{empolyee.Address}' 
                  WHERE UserId = {empolyee.Id}";
            query.Execute(sqlquery);
            return true;
        }

        //Gửi Email 
        public static void SendEmail(string[] recipients, string subject, string content, string[] ccRecipients, string[] bccRecipients)
        {
            // Cấu hình thông tin email
            string emailFrom = "ansaka147@gmail.com";
            string password = "bnbzobpxchqtlsty";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;

            // Tạo đối tượng MailMessage
            MailMessage message = new MailMessage();
            message.From = new MailAddress(emailFrom);
            if (recipients != null)
            {
                foreach (string recipient in recipients)
                {
                    message.To.Add(new MailAddress(recipient));
                }
            }
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = true;

            // Thêm danh sách email vào trường CC nếu có
            if (ccRecipients != null)
            {
                foreach (string ccRecipient in ccRecipients)
                {
                    message.CC.Add(new MailAddress(ccRecipient));
                }
            }

            // Thêm danh sách email vào trường BCC nếu có
            if (bccRecipients != null)
            {
                foreach (string bccRecipient in bccRecipients)
                {
                    message.Bcc.Add(new MailAddress(bccRecipient));
                }
            }

            // Tạo đối tượng SmtpClient
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
            smtpClient.Credentials = new NetworkCredential(emailFrom, password);
            smtpClient.EnableSsl = true;

            // Gửi email
            smtpClient.Send(message);
        }

        //Kiểm tra loại tài khoản người dùng hiện tại
        public static List<User> CheckCurrentUserType(User user)
        {
            var sql = new InlineQuery();
            string query = $"SELECT * FROM dbo.Users WHERE Id = {user.Id} And UserType = {user.UserType}";
            List<User> users = sql.ExecuteTypedList<User>(query);
            return users;
        }
    }
}
