using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colidewall : MonoBehaviour
{
    public AudioClip somDeColisao; 

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball" && somDeColisao != null)
        {
            
            AudioSource audioSource = hitInfo.gameObject.GetComponent<AudioSource>();

           
            if (audioSource == null)
            {
                audioSource = hitInfo.gameObject.AddComponent<AudioSource>();
            }

            
            audioSource.clip = somDeColisao;

            
            audioSource.Play();
        }
    }
}