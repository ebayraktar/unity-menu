using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {
    private GameManager testMgr;
    private void Start()
    {
        testMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnMouseDown()
    {
        testMgr.Click(gameObject);
    }
}
