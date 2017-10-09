using UnityEngine;
using UnityEngine.Video;

public class VideoSphereController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    // Use this for initialization
    void Start()
    {
        if (_videoPlayer == null)
        {
            _videoPlayer = GameObject.FindObjectOfType<VideoPlayer>();
        }
    }

    public void PlayVideo()
    {
        _videoPlayer.Play();
    }

    public void PauseVideo()
    {
        _videoPlayer.Pause();
    }

    public void RestartVideo()
    {
        _videoPlayer.Stop();
        _videoPlayer.Play();
    }
    
}