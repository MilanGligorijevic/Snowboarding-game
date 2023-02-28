using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem fallEffect;
    [SerializeField] AudioClip fallSFX;
    bool crashed = false;
    void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Ground" && crashed == false)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            fallEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(fallSFX);
            Invoke("ReloadScene", delayTime);
            crashed = true;
        }
   }

   void ReloadScene()
   {
    SceneManager.LoadScene(0);
  
   }
}
