using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownItem : MonoBehaviour
{
    public float animTime;
    public float speed;
    float time;
    Vector3 goal_pos_1;
    Vector3 goal_pos_2;

    void Start()
    {
        goal_pos_1 = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        goal_pos_2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < animTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal_pos_1, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, goal_pos_2, speed);
            if (time > 2 * animTime)
            {
                time = 0;
            }
        }
        time += Time.deltaTime;
    }
}
