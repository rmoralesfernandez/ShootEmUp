using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();
    public float minStepTime, maxStepTime, StepTimeAdder;
    public float stepTime, step;
    public float delta = 0f;
    private Transform head;
    private Vector2 moveDirection = Vector2.up;
    public GameObject activeDie;
    public Text pointsEndText;
    ScoreController scoreController;

    // Start is called before the first frame update
    void Start()
    {
        head = bodyParts[0];
        stepTime = maxStepTime;
        scoreController = FindObjectOfType<ScoreController>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        control();
        if(delta >= stepTime)
        {
            move();
            delta = 0f;
        }
        delta += Time.deltaTime;
    }

    void control()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (moveDirection != Vector2.down)
            {
                moveDirection = Vector2.up;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (moveDirection != Vector2.up)
            {
                moveDirection = Vector2.down;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (moveDirection != Vector2.right)
            {
                moveDirection = Vector2.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (moveDirection != Vector2.left)
            {
                moveDirection = Vector2.right;
            }
        }
        
    }

    void move()
    {
        for (int i = bodyParts.Count - 1; i >= 1; i--)
        {
            var part = bodyParts[i];
            var nextPart = bodyParts[i - 1];
            part.rotation = nextPart.rotation;
            part.position = nextPart.position;
        }

        head.up = moveDirection;
        head.position += head.up * step;
    }

    public void Die()
    {
        Time.timeScale = 0f;
        scoreController.PlayerDie();
        pointsEndText.text = SnakePart.points.ToString();
        activeDie.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
