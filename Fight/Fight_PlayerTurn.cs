using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate ()

        {
            //恢复行动力
            FightManager.Instance.CurPowerCount = 3;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();
            //卡牌已经没有卡需要重新初始化
            if (FightCardManager.Instance.HasCard() == false)
            {
                FightCardManager.Instance.Init();
                //更新弃卡堆数量
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
            }
            //抽牌
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4); //抽4张
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

            //更新卡牌数
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        });
    }

 

    public override void OnUpdate()
    {
        
    }
}
