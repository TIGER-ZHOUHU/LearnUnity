--print("**********第一个热补丁************")

--直接写好代码 运行 是会报错的
--我们必须做4个非常重要的操作
--1.加特性
--2.加宏  第一次开发热补丁需要加
--3.生成代码
--4.hotfix注入   注入时可能报错 提示你引入Tools

--热补丁的缺点 ：只要我们修改了热补丁类的代码，我们就需要重新执行第四步
--需要重新点击 注入

--lua当中 热补丁代码固定写法
--xlua.hotfix(类，“函数名"，lua函数)

--成员函数 第一个参数 self
xlua.hotfix(CS.HotfixMain,"Add", function(self,a,b)
    print(a + b)
    return a + b
end)

--静态函数 不用传第一个参数

xlua.hotfix(CS.HotfixMain,"Speak",function(str)
    print(str)
end)