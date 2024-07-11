using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Animator animator;
    AudioSource obstacleSound;
    string startAnim = "start_obstacle";
    public float startInterval = 0f;
    public float interval = 3f;
    void Start()
    {
        animator = GetComponent<Animator>();
        obstacleSound = GetComponent<AudioSource>();
        StartCoroutine(PlayObstacleAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayObstacleAnim()
    {
        yield return new WaitForSeconds(startInterval);
        while (true)
        {
            animator.Play(startAnim);
            obstacleSound.Play();
            yield return new WaitForSeconds(interval);
        }
    }
}
