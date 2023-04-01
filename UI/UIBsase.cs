using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������
/// </summary>

public class UIBsase : MonoBehaviour
{
    public UIEventTrigger Register(string name)
    {
        Transform tf = transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }
    //��ʾ
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    //����
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    //�رս��棨���٣�
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);
    }
}