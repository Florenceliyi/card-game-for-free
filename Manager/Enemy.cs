using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

//���˵��ж�ö��
public enum ActionType
{
    None,
    Defend, //�ӷ���
    Attack //�ӹ���
}

/// <summary>
/// ���˽ű�
/// </summary>
public class Enemy : MonoBehaviour
{
    protected Dictionary<string, string> data; //�������ݱ���Ϣ

    public ActionType type;

    public GameObject hpItemObj;
    public GameObject actionObj;

    //ui���
    public Transform attackTf;
    public Transform defendTf;
    public Text defendTxt;
    public Text hpTxt;
    public Image hpImg;

    //��ֵ���
    public int Defend;
    public int Attack;
    public int MaxHp;
    public int CurHp;

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }
    // Start is called before the first frame update
    void Start()
    {
        type = ActionType.None;
        hpItemObj = UIManager.Instance.CreateHpItem();
        actionObj = UIManager.Instance.CreateActionIcon();

        attackTf = actionObj.transform.Find("attack");
        defendTf = actionObj.transform.Find("defend");

        defendTxt = hpItemObj.transform.Find("fangyu/Text").GetComponent<Text>();
        hpTxt = hpItemObj.transform.Find("hpTxt").GetComponent <Text>();
        hpImg = hpItemObj.transform.Find("fill").GetComponent<Image>();

        //����Ѫ�� �ж���λ��
        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.down * 0.2f);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);

        SetRandomAction();

        //��ʼ����ֵ(hp attack defend)
        Attack = int.Parse(data["Attack"]);
        CurHp = int.Parse(data["Hp"]);
        MaxHp = CurHp;
        Defend = int.Parse(data["Defend"]);

        UpdateHp();
        UpdateDefend();
    }

    //���һ���ж�
    public void SetRandomAction()
    {
        int ran = Random.Range(0, 3);

        type = (ActionType)ran;

        switch (type) { 
            case ActionType.Attack:
                attackTf.gameObject.SetActive(true);
                defendTf.gameObject.SetActive(false);
                break;
            case ActionType.Defend:
                attackTf.gameObject.SetActive(false);
                defendTf.gameObject.SetActive(true);
                break;
            case ActionType.None:
                break;
        }   
    }

    //����Ѫ��
    public void UpdateHp()
    {
        hpTxt.text = CurHp + "/" + MaxHp;
        hpImg.fillAmount = (float)CurHp / (float)MaxHp;
    }

    //���·���ֵ
    public void UpdateDefend()
    {
        defendTxt.text = Defend.ToString();
    }



}
