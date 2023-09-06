using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iacontrol : MonoBehaviour
{
    private float velocidademov;
    private bool iA;
    private GameObject ball; // Corrigido: removido "object" e corrigido o tipo para "GameObject"
    private Rigidbody2D rb2d; // Corrigido: adicionado Rigidbody2D
    private Vector2 playerMove;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iA)
        {
            AiControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
     //   playerMove = new Vector2(0, Input.GetAxiesRaw("Vertical"));
    }
    private void AiControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }
}
