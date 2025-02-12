using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform paddle;
    private Rigidbody ball;
    private Vector3 check;
    private Paddle pad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Rigidbody>();
        check = ball.linearVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        check = ball.linearVelocity;
    }

    // This power-up increases the size of the paddle
    public void PowerUp()
    {
        if (check.x <= 0)
        {
            paddle = GameObject.Find("Right Paddle").GetComponent<Transform>();
            paddle.transform.localScale += new Vector3(0f, 0f, 1.5f);
        }
        else
        {
            paddle = GameObject.Find("Left Paddle").GetComponent<Transform>();
            paddle.transform.localScale += new Vector3(0f, 0f, 1.5f);
        }
        //pad = GameObject.Find("Right Paddle").GetComponent<Paddle>();
        //pad.maxTravelHeight = 2.25f;
        //pad.minTravelHeight = 2.25f;
    }

    // This power-up increases the speed of the paddle
    public void PowerUp2()
    {
        if (check.x <= 0)
        {
            pad = GameObject.Find("Right Paddle").GetComponent<Paddle>();
            pad.speed += 2f;
            
        }
        else
        {
            pad = GameObject.Find("Left Paddle").GetComponent<Paddle>();
            pad.speed += 2f;
        }
    }
}
