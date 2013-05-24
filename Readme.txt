此解决方案共分为6个项目：
1.DemoShow.Domain：底层访问数据库层
2.DemoShow.Entities：对应数据库的实体类
3.DemoShow.UI.AspNet：UI之Asp.Net实现
4.DemoShow.UI.Mvc3：UI之Mvc3实现
5.DemoShow.UI.WinForm：UI之Winform实现
6.DemoShow.Service：Wcf服务项目（为Winform项目访问数据库提供接口）


首先说说他们之间的关系：
其中1、2为项目的底层核心，这两者构成了直接访问数据库的底层，可供不同的UI直接调用，也就是说，只要数据库结构得以确定，
则任何一个UI都可以直接调用，而不必关心访问底层数据的具体实现方式。

