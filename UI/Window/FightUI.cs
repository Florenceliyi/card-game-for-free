using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// 战斗界面
/// </summary>
public class FightUI : UIBsase
{
    private Text cardCountTxt; //卡牌数量
    private Text noCardCountTxt; //弃牌堆数量
    private Text powerTxt;
    private Text hpTxt;
    private Image hpImg;
    private Text fyTxt; //防御数值
    private List<CardItem> cardItemList; //存储卡牌物体的集合
    private void Awake()
    {
        cardItemList = new List<CardItem>();
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

    //更新血量显示
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.CurHp + "/" + FightManager.Instance.MaxHp;
        hpImg.fillAmount = (float)FightManager.Instance.CurHp / FightManager.Instance.MaxHp;
    }

    //更新能量
    public void UpdatePower()
    {
        powerTxt.text = FightManager.Instance.CurPowerCount + "/" + FightManager.Instance.MaxPowerCount;
    }

    //防御更新
    public void UpdateDefense()
    {
        fyTxt.text = FightManager.Instance.DefenseCount.ToString();
    }

    //更新卡堆数量
    public void UpdateCardCount()
    {
        cardCountTxt.text = FightCardManager.Instance.cardList.Count.ToString();
    }

    //更新丢弃卡牌的数量
    public void UpdateUsedCardCount()
    {
        noCardCountTxt.text = FightCardManager.Instance.usedCardList.Count.ToString();
    }

    //创建卡牌物体
    public void CreateCardItem(int count)
    {
        if(count > FightCardManager.Instance.cardList.Count)
        {
            count = FightCardManager.Instance.cardList.Count;
        }

        for(int i = 0; i< count; i++)
        {
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"), transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition= new Vector2(-1000, -700);
            var item = obj.AddComponent<CardItem>();
            string cardId = FightCardManager.Instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.GetCardById(cardId);
            item.Init(data);
            cardItemList.Add(item);
        }
    }

    //更新卡牌位置
    public void UpdateCardItemPos()
    {
        float offset = 800.0f/ cardItemList.Count;
        Vector2 startPos = new Vector2(cardItemList.Count / 2.0f * offset + offset * 0.5f, -700);
        for(int i = 0; i< cardItemList.Count; i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos(startPos, 0.5f);
            startPos.x = startPos.x + offset;
        }
    }
}
