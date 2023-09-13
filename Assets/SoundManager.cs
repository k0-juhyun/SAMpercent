using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource audioSource;

    // ����� Ŭ����
    public AudioClip[] comments;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // ����� Ŭ�� ��� �Լ�
    public IEnumerator PlaySFX(int clipNum)
    {
        audioSource.clip = comments[clipNum];
        audioSource.Play();
        print(clipNum + ": �� Ŭ�� ���");

        // Ŭ�� ����� ���� ������ ���
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
