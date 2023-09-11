print("主lua脚本启动")

--判断全局函数
--第二种方法
function IsNull(obj)
	-- body
	if(obj == nil or obj:Equals(nil)) then
		return true
	else
		return false
	end
end
-- Unity中写lua执行
-- xlua帮我们处理
-- 只要是执行lua脚本 都会自动的进入我们的重定向函数中找文件
--require("Test")
--require("Lesson1_CallClass")
--require("Lesson2_CallEnum")
--require("Lesson3_CallArray")
--require("Lesson4_CallFunction")
--require("Lesson5_CallFunction")
--require("Lesson6_CallFunction")
--require("Lesson7_CallDel")
--require("Lesson8_Special")
--require("Lesson9_Special")
--require("Lesson10_Special")
--require("Lesson11_Coroutine")
--require("Lesson12_T")
--require("Hotfix_Lesson1")
--require("Hotfix_Lesson2")
require("Hotfix_Lesson6")