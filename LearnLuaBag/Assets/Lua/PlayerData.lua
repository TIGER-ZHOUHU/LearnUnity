PlayerData = {}
-- ����Ŀǰֻ���������� ����ֻ��Ҫ���ĵ�����Ϣ����

PlayerData.equips = {}
PlayerData.items = {}
PlayerData.gems = {}

--Ϊ�������д��һ�� ��ʼ������ �Ժ�ֱ�Ӹ������������Դ����
function PlayerData:Init()
    --������Ϣ ���ܴ汾�� ���Ǵ������ ������ѵ��ߵ�������Ϣ���ȥ
    --����ID�͵�������

    -- Ŀǰ��Ϊû�з����� Ϊ�˲��� ���Ǿ�д������������Ϊ�����Ϣ
    table.insert(self.equips,{id = 1,num = 1})
    table.insert(self.equips,{id = 2,num = 1})

    table.insert(self.items,{id = 3,num = 50})
    table.insert(self.items,{id = 4,num = 40})

    table.insert(self.gems,{id = 5,num = 7})
    table.insert(self.gems,{id = 6,num = 9})
end

--PlayerData:Init()
--print(PlayerData.equips[1].id)