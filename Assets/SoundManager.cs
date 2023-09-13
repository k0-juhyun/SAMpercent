using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource audioSource;

    // 오디오 클립들
    public AudioClip[] comments;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // 오디오 클립 재생 함수
    public IEnumerator PlaySFX(int clipNum)
    {
        audioSource.clip = comments[clipNum];
        audioSource.Play();
        print(clipNum + ": 번 클립 재생");

        // 클립 재생이 끝날 때까지 대기
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
