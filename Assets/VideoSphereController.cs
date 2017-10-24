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
    private GameObject _canvasPath;
    private GameObject _creditsCanvas;
    private GameObject _canvasControls;
    private readonly List<Videos> _videoses = new List<Videos>();

    // Use this for initialization
    void Start() {
        _videoPlayer = GetComponent<VideoPlayer>();
        _titleController = FindObjectOfType<TitleController>();
        _particleSystem = FindObjectOfType<ParticleSystem>();
        _canvasPath = GameObject.Find("CanvasPath");
        _creditsCanvas = GameObject.Find("CanvasCredits");
        _canvasControls = GameObject.Find("CanvasControls");

        _videoses.Add(new Videos("Car",
            "https://anderson-souza.000webhostapp.com/videos/carExported_injected.mp4"));
        _videoses.Add(new Videos("Waterfall",
            "https://anderson-souza.000webhostapp.com/videos/Waterfall.mp4"));
        _videoses.Add(new Videos("Rock",
            "https://anderson-souza.000webhostapp.com/videos/Big%20Pointy%20Rock.mp4"));
        _videoses.Add(new Videos("Cliff", "https://anderson-souza.000webhostapp.com/videos/Cliff.mp4"));
        _videoses.Add(new Videos("Lava Fields",
            "https://anderson-souza.000webhostapp.com/videos/lavaFields.mp4"));

        NewVideo(0); //Start the first video

        // Each time we reach the end, calls the function EndReached
        _videoPlayer.loopPointReached += EndReached;
    }

    //Receives the position of the array of videos
    public void NewVideo(int position) {
        Debug.Log("Started a new video at position: " + position);
        _actualVideo = position;
        if (_actualVideo == 0) {
            //If is the first video, play the Particles
            _particleSystem.Play();
            _canvasPath.SetActive(true);
        }
        else {
            _particleSystem.Stop();
            _canvasPath.SetActive(false);
        }
        _videoPlayer.url = _videoses[position].Url;
        PlayVideo();
    }

    public void PlayVideo() {
        _titleController.ChangeTitle(_videoses[_actualVideo].Title); //Change the title
        _videoPlayer.Play();
    }

    public void PauseVideo() {
        _videoPlayer.Pause();
    }

    public void RestartVideo() {
        StopVideo();
        PlayVideo();
    }

    public void StopVideo() {
        _videoPlayer.Stop();
    }

    private void EndReached(VideoPlayer vp) {
        Debug.Log("End of the video. ActualVideo: " + _actualVideo + ". _videoses.Count: " + _videoses.Count);
        if (_actualVideo < _videoses.Count) {
            _actualVideo++;
            NewVideo(_actualVideo);
        }
        else {
            //Show Credits
            _creditsCanvas.SetActive(true);
            _canvasControls.SetActive(false);
        }
    }
}