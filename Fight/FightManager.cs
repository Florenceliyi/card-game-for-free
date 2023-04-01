using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//ս��ö��
public enum FightType
{
    None,
    Init,
    Player,
    Enemy,
    Win,
    Lose
}

/// <summary>
/// ս��������
/// </summary>

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit; //ս����Ԫ

    public int MaxHp;//���Ѫ��

    public int CurHp; //��ǰѪ��

    public int MaxPowerCount; //�������������ʹ�û����ģ�
    public int CurPowerCount; //��ǰ����
    public int DefenseCount; // ����ֵ

    public void Init()
    {
        MaxHp = 10;
        CurHp = 10;
        MaxPowerCount = 10;
        CurPowerCount = 10;
        DefenseCount = 10;
    }

    private void Awake()
    {
        Instance = this;
    }

    //�л�ս������
    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.None:
                break;
            case FightType.Init:
                fightUnit = new FightInit();
                break;
            case FightType.Player:
                fightUnit = new Fight_PlayerTurn();
                break;
            case FightType.Enemy:
                fightUnit = new Fight_EnemyTurn();
                break;
            case FightType.Win:
                fightUnit = new Fight_Win();
                break;
            case FightType.Lose:
                fightUnit = new Fight_Lose();
                break;
            default:
                break;
        }
        //��ʼ��
        fightUnit.Init();
    }
    private void Update()
    {
        if(fightUnit != null)
        {
            fightUnit.OnUpdate();
        }
    }
}
