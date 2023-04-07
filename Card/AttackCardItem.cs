using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

//������
public class AttackCardItem : CardItem, IPointerDownHandler
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
    }

    //����
    public void OnPointerDown(PointerEventData eventData)
    {
        //��������
        AudioManager.Instance.PlayEffect("Cards/draw");

        //�������
        Cursor.visible = false;

        //��ʾ���߽���
        UIManager.Instance.ShowUI<LineUI>("LineUI");

        //���ÿ�ʼ��λ��
        UIManager.Instance.GetUI<LineUI>("LineUI").SetStartPos(transform.GetComponent<RectTransform>().anchoredPosition);

        //�ر�����Эͬ����
        StopAllCoroutines();

        //����������Эͬ����
        StartCoroutine(OnMouseDownRight(eventData));

        IEnumerator OnMouseDownRight(PointerEventData pData)
        {
            while (true)
            {
                //����ٴΰ�������Ҽ�������ѭ��
                if (Input.GetMouseButton(1))
                {
                    break;
                }

                Vector2 pos;

                bool jud = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    transform.parent.GetComponent<RectTransform>(),
                    pData.position,
                    pData.pressEventCamera,
                    out pos
                    );

                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    transform.parent.GetComponent<RectTransform>(),
                    pData.position,
                    pData.pressEventCamera,
                    out pos
                    ))
                {
                    //���ü�ͷλ��
                    UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);
                    //�������߼���Ƿ���������
                    CheckRayToEnemy();
                }

                yield return null;
            }
            //����ѭ������ʾ���
            Cursor.visible = true;

            //�ر����߽���
            UIManager.Instance.CloseUI("LineUI");
        }
    }

    Enemy hitEnemy; // ���߼�⵽�ĵ��˽ű�
    public void CheckRayToEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask("Enemy")))
        {
            hitEnemy = hit.transform.GetComponent<Enemy>();

            if (hitEnemy)
            {
                hitEnemy.OnSelected(); //ѡ��
            }

            //�������������ʹ�ù�����
            if (Input.GetMouseButtonDown(0))
            {
                //�ر�����Эͬ����
                StopAllCoroutines();

                //�����ʾ
                Cursor.visible = true;

                //�ر����߽���
                UIManager.Instance.CloseUI("LineUI");

                if(TryUse() == true)
                {
                    //������Ч
                    PlayEffect(hitEnemy.transform.position);

                    //�����Ч
                    AudioManager.Instance.PlayEffect("Effect/sword");

                    //��������
                    int val = int.Parse(data["Arg0"]);
                    hitEnemy.Hit(val);
                }
                //����δѡ��
                hitEnemy.OnUnSelected();

                //���õ��˽ű�Ϊnull
                hitEnemy = null;
            }

        }
        else
        {
            //δ�䵽����
            if(hitEnemy != null)
            {
                hitEnemy.OnUnSelected();
                hitEnemy = null;
            }
        }


    }
}
