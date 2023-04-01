using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��ʼ���棨�̳�UIBase��
public class LoginUI : UIBsase
{
    private void Awake()
    {
        //��ʼ��Ϸ
        Register("bg/startBtn").onClick = onStartGameBtn;
    }

    private void onStartGameBtn(GameObject obj, PointerEventData pData)
    {
        //�ر�login����
        Close();

        //ս����ʼ��
        FightManager.Instance.ChangeType(FightType.Init);
    }
}
