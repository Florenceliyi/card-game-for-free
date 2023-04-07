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
    }

    public override void OnUpdate()
    {

    }
}
