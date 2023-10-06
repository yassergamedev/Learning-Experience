using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;


public class VideoPlaneController : MonoBehaviour
{
    public Material inactiveMaterial;
    public Material activeMaterial;
    public VideoPlayer videoPlayer;

    private Renderer myRenderer;
    private bool isPlaying = false;
    private bool isGazedAt = false;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        videoPlayer.Stop();
    }

    private void Update()
    {
        if (isGazedAt && Input.GetMouseButtonDown(0))
        {
            if (isPlaying)
            {
                PauseVideo();
            }
            else
            {
                PlayVideo();
            }
        }
    }

    private void PlayVideo()
    {
        videoPlayer.Play();
        isPlaying = true;
        SetMaterial(true);
    }

    private void PauseVideo()
    {
        videoPlayer.Pause();
        isPlaying = false;
        SetMaterial(false);
    }

    private void SetMaterial(bool active)
    {
        if (active)
        {
            myRenderer.material = activeMaterial;
        }
        else
        {
            myRenderer.material = inactiveMaterial;
        }
    }

    private void OnMouseEnter()
    {
        isGazedAt = true;
        SetMaterial(true);
    }

    private void OnMouseExit()
    {
        isGazedAt = false;
        SetMaterial(false);
    }
}
