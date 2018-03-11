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

        private string insertVoteStr = "INSERT INTO `vote` (`user_belong`, `topic`, `desc`, `vote_able`, `create_time`, `overdue_time`, `multi_num`)" +
                                        " VALUES (@userId, @topic, @desc, @voteAble, @createTime, @overDueTime, @multiNum)";

        private string insertItemStr = "INSERT INTO .`item` (`vote_id`, `desc`, `desc_pic_url`) VALUES (@voteId, @desc, @descPicUrl)";

        private string getAllVoteCountStr = "SELECT COUNT(*) FROM `vote`";

        private string getLimitVoteItemsStr = "SELECT multi_num FROM vote WHERE id=@voteId";

        private string getItemInfoStr = "SELECT `item`.`id`, `item`.`vote_id`, `item`.`score`, `item`.`desc`,`item`.`desc_pic_url` FROM `voters`.`item` WHERE id=@itemId";

        private string getVoteItemStr = "SELECT `vote`.`id`, `vote`.`user_belong`, `vote`.`topic`, `vote`.`desc`, `vote`.`vote_able`,  `vote`.`create_time`, `vote`.`overdue_time`," +
                                        " `vote`.`multi_num` FROM `voters`.`vote` WHERE id=@voteId";

        private string getItemsInVoteStr = "SELECT `item`.`id` FROM `voters`.`item` WHERE vote_id=@voteId";

        private string checkItemInVoteStr = "SELECT * FROM `item` WHERE vote_id=@voteId AND id=@itemId";

        private string checkAccountStr = "SELECT id FROM voters.user where user_name=@userName AND password=@password";

        private string checkVoteBelongToUserStr = "SELECT * FROM voters.vote WHERE user_belong=@userId AND id=@voteId";

        private string updateItenItemStr = "UPDATE `voters`.`item` SET `desc`=@desc, `desc_pic_url`=@descPicUrl WHERE `id`=@itemId"; 

        private string updateVoteItemStr = "UPDATE `voters`.`vote` SET `topic`=@topic, `desc`=@desc, `vote_able`=@voteAble, `overdue_time`=@overDueTime, `multi_num`=@multiNum WHERE `id`=@voteId";

        private string updateVoteScoreStr = "UPDATE `voters`.`item` SET `score`=@score WHERE `id`=@itemId";

        private string deleteVoteStr = "DELETE FROM `voters`.`vote` WHERE `id`=@voteId";

        private string deleteItemStr = "DELETE FROM `voters`.`item` WHERE `id`=@itemId";

        private string getLastInsertId = "select last_insert_id()";

        private string getVoteFromNThToMThStr = "SELECT `vote`.`id`, `vote`.`user_belong`,`vote`.`topic`,`vote`.`desc`,`vote`.`vote_able`,`vote`.`create_time`,`vote`.`overdue_time`,`vote`.`multi_num`" +
                                            " from vote limit @nTh, @mTh";

        public bool InsertUser(UserItem item)
        {
            MySqlCommand command = new MySqlCommand
            {
                CommandText = insertUserStr,
                CommandType = System.Data.CommandType.Text,
                Connection = conn
            };
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
            
        public UInt64 InsertVote(VoteItem item)
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
                    conn.Close();
                    return 0;

                }
            }
            catch
            {
                conn.Close();
                return 0;
            }

            MySqlCommand command1 = new MySqlCommand();
            command1.CommandText = getLastInsertId;
            command1.CommandType = System.Data.CommandType.Text;
            command1.Connection = conn;


            try
            {
                UInt64 res = (UInt64)command1.ExecuteScalar();
                return res;
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

        public bool GetVoteItem(uint voteId, ref VoteItem item) 
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = getVoteItemStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", voteId));

            conn.Open();
            try
            {
                var res = command.ExecuteReader();
                if (res.Read())
                {
                    item.VoteId = (uint)res[0];
                    item.UserBelong = (uint)res[1];
                    item.Topic = (string)res[2];
                    item.Desc = (string)res[3];
                    item.VoteAble = (Byte)res[4];
                    item.OverdueTime = (uint)res[5];
                    item.CreateTime = (uint)res[6];
                    item.MultiNum = (uint)res[7];
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

        public bool getItemsInVote(uint voteId, ref VoteItem item)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = getItemsInVoteStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", voteId));

            conn.Open();
            try
            {
                var res = command.ExecuteReader();
                List<uint> b = new List<uint>();
                while (res.Read())
                {
                    b.Add((uint)res[0]);
                }
                item.ItemIds = b.ToArray();
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

        public bool UpdateVoteItem(VoteItem item)
        {
        //private string updateVoteItemStr = "UPDATE `voters`.`vote` SET `topic`=@topic, `desc`=@desc, `vote_able`=@voteAble, `overdue_time`=@overDueTime, `multi_num`=@multiNum WHERE `id`=@voteId";
        
        MySqlCommand command = new MySqlCommand();
            command.CommandText = updateVoteItemStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@topic", item.Topic));
            command.Parameters.Add(new MySqlParameter("@desc", item.Desc));
            command.Parameters.Add(new MySqlParameter("@voteAble", item.VoteAble));
            command.Parameters.Add(new MySqlParameter("@overDueTime", item.OverdueTime));
            command.Parameters.Add(new MySqlParameter("@multiNum", item.MultiNum));
            command.Parameters.Add(new MySqlParameter("@voteId", item.VoteId));

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

        public bool CheckVoteBelongToUser(uint userId, uint voteId)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = checkVoteBelongToUserStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", voteId));
            command.Parameters.Add(new MySqlParameter("@userId", userId));

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

        public bool UpdateItenItem(ItemItem item)
        {
            //private string updateItenItemStr = "UPDATE `voters`.`item` SET `desc`=@desc, `desc_pic_url`=@descPicUrl WHERE `id`=@itemId";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = updateItenItemStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@desc", item.Desc));
            command.Parameters.Add(new MySqlParameter("@descPicUrl", item.DescPicUrl));
            command.Parameters.Add(new MySqlParameter("@itemId", item.ItemId));

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

        public bool DeleteVote(uint voteId)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = deleteVoteStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@voteId", voteId));

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

        public bool GetVoteFromNThToMTh(ref SplitPageRes list, uint n, uint m, int size)
        {
            //private string getVoteFromNThToMThStr = "SELECT `vote`.`id`, `vote`.`user_belong`,`vote`.`topic`,`vote`.`desc`,`vote`.`vote_able`,`vote`.`create_time`,`vote`.`overdue_time`,`vote`.`multi_num`" +
                                           // " from vote limit @nTh, @mTh";
            if(m - n != size || n > m)
            {
                return false;
            } 
            MySqlCommand command = new MySqlCommand();
            command.CommandText = getVoteFromNThToMThStr;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            command.Parameters.Add(new MySqlParameter("@nTh", n));
            command.Parameters.Add(new MySqlParameter("@mTh", m));

            conn.Open();
            try
            {
                var res = command.ExecuteReader();
                int i = 0;
                List<VoteItem> b = new List<VoteItem>();
                while (res.Read() && i < size)
                {
                    VoteItem temp = new VoteItem();
                    temp.VoteId = (uint)res[0];
                    temp.UserBelong = (uint)res[1];
                    temp.Topic = (string)res[2];
                    temp.Desc = (string)res[3];
                    temp.VoteAble = (Byte)res[4];
                    temp.CreateTime = (uint)res[5];
                    temp.OverdueTime = (uint)res[6];
                    temp.MultiNum = (uint)res[7];
                    ++i;
                    b.Add(temp);
                }
                list.items = b.ToArray();
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

    }
}


