--���ñ������������涨λ
--׼��֮ǰ����Ľű�
--����������
require("Object")
--�ַ������
require("SplitTools")
--Json����
Json = require("JsonUtility")

--Unity���
GameObject = CS.UnityEngine.GameObject
Resources = CS.UnityEngine.Resources
Transform = CS.UnityEngine.Transform
RectTransform = CS.UnityEngine.RectTransform
--�洢�ļ�������
TextAsset = CS.UnityEngine.TextAsset
--ͼ��������
SpriteAtlas = CS.UnityEngine.U2D.SpriteAtlas

Vector3 = CS.UnityEngine.Vector3
Vector2 = CS.UnityEngine.Vector2

--UI���
UI = CS.UnityEngine.UI
Image = UI.Image
Text = UI.Text
Button = UI.Button
Toggle = UI.Toggle
ScrollRect = UI.ScrollRect
UIBehaviour = CS.UnityEngine.EventSystems.UIBehaviour

--Canvas �������������Ŀ��˵ ����һ�ξͿ�����
Canvas = GameObject.Find("Canvas").transform

--�Լ�д��C#�ű����
--ֱ�ӵõ�AB����Դ�������� ��������
ABMgr = CS.ABManager.GetInstance()