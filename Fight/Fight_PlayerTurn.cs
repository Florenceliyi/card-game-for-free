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
            //�ָ��ж���
            FightManager.Instance.CurPowerCount = 3;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();
            //�����Ѿ�û�п���Ҫ���³�ʼ��
            if (FightCardManager.Instance.HasCard() == false)
            {
                FightCardManager.Instance.Init();
                //��������������
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
            }
            //����
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4); //��4��
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

            //���¿�����
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        });
    }

 

    public override void OnUpdate()
    {
        
    }
}
