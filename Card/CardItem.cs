using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Dictionary<string, string> data; //������Ϣ

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }

    private int index;
    //������
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.25f);
        index = transform.GetSiblingIndex();
        Debug.Log(index);
        transform.SetAsLastSibling();

        transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.yellow);
        transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 10);
    }

    //����Ƴ�
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.25f);
        transform.SetSiblingIndex(index);
    }

    private void Start()
    {
        //Id Name    Script Type    Des BgIcon  Icon Expend  Arg0 Effects
        //Ψһ�ı�ʶ�������ظ���	���� ������ӵĽű� �������͵�Id ����  ���Ƶı���ͼ��Դ·�� ͼ����Դ��·�� ���ĵķ��� ����ֵ ��Ч
        transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["BgIcon"]);
        transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["Icon"]);
        transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format(data["Des"], data["Arg0"]);
        transform.Find("bg/nameTxt").GetComponent<Text>().text = data["Name"];
        transform.Find("bg/useTxt").GetComponent<Text>().text = data["Expend"];
        transform.Find("bg/Text").GetComponent<Text>().text = GameConfigManager.Instance.GetCardTypeById(data["Type"])["Name"];

        //����bg����image����߿����
        transform.Find("bg").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));
    }
}
