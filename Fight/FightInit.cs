using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ս����ʼ��
public class FightInit : FightUnit
{
    public override void Init()
    {
        //��ʼ��ս����ֵ
        FightManager.Instance.Init();

        //�л�bgm
        AudioManager.Instance.PlayBGM("battle");

        //��������
        Debug.Log("��������");
        EnemyManager.Instance.LoadRes("10003"); //��ȡ�ؿ�3�ĵ�����Ϣ����������ѡ��

        //��ʼ��ս������
        FightCardManager.Instance.Init();

        //��ʾս������
        UIManager.Instance.ShowUI<FightUI>("FightUI");
    }
                                                                                                              
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
