

# XamarinForms笔记

# Community项目
Xamarin练习项目，一个商城，交友平台。使用forms开发。可在ios和android上运行。2017年7月29日。作者：黎明你好，qq：87914111。

## Page文件列表说明
1. Welcome 欢迎页面。
2. LoginMain 登录主页面。
![](https://github.com/limingnihao/XamarinForms/blob/master/Printscreen/%E6%B3%A8%E5%86%8C.jpg)

3. MobileLogin 手机号登录页面。
4. MobileRegister 手机号注册页面。
1. Goods 商品：列表、详情等
2. Myself 我的：个人资料、我的订单、收获地址、密码与安全等。
3. News 新闻：一个cms系统。
4. Message 消息：一个IM系统。


## Service说明
1. NewsService 请求新闻服务（是用第三方接口）

##需要增加一个NuGet的源，因为我用了forms3.0的版本。
在“首选项->NuGet->源”里增加一个 https://www.myget.org/F/xamarinforms-dev/api/v3/index.json


--------------------
# Xamarin开发笔记 - 目录
### 1.1介绍
1. 环境搭建(macOS)
2. 创建第一个forms程序
3. 在iphone上虚拟机、真机上运行
4. 在android虚拟机真机上运行
3. 常用控件汇总

### 1.2注册、登录、首页
3. 创建一个登录页面。
4. 创建一个TAB页面。

### 1.3 新闻
5. 创建一个下拉刷新列表页面
8. 新闻的HTTP异步加载
8. 新闻的WebView的详情页

### 1.4 购物
6. 商品首页 - 使用Grid做列表/网格切换。
7. 自定义控件CheckBox

### 1.5 IM
10. IM首页。
11. 使用xmpp做即时通讯
10. 读取通讯录

### 1.6 我的
10. 上传头像到服务器
11. 保存文件到手机
