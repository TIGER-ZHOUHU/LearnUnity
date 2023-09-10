
--将Json数据读取到Lua中的表中进行存储

-- 首先应该先把Json表 从AB包中加载出来
-- 加载的Json文件 TextAsset对象
local tex = ABMgr:LoadRes("json","ItemData",typeof(TextAsset))
--获取它的文本信息 进行json解析
--print(tex.text)
local itemList = Json.decode(tex.text)
--print(itemList[1].id..itemList[1].name)
--加载出来是一个像数组结构的数据
--不方便我们通过 id去获取里面的内容 所以 我们用一张新表转存一次
--而且这张 新的道具表 在任何地方 都能被使用
--一张用来存储道具信息的表
--键值对形式 键是道具ID 值是道具表一行信息
ItemData = {}
for _, value in pairs(itemList) do
    ItemData[value.id] = value
end
print(ItemData[1].tips)