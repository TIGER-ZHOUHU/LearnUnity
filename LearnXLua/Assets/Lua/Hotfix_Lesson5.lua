--print("�¼������滻")

xlua.hotfix(CS.HotfixMain,{
    -- add_�¼��� �������¼��Ӳ���
    -- remove_�¼��� ������
    add_myEvent = function (self,del)
        print(del)
        print("add event")
        -- ��ȥ����ʹ��luaʹ��C#�¼��ķ���ȥ���
        -- ���¼��Ӽ����ض���lua������
        --ǧ��Ҫ�Ѵ����ί�����¼����
        --�������ѭ��
        --��Ѵ���� ���� ����lua�У���������
        -- self:myEvent("+",del)
    end,
    remove_myEvent = function (self,del)
        print(del)
        print("remove event")
    end
})