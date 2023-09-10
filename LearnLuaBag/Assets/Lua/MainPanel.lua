
--只要是一个新的对象（面板） 我们就新建一张表
BasePanel:subClass("MainPanel")
--不是必须写 因为lua的特性 不存在声明变量的概念
--这样写的目的 是当别看这个lua代码时  知道这个表（对象）有什么变量很重要

--需要做 实例化面板对象
--为这个面板 处理对应的逻辑 比如按钮点击等等

--初始化该面板 实例化对象 控件事件监听
function MainPanel:Init(name)
    self.base.Init(self,name)
    --为了只添加一次事件监听
    if(self.isInitEvent == false) then
        print(self:GetControl("btnRole", "Image"))
        self:GetControl("btnRole","Button").onClick:AddListener(function ()
            self:BtnRoleClick()
        end)
        self.isInitEvent = true
    end


end

function MainPanel:BtnRoleClick()
    --print(123123)
    --print(self.panelObj)
    --等我们写了背包面板
    --在这显示背包面板
    BagPanel:ShowMe("BagPanel")
end