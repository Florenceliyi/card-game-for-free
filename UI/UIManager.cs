using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI管理器
public class UIManager : MonoBehaviour
{
   public static UIManager Instance;

    private Transform canvasTf;//画布的组件

    //存储加载过的界面的集合
    private List<UIBsase> uiList;
    private void Awake()
    {
        Instance = this;
        //找世界中的画布
        canvasTf = GameObject.Find("Canvas").transform;
        //初始化集合
        uiList = new List<UIBsase>();

    }

    public UIBsase ShowUI<T>(string uiName) where T : UIBsase
    {
        UIBsase ui = Find(uiName);
        if(ui == null)
        {
            //集合中没有需要从resources/UI文件夹中加载
           GameObject obj =  Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;
           //改名字
           obj.name = uiName;
            //添加需要的脚本
            ui = obj.AddComponent<T>();
            //添加到集合进行存储
            uiList.Add(ui);
        }
        else
        {
            //显示
            ui.Show();
        }
        return ui;
    }
    //隐藏
    public void HideUI(string uiName)
    {
        UIBsase ui = Find(uiName);
        if(ui != null)
        {
            ui.Hide();
        }
    }

    //关闭所有界面
    public void CloseAllUI()
    {
        for(int i = uiList.Count - 1; i> 0; i--)
        {
            Destroy(uiList[i].gameObject);
        }
        //清空合集
        uiList.Clear();
    }

    //关闭某个界面
    public void CloseUI(string uiName)
    {
        UIBsase ui = Find(uiName);
        if(ui != null)
        {   
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    //从集合中找到名字对应的界面脚本
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
