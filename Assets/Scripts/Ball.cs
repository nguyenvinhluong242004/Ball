using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject newObjectPrefab;
    GameController gameController;
    Ball[] balls;
    Crossbar cr;
    public float speed; // Tốc độ di chuyển của quả bóng
    public Vector2 velocity; // Vận tốc của quả bóng
    public bool isCreat;
    AudioSource aus;
    public AudioClip sound;
    // Khởi tạo giá trị ban đầu
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        cr = FindObjectOfType<Crossbar>();
        speed = gameController.speed;
        if (!isCreat)
        {
            velocity = new Vector2(speed, speed);
        }
    }

    // Cập nhật vị trí của quả bóng
    void Update()
    {
        if (gameController.getStatus())
        {
            transform.position+=(Vector3)(velocity);
            CheckWallCollision();
            checkEnd();
        }
    }

    // Xử lý va chạm tường bật
    void CheckWallCollision()
    {
        if (transform.position.x <= -2.337f)
        {
            if (gameController.isSound)
                aus.PlayOneShot(sound);
            velocity.x = -velocity.x;
            transform.position = new Vector3(-2.337f, transform.position.y, 0);
        }
        else if (transform.position.x >= 2.337f)
        {
            if (gameController.isSound)
                aus.PlayOneShot(sound);
            velocity.x = -velocity.x;
            transform.position = new Vector3(2.337f, transform.position.y, 0);
        }    
        if (transform.position.y >= 3.973f)
        {
            if (gameController.isSound)
                aus.PlayOneShot(sound);
            velocity.y = -velocity.y;
            transform.position = new Vector3(transform.position.x, 3.973f, 0);
        }
    }
    void checkEnd()
    {
        if (transform.position.y <= -5.1f)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crossbar"))
        {
            if (gameController.isSound)
                aus.PlayOneShot(sound);
            float xC = cr.getSpeed();
            float xc = xC * Time.deltaTime;

            velocity.y = -velocity.y;

            xC = Mathf.Sqrt(((velocity.x + xc) * (velocity.x + xc) + velocity.y * velocity.y) / (velocity.x * velocity.x + velocity.y * velocity.y));
            velocity.x = (velocity.x + xc) / xC;
            velocity.y = velocity.y / xC;
        }    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Vector2 point = contact.point;
        // Nhận biết mặt nào của hình vuông
        Vector2 normal = contact.normal;
        {
            if (normal == Vector2.up || normal == Vector2.down)
            {
                velocity.y = -velocity.y;
            }
            else if (normal == Vector2.right || normal == Vector2.left)
            {
                velocity.x = -velocity.x;
            }
        }
        if (gameController.isSound)
            aus.PlayOneShot(sound);
        
    }
}
