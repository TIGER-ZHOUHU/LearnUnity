--print("���Ժ��������滻")

xlua.hotfix(CS.HotfixMain,{
    --��������Խ����Ȳ����ض���
    --set_������ ���������� �ķ���
    --get_������ �ǵõ����� �ķ���
    set_Age = function (self,v)
        print("Lua"..v)
    end,
    get_Age = function (self)
        return 10
    end,

    --�������̶�д��
    --set_Item ͨ������������
    --get_Item ͨ����������ȡ
    set_Item = function (self,index,v)
        print("Lua Index"..index.."Value:"..v)
    end,
    get_Item = function (self,index)
        print("Lua get Index")
        return 9999
    end
})