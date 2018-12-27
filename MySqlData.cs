using UnityEngine;
using MySql.Data.MySqlClient;
using System;  
using System.Data;  
using System.Collections;   
using MySql.Data;
using System.IO;

namespace _Scripts
{
    public class MySqlData : MonoBehaviour
    {
        //数据库名称
        private string dataname = "user";
        //数据库Ip地址
        private string ipAddress = "127.0.0.1";
        //用户名
        private string root = "root";
        //密码
        private string paw = "123456";

        private MySqlConnection mysqlcon;
     
        private void Start()
        {
           string connectionStr = string.Format("Server={0};Database={1};User ID={2};Password={3}",ipAddress,dataname,root,paw);
            mysqlcon=new MySqlConnection(connectionStr);
        }

        void OnGUI()
        {
            //打开数据库
            if (GUILayout.Button("OpenMySql"))
            {
                if (mysqlcon != null)
                {
                    mysqlcon.Open();
                    Debug.Log("打开数据库成功");
                }
            }
            //显示查询到的信息
            string cmdSel = "select * from userinfo1";
            if (GUILayout.Button("SelMySql"))
            {
                ////创建操作数据库的实例（参数是查询语句，数据库）
                //MySqlCommand command = new MySqlCommand(cmdSel, mysqlcon);

                //if (command != null)
                //{
                //    MySqlDataReader msdr = command.ExecuteReader();
                //    while (msdr.Read())
                //    {
                //        //输出第1,2列信息，，，
                //        Debug.Log(msdr[0].ToString()+"\t"+msdr[1].ToString());//
                //    }
                //    command.Dispose(); //释放内存
                //}
                MySqlDataBase.CreatTable(mysqlcon);
            }
            //输入查询语句点击并查询
            string cmdInp = "insert into userinfo1 values(20,'chenzy')";
            if (GUILayout.Button("SelectMySql"))
            {
                //创建操作数据库的实例（参数是查询语句，数据库）
                MySqlCommand command = new MySqlCommand(cmdInp, mysqlcon);

                if (command != null)
                {
                    //返回的是该语句影响的数据库的行数
                    int i = command.ExecuteNonQuery();
                    Debug.Log(i);
                }
            }
          
           
        }
    }
}