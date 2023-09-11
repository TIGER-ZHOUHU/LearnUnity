print("************Lua调用C# 委托和事件 相关知识点**************")

local obj = CS.Lesson7()

--委托是用来装函数的
--使用C#中的委托 就是用来装lua函数的
local fun = function()
	-- body
	print("Lua函数Fun")
end
print("********开始加函数*********")
--Lua中没有复合运算符  不能+=
--如果第一次往委托中加函数 因为是nil 不能直接+
--所以第一次 要先等 =
obj.del = fun
obj.del = obj.del + fun

--不建议这样写 最好还是 先声明函数再加
obj.del = obj.del + function()
	print("临时声明的函数")
end

obj.del()
print("********开始减函数*********")
obj.del = obj.del - fun
obj.del = obj.del - fun
obj.del()
print("********清空*********")
--清空所有存储的函数
obj.del = nil
--清空过后得先等
obj.del = fun
--调用
obj.del()


print("************Lua调用C# 事件 相关知识点**************")
local fun2 = function()
	-- body
	print("事件加的函数")
end
print("********事件加函数*********")
--事件加减函数 和 委托非常不一样
--lua中使用C#事件 加函数
--有点类似使用成员方法 冒号事件名（“+”，函数变量）
obj:eventAction("+",fun2)
--最好不要这样写
obj:eventAction("+",function()
	print("事件加的匿名函数")
end
)

obj:DoEvent()
print("********事件减函数*********")
obj:eventAction("-",fun2)
obj:DoEvent()

print("********事件清除*********")
--清事件 不能直接设空
obj:ClearEvent()
obj:DoEvent()