using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSphereController : MonoBehaviour {
    private VideoPlayer _videoPlayer;

    private TitleController _titleController;
    private int _actualVideo;
    private ParticleSystem _particleSystem;

    private readonly List<Videos> _videoses = new List<Videos>();

    // Use this for initialization
    void Start() {
        _videoPlayer = FindObjectOfType<VideoPlayer>();
        _titleController = FindObjectOfType<TitleController>();
        _particleSystem = FindObjectOfType<ParticleSystem>();

        _videoses.Add(new Videos("Car",
            "https://youtu.be/QIbZatwsEgU"));
        _videoses.Add(new Videos("Waterfall", ""));
        _videoses.Add(new Videos("Rock", ""));
        _videoses.Add(new Videos("Cliff", ""));
        _videoses.Add(new Videos("Lava Field", ""));

        NewVideo(0);

        // Each time we reach the end, calls the function EndReached
        _videoPlayer.loopPointReached += EndReached;
    }

    public void NewVideo(int position) {
        Debug.Log("Started a new video");
        _actualVideo = position;
        if (_actualVideo == 0) { //If is the first video, play the Particles
            _particleSystem.Play();
        }
        else {
            _particleSystem.Stop();
        }
        _titleController.ChangeTitle(_videoses[position].Title); //Change the title
        _videoPlayer.url = _videoses[position].Url;
        PlayVideo();
    }

    public void PlayVideo() {
        _videoPlayer.Play();
    }

    public void PauseVideo() {
        _videoPlayer.Pause();
    }

    public void RestartVideo() {
        _videoPlayer.Stop();
        _videoPlayer.Play();
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