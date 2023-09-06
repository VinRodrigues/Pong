using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab da segunda bola
    private GameObject secondBall; // Referência para a segunda bola em cena

    // Start is called before the first frame update
    void Start()
    {
        // Inicialmente, não há segunda bola em cena
        secondBall = null;
    }

    // Método para criar a segunda bola
    public void CreateSecondBall()
    {
        if (secondBall == null)
        {
            secondBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }

    // Método para remover a segunda bola
    public void RemoveSecondBall()
    {
        if (secondBall != null)
        {
            Destroy(secondBall);
            secondBall = null;
        }
    }
}
