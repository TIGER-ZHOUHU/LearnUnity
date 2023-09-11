print("************Lua调用C# ref和out 相关知识点**************")

Lesson5 = CS.Lesson5

local obj = Lesson5()

--ref参数 会以多返回值的形式返回给lua
--如果函数存在返回值 那么第一个值 就是该返回值
--之后的返回值 就是ref的结果 从左到右一一对应
--ref参数 需要传入一个默认值 占位置
--a相当于 函数返回值
--b 第一个ref
--c 第二个ref
local a,b,c = obj:RefFun(1,0,0,1)
print(a)
print(b)
print(c)


--out参数 会以多返回值的形式返回给lua
--如果函数存在返回值 那么第一个值 就是该返回值
--之后的返回值 就是out的结果 从左到右一一对应
--out参数 不需要传占位置的值
local a,b,c = obj:OutFun(20,30)
print(a)
print(b)
print(c)

--混合使用 综合上面的规则
--ref需占位 out不用传
--第一个是函数的返回值  之后 从左到右一次对应ref或者out
local a,b,c = obj:RefOutFun(10,20)
print(a)
print(b)
print(c)
