
--ֻҪ��һ���µĶ�����壩 ���Ǿ��½�һ�ű�
BasePanel:subClass("MainPanel")
--���Ǳ���д ��Ϊlua������ ���������������ĸ���
--����д��Ŀ�� �ǵ������lua����ʱ  ֪�������������ʲô��������Ҫ

--��Ҫ�� ʵ����������
--Ϊ������ �����Ӧ���߼� ���簴ť����ȵ�

--��ʼ������� ʵ�������� �ؼ��¼�����
function MainPanel:Init(name)
    self.base.Init(self,name)
    --Ϊ��ֻ���һ���¼�����
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
    --������д�˱������
    --������ʾ�������
    BagPanel:ShowMe("BagPanel")
end