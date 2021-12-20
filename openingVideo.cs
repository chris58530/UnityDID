using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class openingVideo : MonoBehaviour
{
    public float videoTime;
    VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>(); 
    }


    void Start()
    {
        videoPlayer.Play();
    }

    void Update()
    {
        StartCoroutine(LoadScene());
        if (Input.GetMouseButtonDown(0))        
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);        
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(videoTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
