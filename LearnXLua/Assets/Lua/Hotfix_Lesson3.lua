--print("Э�̺����滻")

--xlua.hotfix(�࣬{������=������������=����....})
--Ҫ��lua�����C#Э�̺��� ��ô��ʹ����
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

--�������Ϊ����Hotfix���Ե�C#���¼��˺�������
--����ֻע�� ����Ҫ�����ɴ��� ��ע�� ��Ȼע��ᱨ��