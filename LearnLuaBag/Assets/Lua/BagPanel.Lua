--һ������Ӧһ����

BasePanel:subClass("BagPanel")

BagPanel.Content = nil

--�����洢��ǰ ��ʾ�ĸ���
BagPanel.items = {}

BagPanel.nowType  = -1
--����Ա������
--��ʼ������
function BagPanel:Init(name)
    self.base.Init(self,name)

    if self.isInitEvent == false then
        --�ҵ�û�й���UI�ؼ��� ���� ������Ҫ�ֶ�ȥ��
        self.Content = self:GetControl("svBag","ScrollRect").transform:Find("Viewport"):Find("Content")
        --���¼�
        --�رհ�ť
        self:GetControl("btnClose","Button").onClick:AddListener(function ()
            self:HideMe()
        end)
        --��ѡ���¼�
        --��ҳǩ
        --toggle ��Ӧί�� �� UnityAction<bool>
        self:GetControl("togEquip","Toggle").onValueChanged:AddListener(function(value)
            if value == true then
                -- body
                self:ChangeType(1)
            end
        end)
        self:GetControl("togItem","Toggle").onValueChanged:AddListener(function(value)
            if value == true then
                -- body
                self:ChangeType(2)
            end
        end)
        self:GetControl("togGem","Toggle").onValueChanged:AddListener(function(value)
            if value == true then
                -- body
                self:ChangeType(3)
            end
        end)

        self.isInitEvent = true
    end
    
end
--��ʾ����
function BagPanel:ShowMe(name)
    self.base.ShowMe(self,name)
    --��һ�δ�ʱ ��������
    if self.nowType == -1 then
        self:ChangeType(1)
    end
end


--�߼��������� ������ҳǩ
--type 1װ�� 2���� 3��ʯ
function BagPanel:ChangeType(type)
    --�ж�����Ѿ��ǵ���ҳ�� �ͱ������
    if self.nowType==type then
        return
    end
    -- ��ҳ ���������Ϣ �����и��Ӵ���

    --����֮ǰ ���ϵĸ���ɾ�� BagPanel.items
    for i = 1, #self.items do
        --���ٸ��Ӷ���
        --GameObject.Destroy(self.items[i].obj)
        self.items[i]:Destroy()
    end
    self.items = {}
    --�ٸ��ݵ�ǰѡ������� �������µĸ��� BagPanel.items
    --Ҫ���� �����type ��ѡ�� ��ʾ������
    local nowItems = nil
    if type==1 then
        nowItems = PlayerData.equips
    elseif type==2 then
        nowItems = PlayerData.items
    else
        nowItems = PlayerData.gems
    end

    --��������
    for i = 1, #nowItems do
        --�������� ����һ�����Ӷ���
        local grid = ItemGrid:new()
        --Ҫʵ�������� ����λ��
        grid:Init(self.Content,(i-1)%4*85,math.floor((i-1)/4)*85,0)
        --��ʼ��������Ϣ ������ͼ��
        grid:InitData(nowItems[i])
        --����������
        table.insert(self.items,grid)
    end
end

       -- �и�����Դ ���� ���ظ�����Դ ʵ���� �ı�ͼƬ �� �ı� �Լ�λ�� ����
      -- local grid = {}
       --��һ���±� ���� ���Ӷ��� ��������� �洢��Ӧ��Ҫ����Ϣ
      -- grid.obj = ABMgr:LoadRes("ui","ItemGrid");
       --���ø�����
      -- grid.obj.transform:SetParent(self.Content,false)
       --������������λ��
     --  grid.obj.transform.localPosition = Vector3((i-1)%4 * 85,math.floor((i-1)/4)*85,0)
       --�ҿؼ�
     --  grid.imgIcon = grid.obj.transform:Find("imgIcon"):GetComponent(typeof(Image))
     --  grid.Text = grid.obj.transform:Find("Text"):GetComponent(typeof(Text))
       --��������ͼ��
       --ͨ�� ����ID ȥ��ȡ �������ñ� �õ� ͼ����Ϣ
     --  local data = ItemData[nowItems[i].id]
       --��Ҫ����data�е� ͼ����Ϣ
       --�������� �ȼ���ͼ�� �ټ���ͼ���е� ͼ����Ϣ
      -- local strs = string.split(data.icon,"_")
       --����ͼ��
     --  local spriteAtlas = ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))
       --����ͼ��
     --  grid.imgIcon.sprite = spriteAtlas:GetSprite(strs[2])
       --������������
      -- grid.Text.text = nowItems[i].num