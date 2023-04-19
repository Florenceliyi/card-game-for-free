using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//胜利
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        FightManager.Instance.StopAllCoroutines();
        //显示结算界面
        UIManager.Instance.ShowTip("你胜利了!", Color.blue);
    }

    public override void OnUpdate()
    {

    }
}
