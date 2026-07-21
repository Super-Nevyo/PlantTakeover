using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float VideoLength;
    void Awake()
    {
        EventManager.PlayVideo += Play;
    }
    private void OnDisable()
    {
        EventManager.PlayVideo -= Play;
    }
    public void Play()
    {
        videoPlayer.enabled = true;
        videoPlayer.Play();
        StartCoroutine(WaitToEndVideo());
    }
    private IEnumerator WaitToEndVideo()
    {
        yield return new WaitForSeconds(VideoLength);
        videoPlayer.enabled = false;
        EventManager.VideoOver?.Invoke();
    }
}
