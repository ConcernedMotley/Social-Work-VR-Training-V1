using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoControls : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private Material videoMaterial;
    
    private void Awake()
    {
        // _videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
        // PauseVideo(); // Pause the video, because the module script will control it

        this.gameObject.GetComponent<Renderer>().material = videoMaterial;

    }
    
    public float GetVideoTime()
    {
        return (float)videoPlayer.time;
    }

    public void SetVideoTime(float time)
    {
        videoPlayer.time = time;
        PlayVideo();
    }
    
    public void PlayVideo()
    {
        StartCoroutine(PlayVideoDelay(1));
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void RestartVideo()
    {
        SetVideoTime(0);
        // PlayVideo();
    }

    private IEnumerator PlayVideoDelay(float delayTime) // need this delay for the sync
    {
        yield return new WaitForSeconds(delayTime);
    }
    

}
