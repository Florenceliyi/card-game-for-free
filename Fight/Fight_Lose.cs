using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        Debug.Log("ʧ����");
        FightManager.Instance.StopAllCoroutines();
    }

    public override void OnUpdate()
    {

    }
}
