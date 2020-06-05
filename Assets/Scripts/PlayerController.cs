using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float xRange;
    public float ySpawn;
    public GameObject[] foods;
    public UIManager uiManager;
    public float dieWaitTime;
    private Animator anim;
    private bool dead = false;
    public ScenesManager scenesManager;
    private ScoreManager scoreManager;
    public ParticleSystem hitAnimalParticleEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.ResetScore();
        scoreManager.SetCountingScore(true);
    }

    void Update()
    {
        if (!dead)
        {
            transform.Translate(Vector3.right * movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                anim.SetBool("Moving", true);
            }
            else
            {
                anim.SetBool("Moving", false);
            }

            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject projectile = foods[Random.Range(0, foods.Length - 1)];
                Instantiate(projectile, transform.position + Vector3.up * ySpawn, projectile.transform.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        uiManager.SubtractLife();

        Instantiate(hitAnimalParticleEffect.gameObject, other.gameObject.transform.position, hitAnimalParticleEffect.transform.rotation);
    }

    public void Die()
    {
        anim.SetTrigger("Die");
        dead = true;
        scoreManager.SetCountingScore(false);

        StartCoroutine(WaitToSwitchToEndScene());
    }

    private IEnumerator WaitToSwitchToEndScene()
    {
        yield return new WaitForSeconds(dieWaitTime);

        scenesManager.GoToEndScreen();
    }
}
