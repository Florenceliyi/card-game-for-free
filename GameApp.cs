using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {
        //��ʼ�����ñ�
        GameConfigManager.Instance.Init();

        //��ʼ����Ƶ������
        AudioManager.Instance.Init();

        //��ʼ���û���Ϣ
        RoleManager.Instance.Init();

        //��ʾloginUI �����Ľű�������Ԥ������������Ҫһ��
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //����bgm
        AudioManager.Instance.PlayBGM("bgm1");

        //test
        string name = GameConfigManager.Instance.GetCardById("1002")["Des"];
        print(name);
    }

   
}
