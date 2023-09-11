print("************Lua调用C# 拓展方法 相关知识点**************")

Lesson4 = CS.Lesson4
--使用静态方法
--CS.命名空间.类名.静态方法名（）
Lesson4.Eat()

--成员方法 实例化出来用
local obj = Lesson4()
--成员方法 一定用冒号
obj:Speak("wakakakaka")

--使用拓展方法 和使用成员方法 一致
--要调用 C#中某个类的拓展方法 那一定要在拓展方法的静态类前面加上LuaCallCSharp特性
obj:Move()