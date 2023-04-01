using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ս������
/// </summary>
public class FightUI : UIBsase
{
    private Text cardCountTxt; //��������
    private Text noCardCountTxt; //���ƶ�����
    private Text powerTxt;
    private Text hpTxt;
    private Image hpImg;
    private Text fyTxt; //������ֵ

    private void Awake()
    {
        cardCountTxt = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        noCardCountTxt = transform.Find("noCard/icon/Text").GetComponent<Text>();
        powerTxt = transform.Find("mana/Text").GetComponent<Text>();
        hpTxt = transform.Find("hp/moneyTxt").GetComponent<Text>();
        hpImg = transform.Find("hp/fill").GetComponent<Image>();
        fyTxt = transform.Find("hp/fangyu/Text").GetComponent<Text>();
    }

    private void Start()
    {
        UpdateHp();
        UpdatePower();
        UpdateDefense();
        UpdateCardCount();
        UpdateUsedCardCount();
    }

    //����Ѫ����ʾ
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.CurHp + "/" + FightManager.Instance.MaxHp;
        hpImg.fillAmount = (float)FightManager.Instance.CurHp / FightManager.Instance.MaxHp;
    }

    //��������
    public void UpdatePower()
    {
        powerTxt.text = FightManager.Instance.CurPowerCount + "/" + FightManager.Instance.MaxPowerCount;
    }

    //��������
    public void UpdateDefense()
    {
        fyTxt.text = FightManager.Instance.DefenseCount.ToString();
    }

    //���¿�������
    public void UpdateCardCount()
    {
        cardCountTxt.text = FightCardManager.Instance.cardList.Count.ToString();
    }

    //
    public void UpdateUsedCardCount()
    {
        noCardCountTxt.text = FightCardManager.Instance.usedCardList.Count.ToString();
    }
}
