--print("协程函数替换")

--xlua.hotfix(类，{函数名=函数，函数名=函数....})
--要在lua中配合C#协程函数 那么必使用它
util = require("xlua.util")
xlua.hotfix(CS.HotfixMain,{
    TestCoroutine = function (self)
        return util.cs_generator(function ()
            while true do
                coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
                print("Lua hotfix Coroutine")
            end
        end)
    end
})

--如果我们为打了Hotfix特性的C#类新加了函数内容
--不能只注入 必须要先生成代码 再注入 不然注入会报错