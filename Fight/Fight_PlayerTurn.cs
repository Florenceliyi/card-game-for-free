using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4); //��4��
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
        });
    }

 

    public override void OnUpdate()
    {
        
    }
}
