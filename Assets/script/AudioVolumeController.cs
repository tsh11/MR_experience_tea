using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeController : MonoBehaviour
{
    [Header("Audio Source A (已掛在場景上)")]
    public AudioSource audioSourceA;

    [Header("Audio Source B (動態新增或已掛在場景上)")]
    public AudioSource audioSourceB;

    [Header("Inspector 音量滑桿")]
    [Range(0f, 1f)]
    public float volumeA = 0.5f;
    [Range(0f, 1f)]
    public float volumeB = 1.0f;

    [Header("UI Slider (可不綁定)")]
    public Slider sliderA;
    public Slider sliderB;

    void Awake()
    {
        // 如果没有在 Inspector 指定，就自動抓本物件上的 A
        if (audioSourceA == null)
            audioSourceA = GetComponent<AudioSource>();

        // 如果 B 也想提前掛一個在場景上，Inspector 指定；否則程式動態新增：
        if (audioSourceB == null)
        {
            audioSourceB = gameObject.AddComponent<AudioSource>();
            audioSourceB.playOnAwake = false;
        }
    }

    void OnValidate()
    {
        // 在 Inspector 值改變時即時更新音量
        if (audioSourceA != null) audioSourceA.volume = Mathf.Clamp01(volumeA);
        if (audioSourceB != null) audioSourceB.volume = Mathf.Clamp01(volumeB);
    }

    void Start()
    {
        // 如果綁定了 UI Slider，就把它們連到對應的設定函式
        if (sliderA != null)
        {
            sliderA.minValue = 0f;
            sliderA.maxValue = 1f;
            sliderA.value = volumeA;
            sliderA.onValueChanged.AddListener(SetVolumeA);
        }

        if (sliderB != null)
        {
            sliderB.minValue = 0f;
            sliderB.maxValue = 1f;
            sliderB.value = volumeB;
            sliderB.onValueChanged.AddListener(SetVolumeB);
        }
    }

    /// <summary>
    /// 從外部或 UI 呼叫，設定 A 的音量 (0~1)
    /// </summary>
    public void SetVolumeA(float vol)
    {
        volumeA = Mathf.Clamp01(vol);
        if (audioSourceA != null) audioSourceA.volume = volumeA;
    }

    /// <summary>
    /// 從外部或 UI 呼叫，設定 B 的音量 (0~1)
    /// </summary>
    public void SetVolumeB(float vol)
    {
        volumeB = Mathf.Clamp01(vol);
        if (audioSourceB != null) audioSourceB.volume = volumeB;
    }

    /// <summary>
    /// 立刻播放 A（可由 UI Button 呼叫）
    /// </summary>
    public void PlayA()
    {
        if (audioSourceA != null) audioSourceA.Play();
    }

    /// <summary>
    /// 立刻播放 B（可由 UI Button 呼叫）
    /// </summary>
    public void PlayB()
    {
        if (audioSourceB != null) audioSourceB.Play();
    }
}
