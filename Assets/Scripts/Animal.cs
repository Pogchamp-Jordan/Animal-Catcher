using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private UIManager uiManager;
    public float zPosToLoseLife;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (transform.position.z <= zPosToLoseLife)
        {
            uiManager.SubtractLife();
            Destroy(gameObject);
        }
    }
}
