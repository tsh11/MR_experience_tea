using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Translate : MonoBehaviour
{
    public TMP_Text readTaiwtext;
    private const string LANGUAGE_CODE = "zh-tw";
    private const string BASE_URL = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=";

    private AudioSource audioSource;

    // 播放控制
    private bool isPlayingAudio = false; // 確保協程只執行一次
    // private Coroutine playSpeakCoroutine = null; // 用來追蹤正在執行的協程

    // Speed control variable
    public float playbackSpeed = 1.5f; // Default 1.5x speed

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySpeak(BASE_URL + getString(readTaiwtext.text, LANGUAGE_CODE)));
    }

    // Updated PlaySpeak Coroutine using UnityWebRequest
    IEnumerator PlaySpeak(string url)
    {
        // Check if an audio is already playing, if so stop it
        if (isPlayingAudio)
        {
            // Wait for the current audio to finish
            yield return new WaitUntil(() => !audioSource.isPlaying);
            Debug.LogError("audioSource.isPlaying ");
        }

        // Start playing the new text audio
        isPlayingAudio = true;

        using (UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            // Send the web request and wait for a response
            yield return webRequest.SendWebRequest();

            // Check for errors
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Audio load failed: " + webRequest.error);
                isPlayingAudio = false; // Reset the flag on error
                yield break; // Exit if there was an error
            }

            // If successful, get the audio clip
            AudioClip audioClip = DownloadHandlerAudioClip.GetContent(webRequest);
            if (audioClip == null)
            {
                Debug.LogError("Failed to load audio clip.");
                isPlayingAudio = false; // Reset the flag if clip is null
                yield break; // Exit if the clip is null
            }

            // Adjust playback speed
            audioSource.pitch = playbackSpeed;  // Modify the pitch to change speed

            // Play the audio
            audioSource.clip = audioClip;
            audioSource.Play();

            // Wait until the audio has finished playing
            yield return new WaitUntil(() => !audioSource.isPlaying);

            isPlayingAudio = false; // Reset the flag when audio is done
        }
    }

    // Ensure the text is properly URL encoded
    private string getString(string text, string stateName)
    {
        // Properly escape the text for the URL and fix the language code
        string escapedText = UnityWebRequest.EscapeURL(text);
        return escapedText + "&tl=" + stateName;
    }
}
