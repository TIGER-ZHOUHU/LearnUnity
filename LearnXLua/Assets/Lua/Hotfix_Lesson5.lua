--print("事件操作替换")

xlua.hotfix(CS.HotfixMain,{
    -- add_事件名 代表着事件加操作
    -- remove_事件名 减操作
    add_myEvent = function (self,del)
        print(del)
        print("add event")
        -- 会去尝试使用lua使用C#事件的方法去添加
        -- 在事件加减的重定向lua函数中
        --千万不要把传入的委托往事件里存
        --否则会死循环
        --会把传入的 函数 存在lua中！！！！！
        -- self:myEvent("+",del)
    end,
    remove_myEvent = function (self,del)
        print(del)
        print("remove event")
    end
})