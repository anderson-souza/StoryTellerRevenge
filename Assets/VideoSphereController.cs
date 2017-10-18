using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSphereController : MonoBehaviour {
    private VideoPlayer _videoPlayer;

    private TitleController _titleController;
    private int _actualVideo;
    private ParticleSystem _particleSystem;
    private GvrVideoPlayerTexture _gvrVideoPlayerTexture;
    private Action callbackVideo;

    private readonly List<Videos> _videoses = new List<Videos>();

    // Use this for initialization
    void Start() {
        _videoPlayer = GetComponent<VideoPlayer>();
        _titleController = FindObjectOfType<TitleController>();
        _particleSystem = FindObjectOfType<ParticleSystem>();
        _gvrVideoPlayerTexture = GetComponent<GvrVideoPlayerTexture>();

        _videoses.Add(new Videos("Car",
            "https://onedrive.live.com/download?cid=E29AE0C338BE57F1&resid=E29AE0C338BE57F1%2114809&authkey=AEeOLV6Z_hT2uMU"));
        _videoses.Add(new Videos("Waterfall",
            "file://E:/Udacity/360 Media Production Assets/Exported files/Waterfall.mp4"));
        _videoses.Add(new Videos("Rock",
            "file://E:/Udacity/360 Media Production Assets/Exported files/Big Pointy Rock.mp4"));
        _videoses.Add(new Videos("Cliff", "file://E:/Udacity/360 Media Production Assets/Exported files/Cliff.mp4"));
        _videoses.Add(new Videos("Lava Field",
            "file://E:/Udacity/360 Media Production Assets/Exported files/lavaFields.mp4"));

        NewVideo(0);

        // Each time we reach the end, calls the function EndReached
        _videoPlayer.loopPointReached += EndReached;
        _gvrVideoPlayerTexture.SetOnVideoEventCallback(GvrVideoCallback);
    }

    private void GvrVideoCallback(int eventId) {
        switch (eventId) {
            case (int) GvrVideoPlayerTexture.VideoEvents.VideoReady:
                Debug.Log("Video Ready");
                break;
            case (int) GvrVideoPlayerTexture.VideoEvents.VideoStartPlayback:
                Debug.Log("Video start");
                break;
            default:
                Debug.Log("Another event");
                break;
        }
    }

    public void NewVideo(int position) {
        //Receives the position of the array of videos
        Debug.Log("Started a new video");
        _actualVideo = position;
        if (_actualVideo == 0) {
            //If is the first video, play the Particles
            _particleSystem.Play();
        }
        else {
            _particleSystem.Stop();
        }
        //_videoPlayer.url = _videoses[position].Url;
        _titleController.ChangeTitle(_videoses[position].Title); //Change the title

        _gvrVideoPlayerTexture.videoURL = _videoses[position].Url;
        _gvrVideoPlayerTexture.videoType = GvrVideoPlayerTexture.VideoType.Dash;
        _gvrVideoPlayerTexture.videoProviderId = string.Empty;
        _gvrVideoPlayerTexture.videoContentID = string.Empty;
        _gvrVideoPlayerTexture.CleanupVideo();
        _gvrVideoPlayerTexture.ReInitializeVideo();
        PlayVideo();
    }

    public void PlayVideo() {
        //_videoPlayer.Play();
        _gvrVideoPlayerTexture.Play();
    }

    public void PauseVideo() {
        //_videoPlayer.Pause();
        _gvrVideoPlayerTexture.Pause();
    }

    public void RestartVideo() {
        /*_videoPlayer.Stop();
        _videoPlayer.Play();*/
        _gvrVideoPlayerTexture.ReInitializeVideo();
    }

    private void EndReached(VideoPlayer vp) {
        if (_videoses.Count < _actualVideo) {
            NewVideo(_actualVideo++);
        }
        else {
            //Show Credits
        }
    }
}