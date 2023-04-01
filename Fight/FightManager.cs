using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//战斗枚举
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
/// 战斗管理器
/// </summary>

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit; //战斗单元

    public int MaxHp;//最大血量

    public int CurHp; //当前血量

    public int MaxPowerCount; //最大能量（卡牌使用会消耗）
    public int CurPowerCount; //当前能量
    public int DefenseCount; // 防御值

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

    //切换战斗类型
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
        //初始化
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
