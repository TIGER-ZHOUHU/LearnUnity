--print("�������滻")

--������ T�ǿ��Ա仯 ��lua��Ӧ������滻�أ�
--lua�е��滻 Ҫһ������һ�����͵���

xlua.hotfix(CS.HotfixTest2(CS.System.String),{
    Test = function (self,str)
        print("lua fix:"..str)
    end
})

xlua.hotfix(CS.HotfixTest2(CS.System.Int32),{
    Test = function (self,str)
        print("lua fix:"..str)
    end
})



