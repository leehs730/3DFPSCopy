using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssaultRifle : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipTakeOutWeapon;   // 무기 장착 사운	

    private AudioSource audioSource;        // 사운드 재생 컴포넌트

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlaySound(audioClipTakeOutWeapon);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
