--print("�ຯ���滻")

--lua���� �Ȳ�������̶�д��
--xlua.hotfix(�࣬��������"��lua����)

--xlua.hotfix(�࣬{������=������������=����....})
xlua.hotfix(CS.HotfixMain,{
    Update = function (self)
        print(os.time())
    end,
    Add = function (self,a,b)
        return a +b
    end,
    Speak = function (a)
        print(a)
    end
})

xlua.hotfix(CS.HotfixTest,{
    --���캯�� �Ȳ����̶�д��[".ctor"]������
    --���Ǻͱ�ĺ�����ͬ �����滻 ���ȵ���ԭ�߼��ٵ���lua�߼�
    [".ctor"] = function ()
        --print("Lua�Ȳ������캯��")
    end,
    Speak = function (self,a)
        --print("����ʦ˵"..a)     
    end,
    --���������̶�д��
    Finalize = function ()
        
    end
})