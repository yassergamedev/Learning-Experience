using UnityEngine;
using UnityEngine.Video;

public class ObjectController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;
    public VideoPlayer videoPlayer3;
    public VideoPlayer videoPlayer4;
   
    private int currentVideoIndex = 0;
    private bool isFirstClick = true;
    private bool isSecondClick = false;
    private bool isThirdClick = false;
    private bool isFourthClick = false;
    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    public void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);

        // Stop all video players except the first one
       
    }


    public void TeleportRandomly()
    {
        // Code for teleportation...
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    public void OnPointerClick()
    {
        if (isFirstClick)
        {
            videoPlayer1.Play();
        }
        if (isSecondClick)
        {
            videoPlayer2.Play();
        }
        if (isThirdClick)
        {
            videoPlayer3.Play();
        }
        if (isFourthClick)
        {
            videoPlayer4.Play();
        }

    }

    public void Update()
    {
          if(videoPlayer1.isPrepared && isFirstClick)
        {
            isFirstClick = false;
            isSecondClick = true;
        }
        if (videoPlayer2.isPrepared && isSecondClick)
        {
        
            isSecondClick = false;
            isThirdClick
                = true;
        }
        if (videoPlayer3.isPrepared && isThirdClick)
        {
            isThirdClick = false;
            isFourthClick = true;
        }
        if (videoPlayer4.isPrepared && isFourthClick)
        {
            isFourthClick = false;
          
        }

    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
