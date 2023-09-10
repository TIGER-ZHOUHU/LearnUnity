using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LuaCopyEditor 
{
    [MenuItem("XLua/�Զ�����txt��׺��lua")]
    public static void CopyLuaToTxt(){
        //����Ҫ�ҵ� ���ǵ����е�Lua�ļ�
        string path = Application.dataPath + "/Lua/";
        //�ж�·���Ƿ����
        if(!Directory.Exists(path))
            return;
        // �õ�ÿһ��lua�ļ���·�� ���ܽ���Ǩ�ƿ���
        string[] strs = Directory.GetFiles(path,"*.lua");

        //Ȼ���Lua�ļ�������һ���µ��ļ�����
        //���ȶ���һ����·��
        string newPath = Application.dataPath + "/LuaTxt/";
        //Ϊ�˱���һЩ��ɾ����lua�ļ� ����ʹ�� ����Ӧ�������Ŀ��·��

        //�ж���·���ļ��� �Ƿ����
        if(!Directory.Exists(newPath))
            Directory.CreateDirectory(newPath);
        else
        {
            //�õ���·���� ���к�׺.txt�ļ� ������ȫ��ɾ����
            string[] oldFileStrs = Directory.GetFiles(newPath,"*.txt");
            for (int i = 0; i < oldFileStrs.Length; i++)
            {
                File.Delete(oldFileStrs[i]);
            }   
        }
        List<string> newFileNames = new List<string>();
        string fileName;
        for(int i = 0; i<strs.Length; ++i){
            //�õ��µ��ļ�·�� ���ڿ���
            fileName = newPath + strs[i].Substring(strs[i].LastIndexOf("/")+1) + ".txt";
            newFileNames.Add(fileName);
            File.Copy(strs[i],fileName);
        }

        AssetDatabase.Refresh();

        //ˢ�¹���������ָ���� ��Ϊ �����ˢ�� ��һ�θı� ��û��
        for(int i = 0; i < newFileNames.Count; i++){
            //Unity API
            //��API�����·�� ������ ���Assets�ļ��е� Assets/.../...
            AssetImporter imorter = AssetImporter.GetAtPath(newFileNames[i].Substring(newFileNames[i].IndexOf("Assets")));
            if(imorter != null)
                imorter.assetBundleName = "lua";
        }
    }
}
