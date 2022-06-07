# SportSystem

基于C#和SQL Server 2014开发的运动会管理系统

使用到的开发环境

- Visual Studio 2015
- SQL Server 2014

## 准备工作（数据库部署）

安装**SQL Server 2014**并在开始菜单中打开**Microsoft SQL Server Management Studio**，选择验证方式为**Windows身份验证**，***注：此服务器名称要记下来，后面要用到***



![image](https://user-images.githubusercontent.com/33719641/172337720-b79bddba-bcea-42f5-88c4-11551351b35d.png)



点击连接，然后打开**sportSystem_database**文件夹下的**sportSystem.sql**文件，点击执行，



![image](https://user-images.githubusercontent.com/33719641/172338889-2bfcbf4e-95cb-4c53-9809-71d88a8c80a3.png)



即可看到相应的数据库



![image](https://user-images.githubusercontent.com/33719641/172339236-1dadf266-7cb5-4b04-a4ba-b4493be1d26d.png)



## 运行代码

双击**sportSystem.sln**打开Visual Studio 2015项目

双击.cs文件对窗口界面进行编辑，展开.cs文件对窗口逻辑代码进行编辑，以athletesMatchMgr.cs为例



![image](https://user-images.githubusercontent.com/33719641/172341448-19f1cc47-63a6-47d0-962c-866d46efa93d.png)





`string connstr = "server=PC-PC;database=sportSystem;Trusted_Connection = True";`



将server名称改为自己的服务器名称，其他所有文件同理，更改完毕后，点击上方的运行即可，点击登录，用户名和密码可以在login中设置，把代码取消注释即为用户名admin，密码admin

```c#
private void button1_Click(object sender, EventArgs e)
{
	/*if (textBox1.Text == "admin" && textBox2.Text == "admin")
	{*/
	main f2 = new main();
	f2.Show(this);
	this.Visible = false;
	/*}
	else
	{
		MessageBox.Show("用户名或密码错误！");
	}*/
}
```

## 运行效果截图

![image](https://user-images.githubusercontent.com/33719641/172344250-38588b4a-f0b7-4e98-8411-f59fb69d61d7.png)



![image](https://user-images.githubusercontent.com/33719641/172344405-bcef78f0-8887-40d6-9728-839fe32a1a71.png)

![image](https://user-images.githubusercontent.com/33719641/172345034-a95ff9e4-528c-47cc-8fcf-768ca1646ad1.png)

## 补充说明（表属性说明）

- athletes表

|    Ano     |   Aname    |    Asex    |    Aage    |   team   |       Ecout        |
| :--------: | :--------: | :--------: | :--------: | :------: | :----------------: |
| 运动员编号 | 运动员姓名 | 运动员性别 | 运动员年龄 | 队伍名称 | 运动员参加的项目数 |

- grade表

|    Ano     |   Eno    |       grade        |  eventGrade  |
| :--------: | :------: | :----------------: | :----------: |
| 运动员编号 | 项目编号 | 成绩转化到具体数值 | 实际项目成绩 |

由于每种项目评分标准不同，例如跑步的**eventGrade**为4分30秒，升序排列，最终根据排名转化为**grade**，第一名**grade**给10分，实际计算总成绩是根据**grade**来算的，而**eventGrade**只是作为给分参考，具体给到的数值 还是看**grade**

- spevent表

|   Eno    |  Edate   |  Eplace  |  Ename   |                           Eattrib                            |
| :------: | :------: | :------: | :------: | :----------------------------------------------------------: |
| 项目编号 | 赛事日期 | 赛事地点 | 赛事名称 | 赛事成绩属性（升或者降，决定值是越小越好还是越大越好，例如跑步时间越小越好，则为升序，进球越大越好，则为降序） |

- team_grade表

|   team   |     sum      |        Acount        |
| :------: | :----------: | :------------------: |
| 队伍名称 | 队伍所得总分 | 队伍所含总运动员人数 |

