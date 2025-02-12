using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public Transform paddle;
    private Paddle pad;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public TextMeshProUGUI LeftPlayerScore;
    public TextMeshProUGUI RightPlayerScore;

    int leftPlayerScore;
    int rightPlayerScore;
    Vector3 ballStartPos;

    const int scoreToWin = 11;

    //---------------------------------------------------------------------------
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.linearVelocity = new Vector3(1f, 0f, 0f) * startSpeed;
        SetCountText();
    }

    void SetCountText()
    {
        LeftPlayerScore.text = "Score: " + leftPlayerScore.ToString();
        Color randomColorLeft = new Color(Random.value, Random.value, Random.value);
        LeftPlayerScore.color = randomColorLeft;
        RightPlayerScore.text = "Score: " + rightPlayerScore.ToString();
        Color randomColorRight = new Color(Random.value, Random.value, Random.value);
        RightPlayerScore.color = randomColorRight;
    }


    //---------------------------------------------------------------------------
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball

        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");

            if (rightPlayerScore == scoreToWin)
                Debug.Log("Right player wins!");
            else
                ResetBall(-1f);

            SetCountText();
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");

            if (leftPlayerScore == scoreToWin)
                Debug.Log("Left player wins!");
            else
                ResetBall(1f);

            SetCountText();
        }
        ResetPaddle();
    }

    //---------------------------------------------------------------------------
    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(-directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.linearVelocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }

    void ResetPaddle()
    {
        paddle = GameObject.Find("Right Paddle").GetComponent<Transform>();
        paddle.transform.localScale = new Vector3(0.75f, 1f, 4f);
        paddle = GameObject.Find("Left Paddle").GetComponent<Transform>();
        paddle.transform.localScale = new Vector3(0.75f, 1f, 4f);
        pad = GameObject.Find("Right Paddle").GetComponent<Paddle>();
        pad.speed = 3f;
        pad = GameObject.Find("Left Paddle").GetComponent<Paddle>();
        pad.speed = 3f;
    }
}
