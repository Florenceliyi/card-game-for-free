using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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

    //���ĳ������Ľű�
    public T GetUI<T>(string uiName) where T : UIBsase
    {
        UIBsase ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;
    }

    //��������ͷ�����ж�ͼ������
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling(); // �����ڸ�����һλ
        return obj;
    }

    //�������˵ײ���Ѫ������
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling(); //�����ڸ�����һλ
        return obj;
    }

    //��ʾ����
    public void ShowTip(string msg, Color color, System.Action callback = null )
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), canvasTf) as GameObject;
        Text text = obj.transform.Find("bg/Text").GetComponent<Text>();
        text.color = color;
        text.text = msg;
        Tween scale1 = obj.transform.Find("bg").DOScaleY(1, 0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScaleY(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {                                               
                callback();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            }
        });
        MonoBehaviour.Destroy(obj, 2);                                                                                                                                                                                                                                                                 

    }
}
