using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

//物品类
public class ObjectsInfo : MonoBehaviour
{
    public static ObjectsInfo _instance;
    public TextAsset objectInfoListText;
    private Dictionary<int, ObjectInfo> objectInfoDic = new Dictionary<int, ObjectInfo>();
     
    private void Awake()
    {
        _instance = this;
        objectInfoListText = Resources.Load<TextAsset>("ObjecyInfo/ObjectInfoList");
        ReadInfo();
        print(objectInfoDic.Keys.Count);
    }

    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info=null;
        objectInfoDic.TryGetValue(id, out info);
        return info;    
    }

    void ReadInfo()
    {
        string text = objectInfoListText.text;
        string[] strArray = text.Split("\n");
        foreach (var str in strArray)
        {
            string[] proArray = str.Split(",");
            ObjectInfo objectInfo = new ObjectInfo();
            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            ObjectType type = ObjectType.Drug;
            objectInfo.id = id;
            objectInfo.icon_name = icon_name;
            objectInfo.name = name;
            switch (str_type)
            {
                case "Drug":type=ObjectType.Drug ;
                    break;
                case "Equip": type = ObjectType.Equip; 
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }

            objectInfo.type = type;
            if (type==ObjectType.Drug)
            {
                int hp = int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell = int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                objectInfo.hp = hp;
                objectInfo.mp = mp;
                objectInfo.price_sell = price_sell;
                objectInfo.price_buy = price_buy;
            }
            objectInfoDic.Add(id,objectInfo);
        }
    }
}

public enum ObjectType
{
    Drug,
    Equip,
    Mat
}
public class ObjectInfo
{
    public int id;
    public string name;
    public string icon_name;
    public ObjectType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;
}
