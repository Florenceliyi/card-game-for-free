using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�û���Ϣ������(ӵ�п��Ƶ���Ϣ ��ҵ�)
public class RoleManager 
{
   public static RoleManager Instance = new RoleManager();

    public List<string> cardList; // �洢ӵ�еĿ��Ƶ�id

    public void Init()
    {
        cardList = new List<string>();
        //���Ź����� ���ŷ����� ����Ч����
        cardList.Add("1000"); 
        cardList.Add("1000"); 
        cardList.Add("1000"); 
        cardList.Add("1000");

        cardList.Add("1001"); 
        cardList.Add("1001"); 
        cardList.Add("1001"); 
        cardList.Add("1001");

        cardList.Add("1002");
        cardList.Add("1002");
    }
}
