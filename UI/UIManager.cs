using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI������
public class UIManager : MonoBehaviour
{
   public static UIManager Instance;

    private Transform canvasTf;//���������

    //�洢���ع��Ľ���ļ���
    private List<UIBsase> uiList;
    private void Awake()
    {
        Instance = this;
        //�������еĻ���
        canvasTf = GameObject.Find("Canvas").transform;
        //��ʼ������
        uiList = new List<UIBsase>();

    }

    public UIBsase ShowUI<T>(string uiName) where T : UIBsase
    {
        UIBsase ui = Find(uiName);
        if(ui == null)
        {
            //������û����Ҫ��resources/UI�ļ����м���
           GameObject obj =  Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;
           //������
           obj.name = uiName;
            //�����Ҫ�Ľű�
            ui = obj.AddComponent<T>();
            //��ӵ����Ͻ��д洢
            uiList.Add(ui);
        }
        else
        {
            //��ʾ
            ui.Show();
        }
        return ui;
    }
    //����
    public void HideUI(string uiName)
    {
        UIBsase ui = Find(uiName);
        if(ui != null)
        {
            ui.Hide();
        }
    }

    //�ر����н���
    public void CloseAllUI()
    {
        for(int i = uiList.Count - 1; i> 0; i--)
        {
            Destroy(uiList[i].gameObject);
        }
        //��պϼ�
        uiList.Clear();
    }

    //�ر�ĳ������
    public void CloseUI(string uiName)
    {
        UIBsase ui = Find(uiName);
        if(ui != null)
        {   
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    //�Ӽ������ҵ����ֶ�Ӧ�Ľ���ű�
    public UIBsase Find(string uiName)
    {
        for(int i = 0; i< uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                return uiList[i];
            }
        }
        return null;
    }
}
