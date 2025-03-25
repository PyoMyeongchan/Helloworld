using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MysqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // DB랑 서버 연결          
            string connectString = "server=localhost;user=root;database=membership;password=416089ey~!";
            MySqlConnection mySqlConnector = new MySqlConnection(connectString);

            try 
            { 

                mySqlConnector.Open();

                
                // 데이터 확인하는 코드
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnector;

                mySqlCommand.CommandText = "select* from users limit 0, 10";
                mySqlCommand.Prepare();
                // mySqlCommand.Parameters.AddWithValue("@user_id", "vyaudcks");
                // mySqlCommand.Parameters.AddWithValue("@user_password", "123456");

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    Console.WriteLine(mySqlDataReader["user_name"] + " " + mySqlDataReader["user_email"]);
                }
                mySqlCommand.ExecuteNonQuery();
                

                /*
                // 데이터 넣는 코드
                MySqlCommand mySqlCommand1 = new MySqlCommand();

                mySqlCommand1.Connection =mySqlConnector;
                mySqlCommand1.CommandText = "insert into users (user_id, user_password, user_name, user_email) values ( @user_id, @user_password, @user_name, @user_email)";
                mySqlCommand1.Prepare();
                mySqlCommand1.Parameters.AddWithValue("@user_id", "vyaudcks");
                mySqlCommand1.Parameters.AddWithValue("@user_password", "123456");
                mySqlCommand1.Parameters.AddWithValue("@user_name", "누구");
                mySqlCommand1.Parameters.AddWithValue("@user_email", "없음");
                mySqlCommand1.ExecuteNonQuery();
                */
                
                /*
                // 데이터 없애는 코드
                MySqlCommand mySqlCommand2 = new MySqlCommand();

                mySqlCommand2.Connection = mySqlConnector;
                mySqlCommand2.CommandText = " delete from users where (user_idx = 4)"; // 없애고싶은 자료 번호 넣기
                mySqlCommand2.Prepare();
                mySqlCommand2.ExecuteNonQuery();
                */

                /*
                // 데이터를 수정하는 코드
                MySqlCommand mySqlCommand3 = new MySqlCommand();

                mySqlCommand3.Connection = mySqlConnector;
                mySqlCommand3.CommandText = "update users set user_name = '명차니' where (user_idx = 1)"; // 인덱스 번호 1인 자료의 이름을 바꾸는 코드
                mySqlCommand3.Prepare();
                mySqlCommand3.ExecuteNonQuery();
                */

                mySqlConnector.Close();

            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }



            
        }
        
    }
}
