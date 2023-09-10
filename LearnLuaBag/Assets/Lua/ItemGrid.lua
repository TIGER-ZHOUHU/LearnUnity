--�õ�֮ǰ������֪ʶ  Object
--����һ��table ����Object ��ҪĿ����Ҫ������ʵ�ֵ� �̳з���subClass��new
Object:subClass("ItemGrid")

--��Ա����
ItemGrid.obj = nil
ItemGrid.imgIcon = nil
ItemGrid.Text = nil
--��Ա����
--ʵ�������Ӷ���
function ItemGrid:Init(father,posX,posY)
    self.obj = ABMgr:LoadRes("ui","ItemGrid");
    --���ø�����
    self.obj.transform:SetParent(father,false)
    --������������λ��
    self.obj.transform.localPosition = Vector3(posX,posY,0)
    --�ҿؼ�
    self.imgIcon = self.obj.transform:Find("imgIcon"):GetComponent(typeof(Image))
    self.Text = self.obj.transform:Find("Text"):GetComponent(typeof(Text))
end

--��ʼ��������Ϣ
--data �����洫��� ������Ϣ ��������� id��num
function ItemGrid:InitData(data)
    --ͨ�� ����ID ȥ��ȡ �������ñ� �õ� ͼ����Ϣ
     local itemData = ItemData[data.id]
    --��Ҫ����data�е� ͼ����Ϣ
    --�������� �ȼ���ͼ�� �ټ���ͼ���е� ͼ����Ϣ
    local strs = string.split(itemData.icon,"_")
    --����ͼ��
    local spriteAtlas = ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))
    --����ͼ��
    self.imgIcon.sprite = spriteAtlas:GetSprite(strs[2])
    --������������
    self.Text.text = data.num
end

--���Լ����߼�
function ItemGrid:Destroy()
    GameObject.Destroy(self.obj)
    self.obj = nil
end