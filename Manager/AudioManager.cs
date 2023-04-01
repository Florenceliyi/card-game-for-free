using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //����bgm����Ƶ
    private AudioSource bgmSource;

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
    }

    //����bgm
    public void PlayBGM(string name, bool isLoop = true)
    {
        //����bgm��������
        AudioClip clip = Resources.Load<AudioClip>("Sounds/BGM/" + name);
        //������Ƶ
        bgmSource.clip = clip;

        bgmSource.loop = isLoop;

        bgmSource.Play();

    }

    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);

        //����
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
