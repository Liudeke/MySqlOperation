using UnityEngine;
using MySql.Data.MySqlClient;

namespace _Scripts
{
    public class MySqlDataBase 
    {
        //创建一个表
        public static void CreatTable(MySqlConnection sqlConnection)
        {
            string cmd = "drop table sheet1";//"create table student(id int auto_increment primary key,name varchar(50),sex varchar(20),date varchar(50),content varchar(100)) default charset=utf8";
            MySqlCommand mycmd=new MySqlCommand(cmd,sqlConnection);
            mycmd.ExecuteReader();
            Debug.Log("Create");
        }
        //删除一个表
        public static void DeleteTable(MySqlConnection sqlConnection)
        {
            string cmd = "drop table sheet1";
            MySqlCommand mycmd = new MySqlCommand(cmd, sqlConnection);

        }
    }
}