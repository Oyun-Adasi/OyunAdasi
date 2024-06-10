using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public List<string> videoUrls = new List<string>();
    private UnityEngine.Video.VideoPlayer videoPlayer;
    public Camera mainCamera;
    public int index=0;

    void Start()
    {

        videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.source = VideoSource.Url;
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        mainCamera = Camera.main;
        videoPlayer.aspectRatio=VideoAspectRatio.FitInside;
        videoPlayer.targetCamera = mainCamera;
        videoPlayer.SetDirectAudioVolume(0, 0.00125f);
    }

    public void PlayVideos()
    {       
            videoPlayer.url = videoUrls[index];
            videoPlayer.Play();
    }
}
