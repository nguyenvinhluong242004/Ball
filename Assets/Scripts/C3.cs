using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3 : MonoBehaviour
{
    GameController gameController;
    AudioSource aus;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.getStatus())
        {
            transform.position = transform.position + new Vector3(0, -gameController.speed, 0);
            checkEnd();
        }
    }
    void checkEnd()
    {
        if (transform.position.y <= -5.1f)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crossbar")) // va cham xuyen
        {
            if (gameController.isSound)
                aus.PlayOneShot(sound);
            gameController.c3ball();
            Destroy(gameObject);
        }
    }
}
