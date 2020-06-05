using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> hearts;
    public float offset = 40;
    public PlayerController playerMovement;
    public Text score;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void SubtractLife()
    {
        if (hearts.Count > 0)
        {
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);

            if (hearts.Count == 0)
            {
                playerMovement.Die();
            }
        }
    }

    public void AddLife()
    {
        GameObject newHeart = Instantiate(hearts[hearts.Count - 1], transform);
        newHeart.transform.position = hearts[hearts.Count - 1].transform.position + Vector3.right * offset;
        hearts.Add(newHeart);
    }

    private void Update()
    {
        score.text = "Score: " + Mathf.RoundToInt(scoreManager.GetScore());
    }
}
