using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager 
{
    public static FightCardManager Instance = new FightCardManager();

    public List<string> cardList;// 卡牌集合

    public List<string> usedCardList; //弃牌堆
   public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();

        //定义临时集合
        List<string> tempList = new List<string>();
        //将玩家的卡牌存储到临时集合
        tempList.AddRange(RoleManager.Instance.cardList);

        while(tempList.Count > 0)
        {
            //随机
            int tempIndex = Random.Range(0, tempList.Count);

            //添加到卡牌
            cardList.Add(tempList[tempIndex]);

            //临时集合删除
            tempList.RemoveAt(tempIndex);
        }

    }

    //是否存在卡牌
    public bool HasCard()
    {
        return cardList.Count > 0;
    }

    //抽卡
    public string DrawCard()
    {
        string id = cardList[cardList.Count - 1];
        cardList.RemoveAt(cardList.Count - 1);
        return id;
    }
}
