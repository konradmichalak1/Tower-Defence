using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPauseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
