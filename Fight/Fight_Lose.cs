using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        FightManager.Instance.StopAllCoroutines();
        UIManager.Instance.ShowTip("��ʧ����!", Color.red);
    }

    public override void OnUpdate()
    {

    }
}
