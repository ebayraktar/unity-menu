using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private bool down = true;
    private float x, y;
    //private GameManager gameManager;


    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            if (transform.position.y - y < 0.05f)
            {
                down = false;
                transform.position = new Vector3(x, y, 0);
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, 0), Time.deltaTime * 3f);
        }
    }

    public void NewLocation(float _x, float _y)
    {
        x = _x;
        y = _y;
    }
    private void Check()
    {
    }
}
