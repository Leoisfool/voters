using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace Voters.Models
{
    public class DBAction 
    {
        private readonly ILogger _logger;

        private string connStr;
        private MySqlConnection conn;

        public DBAction()
        {
            connStr = "Server=localhost;Data Source=localhost;User ID=root;Password=123456;DataBase=voters;Charset=utf8;SslMode=None;";
            conn = new MySqlConnection(connStr);
        }

        private string insertUserStr = "INSERT INTO `user` (`user_name`, `password`) VALUES (@userName,@password)";
        private string insertVoteStr = "INSERT INTO `vote` (`user_belong`, `topic`, `desc`, `vote_able`, `create_time`, `overdue_time`, `multi_num`) VALUES (@userId, @topic, @desc, @voteAble, @createTime, @overDueTime, @multiNum)";
        private string insertItemStr = "INSERT INTO .`item` (`vote_id`, `desc`, `desc_pic_url`) VALUES (@voteId, @desc, @descPicUrl)";
        private string checkItemInVoteStr = "SELECT * FROM `item` WHERE vote_id=@voteId AND id=@itemId";
        private string checkAccountStr = "SELECT id FROM voters.user where user_name=@userName AND password=@password";
        private string getAllVoteCountStr = "SELECT COUNT(*) FROM `vote`";
        private string updateVoteScoreStr = "UPDATE `voters`.`item` SET `score`=@score WHERE `id`=@itemId";
        private string getLimitVoteItemsStr = "SELECT multi_num FROM vote WHERE id=@voteId";
        private string getItemInfoStr = "SELECT `item`.`id`, `item`.`vote_id`, `item`.`score`, `item`.`desc`,`item`.`desc_pic_url` FROM `voters`.`item` WHERE id=@itemId";

        public bool InsertUser(UserItem item)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = insertUserStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@userName", item.UserName));
            command.Parameters.Add(new MySqlParameter("@password", item.Password));
            conn.Open();
            try
            {
                int res = command.ExecuteNonQuery();
                if (res <= 0)
                {
                    return false;
                }
            }
            catch {
                return false;
            }
            finally
            {
                conn.Close();
            }
            
            return true;
        }
            
        public bool InsertVote(VoteItem item)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = insertVoteStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@userId", item.UserBelong));
            command.Parameters.Add(new MySqlParameter("@topic", item.Topic));
            command.Parameters.Add(new MySqlParameter("@desc", item.Desc));
            command.Parameters.Add(new MySqlParameter("@voteAble", item.VoteAble));
            command.Parameters.Add(new MySqlParameter("@createTime", item.CreateTime));
            command.Parameters.Add(new MySqlParameter("@overdueTime", item.OverdueTime));
            command.Parameters.Add(new MySqlParameter("@multiNum", item.MultiNum));
            conn.Open();

            try
            {
                int res = command.ExecuteNonQuery();
                if (res <= 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public long GetAllVoteCount()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = getAllVoteCountStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();
            try
            {
                var res = command.ExecuteScalar();
                return (long)res;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public bool InsertItem(ItemItem item)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = insertItemStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", item.VoteId));
            command.Parameters.Add(new MySqlParameter("@desc", item.Desc));
            command.Parameters.Add(new MySqlParameter("@descPicUrl", item.DescPicUrl));

            conn.Open();
            try
            {
                int res = command.ExecuteNonQuery();
                if (res <= 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public int CheckAccount(UserItem item)
        {
            string userName = item.UserName;
            string password = item.Password;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = checkAccountStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@userName", userName));
            command.Parameters.Add(new MySqlParameter("@password", password));

            conn.Open();
            try
            {
                var res = command.ExecuteReader();
                if (res.Read())
                {
                    return (int)((uint)res[0]);
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
            return -1;
        }

        public bool checkItemsInVote(long voteId, long itemId)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = checkItemInVoteStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", voteId));
            command.Parameters.Add(new MySqlParameter("@itemId", itemId));

            conn.Open();
            try
            {
                var res = command.ExecuteReader();
                if (res.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool UpdateVoteScore(int itemId, int score)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = updateVoteScoreStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@score", score));
            command.Parameters.Add(new MySqlParameter("@itemId", itemId));

            conn.Open();
            try
            {
                int res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public uint GetLimitVoteItems(uint voteId)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = getLimitVoteItemsStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", voteId));
            conn.Open();
            try
            {
                var res = command.ExecuteScalar();
                return (uint)res;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool GetItemInfo(uint itemId, ref ItemItem item)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = getItemInfoStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@itemId", itemId));

            conn.Open();
            try
            {
                var res = command.ExecuteReader();
                if (res.Read())
                {
                    item.VoteId = (uint)res[1];
                    item.Desc = (string)res[3];
                    item.DescPicUrl = (string)res[4];
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

    }


}
