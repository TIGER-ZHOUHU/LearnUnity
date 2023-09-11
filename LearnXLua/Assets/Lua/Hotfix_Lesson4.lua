--print("属性和索引器替换")

xlua.hotfix(CS.HotfixMain,{
    --如果是属性进行热补丁重定向
    --set_属性名 是设置属性 的方法
    --get_属性名 是得到属性 的方法
    set_Age = function (self,v)
        print("Lua"..v)
    end,
    get_Age = function (self)
        return 10
    end,

    --索引器固定写法
    --set_Item 通过索引器设置
    --get_Item 通过索引器获取
    set_Item = function (self,index,v)
        print("Lua Index"..index.."Value:"..v)
    end,
    get_Item = function (self,index)
        print("Lua get Index")
        return 9999
    end
})