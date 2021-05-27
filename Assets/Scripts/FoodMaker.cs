using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMaker : MonoBehaviour
{
    public GameObject food, poison;
    public float maxPoisonChance, poisonChance, poisonChanceAdder;
    Field field;
    private float time = 0f;
    private float maxTime = 5f;
    public static bool isActive = false;
    private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        maxTime = 5f;
        poisonChance = 0f;
        isActive = false;
        field = FindObjectOfType<Field>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= maxTime || transform.childCount == 0)
        {
            time = 0f;
        }

        if(time == 0)
        {
            if(transform.childCount == 1)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            Make();
        }

        time += Time.deltaTime;
    }

    void Make()
    {
        var chance = Random.Range(0f, 1f);
        //GameObject item;

        if(chance > poisonChance)
        {
            item = food;
        } else
        {
            item = poison;
        }

        var randomCell = field.emptyCells[Random.Range(0, field.emptyCells.Count - 1)];
        var position = randomCell.position;

        Instantiate(item, position, Quaternion.identity, transform);
        isActive = true;

        if (poisonChance < maxPoisonChance)
        {
            poisonChance += poisonChanceAdder;
        }
    }
}
