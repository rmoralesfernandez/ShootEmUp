using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakePart : MonoBehaviour
{
    Snake snake;
    Field field;
    public static int points = 0;
    private float time = 0;
    public Text pointsText, timeText, pointsTextShadow, timeTextShadow;
    private int maxTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        time = 0;
        snake = transform.parent.GetComponent<Snake>();
        field = FindObjectOfType<Field>();
    }

    void Update()
    {
        time += Time.deltaTime;
        pointsText.text = points.ToString();
        pointsTextShadow.text = points.ToString();
        timeText.text = time.ToString("f1");
        timeTextShadow.text = time.ToString("f1");
        if (time >= maxTime)
        {
            points += 5;
            maxTime += 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("food"))
        {
            var lastPart = snake.bodyParts[snake.bodyParts.Count - 1];
            var newPart = Instantiate(lastPart.gameObject, lastPart.position - lastPart.up * snake.step, lastPart.rotation, transform.parent);
            snake.bodyParts.Add(newPart.transform);
            Destroy(col.gameObject);
            points += 100;
            FoodMaker.isActive = false;
            if(snake.stepTime > snake.minStepTime)
            {
                snake.stepTime -= snake.StepTimeAdder;
            }
        } else if(!col.CompareTag("Border"))
        {
            Destroy(col.gameObject);
            snake.Die();
        }

        if(col.gameObject.tag == "Border")
        {
            snake.Die();
        }

        
    }
}
