# 河海大学自动健康打卡 - GUI

## 截图

![](https://github.com/Xiderowg/HHUHealthCheckinGUI/blob/master/image/formshot.png)

## 功能

* 定时打卡(10~20点)
* 自定义滞后(开始打卡)时间
* 打卡失败自动重试
* 打卡成功邮件提示
* 缩小化到托盘

## 使用

打开软件，输入学号和密码，点击最小化按钮缩小话到托盘，保持程序不退出程序将在每日10~20点之间定时打卡，若打卡不成功将每隔5分钟重试，直至成功。  

若需要将打卡成功消息发送到邮箱中，请在邮箱一栏填写合法的邮箱，程序使用邮箱服务器是个小鸡，不保证高可用性，若无必要请勿勾选，节约公共资源。

为避免集中在10点5分进行打卡导致邮件丢件，用户现在可以选择滞后时间来进行错峰打卡。将滞后时间设置为X分钟，程序将会在晚上6点X分开始尝试打卡。


## 建议

为达到最好的使用体验，可以选中exe文件后，右键单击，将此程序添加至开始菜单，此后只需在开始菜单即可启动。

![](https://github.com/Xiderowg/HHUHealthCheckinGUI/blob/master/image/addToStartMenu.png)

![](https://github.com/Xiderowg/HHUHealthCheckinGUI/blob/master/image/StartMenuSample.png)


## 更新日志

- 2020/08/09 完善了程序的异常捕捉机制，新增了滞后时间选项，错峰发送邮件避免高峰丢件
- 2020/11/25 新增了开机自启功能，并对用户之前的配置进行全部的保存，以便下次使用（by RickyChu）
- 2020/11/28 新增上次打卡之间的配置保存，以及优化功能（by RickyChu）

## 其他

遇到程序问题请移步issue，欢迎大佬PR优化这个屎一样的代码。

也欢迎电邮xiderowg@foxmail.com提出功能建议。
