using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {
        //初始化配置表
        GameConfigManager.Instance.Init();

        //初始化音频管理器
        AudioManager.Instance.Init();

        //初始化用户信息
        RoleManager.Instance.Init();

        //显示loginUI 创建的脚本名字与预制体物体名字要一致
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //播放bgm
        AudioManager.Instance.PlayBGM("bgm1");

        //test
        string name = GameConfigManager.Instance.GetCardById("1002")["Des"];
        print(name);
    }

   
}
