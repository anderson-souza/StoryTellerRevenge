using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSphereController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    private TitleController _titleController;
    readonly Dictionary<string, string> _videoDictionary = new Dictionary<string, string>();

    // Use this for initialization
    void Start()
    {
        _videoPlayer = FindObjectOfType<VideoPlayer>();
        _titleController = FindObjectOfType<TitleController>();

        //The key value will be the name for the title
        _videoDictionary.Add("Car",
            "file://E:/Udacity/360 Media Production Assets/13 - Car (1.1 GB)/carExported.mp4"); // 1
        _videoDictionary.Add("Waterfall", ""); // 2
        _videoDictionary.Add("Rock", ""); // 3
        _videoDictionary.Add("Cliff", ""); // 4
        _videoDictionary.Add("Lava Field", ""); // 5

        NewVideo("Car", _videoDictionary["Car"]);
    }

    public void NewVideo(string title, string url)
    {
        _titleController.ChangeTitle(title);
        _videoPlayer.url = url;
        PlayVideo();
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