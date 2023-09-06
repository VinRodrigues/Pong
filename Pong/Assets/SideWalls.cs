using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    public AudioClip somDeColisao;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        GameManager gameManager = FindObjectOfType<GameManager>(); // Encontre a instância do GameManager

        if (hitInfo.name == "Ball" && gameManager != null)
        {
            string wallName = transform.name;
            gameManager.Score(wallName); // Chame o método Score na instância do GameManager
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);

            if (somDeColisao != null)
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
        if (hitInfo.name == "Ball2" && gameManager != null)
        {
            string wallName = transform.name;
            gameManager.Score(wallName); // Chame o método Score na instância do GameManager
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);

            if (somDeColisao != null)
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
}
