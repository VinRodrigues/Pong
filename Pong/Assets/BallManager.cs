using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab da segunda bola
    private GameObject secondBall; // Refer�ncia para a segunda bola em cena

    // Start is called before the first frame update
    void Start()
    {
        // Inicialmente, n�o h� segunda bola em cena
        secondBall = null;
    }

    // M�todo para criar a segunda bola
    public void CreateSecondBall()
    {
        if (secondBall == null)
        {
            secondBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }

    // M�todo para remover a segunda bola
    public void RemoveSecondBall()
    {
        if (secondBall != null)
        {
            Destroy(secondBall);
            secondBall = null;
        }
    }
}
