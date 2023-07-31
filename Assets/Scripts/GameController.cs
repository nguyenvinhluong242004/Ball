using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    AudioSource aus;
    public AudioClip sound;
    Ball ball;
    Square square;
    Ball[] balls;
    Crossbar cr;
    public GameObject obiject, bal, squa, wal, c3, x3, obj, _obj, _continue, tableLever, _try, start, play, pause, setting, on, off, onS, offS;
    bool isEnd;
    int lever;
    int point;
    bool isStart, isChooseLever;
    bool isPlay;
    public bool isSound, isMusic;
    public float speed;
    int sceneLV;
    //Demo
    float[,] D = new float[26, 21];
    // Start is called before the first frame update
    void Start()
    {
        aus = FindObjectOfType<AudioSource>();
        GameObject newObject = Instantiate(obj, new Vector3(0, 0, 0), transform.rotation);
        newObject.transform.parent = obiject.transform;
        lever = 1;
        point = 1;
        speed = 0.017f;
        sceneLV = 1;
        isEnd = true;
        isStart = true;
        isPlay = true;
        isChooseLever = false;
        isSound = true;
        isMusic = true;
        aus.loop = true;
        aus.clip = sound;
        aus.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (isChooseLever && !isStart)
        {
            Init();
            isChooseLever = false;
        }    
        if (!isEnd)
        {
            checkWin();
        }     
    }
    void initLever(int lever)
    {
        if (lever == 1)
        {
            for (float i=1; i<4f; i+=1f)
                for (float j=-2.2f; j<-1.6f; j += 0.15f)
                {
                    creatSquare(j, i);
                    creatSquare(j+1, i);
                    creatSquare(j+2, i);
                    creatSquare(j+3, i);
                    creatSquare(j+4, i);
                }  
                    
        }
        else if (lever == 2)
        {
            for (float i = -2.3f; i < 2.4f; i += 1f)
            {
                creatWall(i, 1.075f, 0.15f, 0.3f);
                creatWall(i, 2.075f, 0.15f, 0.3f);
                creatWall(i, 3.075f, 0.15f, 0.3f);
            }
            for (float i = 1; i < 4f; i += 1f)
                for (float j = -2.15f; j < -1.6f; j += 0.15f)
                {
                    creatSquare(j, i);
                    creatSquare(j + 1, i);
                    creatSquare(j + 2, i);
                    creatSquare(j + 3, i);
                    creatSquare(j + 4, i);
                    creatSquare(j, i + 0.15f);
                    creatSquare(j + 1, i + 0.15f);
                    creatSquare(j + 2, i + 0.15f);
                    creatSquare(j + 3, i + 0.15f);
                    creatSquare(j + 4, i + 0.15f);
                }
        }
        else if (lever == 3)
        {
            for (float i = -0.4f; i < 3.4f; i += 0.8f)
                creatWall(0f, i + 0.4f, 4.35f, 0.15f);
            for (float i = -0.15f; i < 3.6f; i += 0.8f)
                for (float j = -2.1f; j < 2.2f; j += 0.15f)
                    creatSquare(j, i + 0.3f);
        }
        else if (lever == 4)
        {
            for (float i = -1.1f; i < 3.2f; i += 1.6f)
            {
                creatWall(i, 0.1f, 0.3f, 0.3f);
                creatWall(i, 1.7f, 0.3f, 0.3f);
                creatWall(i, 3.3f, 0.3f, 0.3f);
            }
            for (float i = -1.9f; i < 2.4f; i += 1.6f)
            {
                creatWall(i, 0.9f, 0.3f, 0.3f);
                creatWall(i, 2.5f, 0.3f, 0.3f);
            }
            creatWall(0f, -0.6f, 4.3f, 0.15f);
            for (float i = 0.8f; i < 3f; i += 1.6f)
            {
                for (float j = -1.2f; j < -1f; j += 0.15f)
                {
                    creatSquare(j, i);
                    creatSquare(j, i + 0.15f);
                    creatSquare(j + 1.6f, i);
                    creatSquare(j + 1.6f, i + 0.15f);
                    creatSquare(j + 3.2f, i);
                    creatSquare(j + 3.2f, i + 0.15f);
                }
            }
            for (float i = 0; i < 4f; i += 1.6f)
            {
                for (float j = -2f; j < -1.8f; j += 0.15f)
                {
                    creatSquare(j, i);
                    creatSquare(j, i + 0.15f);
                    creatSquare(j + 1.6f, i);
                    creatSquare(j + 1.6f, i + 0.15f);
                    creatSquare(j + 3.2f, i);
                    creatSquare(j + 3.2f, i + 0.15f);
                }
            }
        }
        else if (lever == 5)
        {
            creatWall(-1.275f, 0.45f, 1.8f, 0.15f);
            creatWall(1.275f, 0.45f, 1.8f, 0.15f);
            creatWall(0f, 3.6f, 4.05f, 0.15f);
            creatWall(2.1f, 2.1f, 0.15f, 3.15f);
            creatWall(-2.1f, 2.1f, 0.15f, 3.15f);
            for (float i = -1.95f; i <= 2.05f; i += 0.15f)
                for (float j = 0.6f; j <= 3.6f; j += 0.15f)
                    creatSquare(i, j);
        }
        else if (lever == 6)
        {
            creatWall(-1.2f, 0.45f, 1.95f, 0.15f);
            creatWall(1.275f, 0.45f, 1.8f, 0.15f);
            creatWall(0f, 3.6f, 4.05f, 0.15f);
            creatWall(2.1f, 2.1f, 0.15f, 3.15f);
            creatWall(-2.1f, 2.1f, 0.15f, 3.15f);

            creatWall(-1.2f, 2.55f, 0.75f, 0.75f);
            creatWall(1.2f, 2.55f, 0.75f, 0.75f);
            creatWall(0f, 1.275f, 3.15f, 0.6f);
            for (float i = -1.95f; i <= 2.05f; i += 0.15f)
                for (float j = 0.6f; j <= 3.6f; j += 0.15f)
                {
                    if (j>=3||(j>=1.6f&&j<=2.2f)||j<=0.9f)
                        creatSquare(i, j);
                    else if (j>=1.6f&&(i<=-2f||i>=2f||(i>=-0.8f&&i<=0.8f)))
                        creatSquare(i, j);
                    else if (i <= -1.6f || i >= 1.6f)
                        creatSquare(i, j);
                }
        }
        else if (lever == 7)
        {
            creatWall(-1.125f, 3.6f, 2.1f, 0.15f);
            creatWall(1.275f, 3.6f, 1.8f, 0.15f);
            creatWall(0f, 0.45f, 4.055f, 0.15f);
            creatWall(2.1f, 1.95f, 0.15f, 3.15f);
            creatWall(-2.1f, 1.95f, 0.15f, 3.15f);
            for (float i = -1.95f; i <= 2.05f; i += 0.15f)
                for (float j = 0.6f; j <= 3.6f; j += 0.15f)
                    creatSquare(i, j);
        }
        else if (lever == 8)
        {
            creatWall(-1.125f, 0.45f, 2.1f, 0.15f);
            creatWall(1.2f, 0.45f, 1.95f, 0.15f);
            creatWall(0f, 3.6f, 4.05f, 0.15f);
            creatWall(2.1f, 2.1f, 0.15f, 3.15f);
            creatWall(-2.1f, 2.1f, 0.15f, 3.15f);

            creatWall(0f, 2.7f, 3.6f, 0.15f);
            creatWall(-1.05f, 2.05f, 0.15f, 2.5f);
            creatWall(0.75f, 2.05f, 0.15f, 2.5f);

            for (float i = -1.95f; i < 0.65f; i += 0.15f)
                for (float j = 0.6f; j <= 3.6f; j += 0.15f)
                    if ((j < 2.6f || j > 2.8f)&&(i < -1.15f || i > -0.95f))
                        creatSquare(i, j);
            for (float i = 0.9f; i <= 2.05f; i += 0.15f)
                for (float j = 0.6f; j <= 3.6f; j += 0.15f)
                    if (j < 2.6f || j > 2.8f)
                        creatSquare(i, j);

        }
        else if (lever == 9)
        {
            creatWall(-0.425f, 0.45f, 3.5f, 0.15f);
            creatWall(1.875f, 0.45f, 0.6f, 0.15f);
            creatWall(-0.025f, 3.6f, 4.2f, 0.15f);
            creatWall(2.1f, 2.1f, 0.15f, 3.15f);
            creatWall(-2.1f, 2.1f, 0.15f, 3.15f);
            creatWall(-0.3f, 2.175f, 0.15f, 2.7f);
            creatWall(1.25f, 1.875f, 0.15f, 2.7f);
            creatWall(0.225f, 1.875f, 0.15f, 2.7f);
            creatWall(0.77f, 2.175f, 0.15f, 2.7f);
            creatWall(1.7f, 2f, 0.15f, 2.4f);
            creatWall(1.475f, 0.875f, 0.3f, 0.15f);
            for (float i = -1.95f; i < -0.4f; i += 0.15f)
                for (float j = 0.6f; j <= 3.6f; j += 0.15f)
                        creatSquare(i, j);
        }
    }
    void getC3() 
    {
        if (point == 4)
        {
            creatC3();
            point++;
        }    
        else if (point%36==0)
        {
            creatC3();
            point++;
        }    
    }   
    void getX3()
    {
        if (point == 8)
        {
            creatX3();
            point++;
        }
        else if (point == 15)
        {
            creatX3();
            point++;
        }
        else if (point % 72 == 0)
        {
            creatX3();
            point++;
        }
    }    
    void Init()
    {
        _obj = Instantiate(obj, new Vector3(0, 0, 0), transform.rotation);
        _obj.transform.parent = obiject.transform;
        isEnd = false;
        point = 1;
        obiject.SetActive(true);
        initLever(lever);
        creatBall();
    }
    void checkWin()
    {
        square = FindObjectOfType<Square>();
        if (!square)
        {
            lever++;
            Destroy(_obj);
            isEnd = true;
            _continue.SetActive(true);
        }    
        else
            checkLose();
    }
    void checkLose()
    {
        ball = FindObjectOfType<Ball>();
        if (!ball)
        {
            Destroy(_obj);
            isEnd = true;
            obiject.SetActive(false);
            _try.SetActive(true);

        }
    }
    public bool getStatus()
    {
        if (isPlay)
            return true;
        return false;
    }
    public void setStatus(bool sta)
    {
        isPlay = sta;
        if (isPlay)
        {
            pause.SetActive(false);
            play.SetActive(true);
        }
        else
        {
            play.SetActive(false);
            pause.SetActive(true);
        }
    }
    public void setBackAgain()
    {
        if (!isEnd)
        {
            Destroy(_obj);
            isEnd = true;
            obiject.SetActive(false);
            Init();
        }
    }
    public void getSetting()
    {
        isStart = false;
        isEnd = true;
        isChooseLever = false;
        start.SetActive(false);
        setting.SetActive(true);
        sceneLV++;
    }
    public void setSound(bool sta)
    {
        if (sta)
        {
            offS.SetActive(false);
            onS.SetActive(true);
            isSound = true;
        }
        else
        {
            onS.SetActive(false);
            offS.SetActive(true);
            isSound = false;
        }
    }
    public void setMusic(bool sta)
    {
        if (sta)
        {
            off.SetActive(false);
            on.SetActive(true);
            isMusic = true;
            aus.Play();
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
            isMusic = false;
            aus.Stop();
        }
    }    
    public void setScene()
    {
        if (sceneLV==3)
        {
            Destroy(_obj);
            isEnd = true;
            obiject.SetActive(false);
            _continue.SetActive(false);
            _try.SetActive(false);
            tableLever.SetActive(true);
            sceneLV--;
        }
        else if (sceneLV==2)
        {
            isStart = true;
            setting.SetActive(false);
            tableLever.SetActive(false);
            start.SetActive(true);
            sceneLV--;
        }
        isChooseLever = false;
    }
    public void setStart()
    {
        isStart = false;
        isEnd = true;
        isChooseLever = false;
        start.SetActive(false);
        tableLever.SetActive(true);
        sceneLV++;
    }
    public void setLever(int _lever)
    {
        lever = _lever;
        isChooseLever = true;
        tableLever.SetActive(false);
        sceneLV++;
    }    
    public void chooseContinue()
    {
        _continue.SetActive(false);
        Debug.Log("done");
        Init();
    }   
    public void playAgain()
    {
        Debug.Log("click");
        _try.SetActive(false);
        Init();
    }
    public void increaseSpeed(float k)
    {
        if (speed + k > 0)
            speed += k;
    }    
    public void increasePoint()
    {
        point++;
        getC3();
        getX3();
    }     // tăng point lên 1
    void creatBall()
    {
        cr = FindObjectOfType<Crossbar>();
        float x = cr.getX();
        GameObject newObject = Instantiate(bal, new Vector3(x, -3.92f, 0), transform.rotation);
        newObject.transform.parent = _obj.transform;
        newObject.GetComponent<Ball>().isCreat = false;
    }
    void creatWall(float x, float y, float width, float height)
    {
        GameObject newObject = Instantiate(wal, new Vector3(x, y, 0), transform.rotation);
        newObject.transform.parent = _obj.transform;
        newObject.transform.localScale = new Vector3(width, height, wal.transform.localScale.z);
    }
    void creatSquare(float x, float y)
    {
        GameObject newObject = Instantiate(squa, new Vector3(x, y, 0), transform.rotation);
        newObject.transform.parent = _obj.transform;
    }
    void creatX3()
    {
        GameObject newObject = Instantiate(x3, new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(2.8f, 3.5f), 0), transform.rotation);
        newObject.transform.parent = _obj.transform;
    }
    void creatC3()
    {
        GameObject newObject = Instantiate(c3, new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(2.8f, 3.5f), 0), transform.rotation);
        newObject.transform.parent = _obj.transform;
    }
    public void x3ball()
    {
        balls = FindObjectsOfType<Ball>();
        if (balls.Length<100)
            foreach (Ball ball in balls)
            {
                if (ball)
                {
                    float f = -0.02f;
                    float d = Mathf.Sqrt(((ball.velocity.x + f) * (ball.velocity.x + f) + ball.velocity.y * ball.velocity.y) / (ball.velocity.x * ball.velocity.x + ball.velocity.y * ball.velocity.y));
                    float nX = (ball.velocity.x + f) / d;
                    float nY = ball.velocity.y / d;
                    GameObject newObject = Instantiate(bal, ball.transform.position, ball.transform.rotation);
                    newObject.transform.parent = _obj.transform;
                    newObject.GetComponent<Ball>().velocity.x = nX;
                    newObject.GetComponent<Ball>().velocity.y = nY;
                    newObject.GetComponent<Ball>().isCreat = true;
                    f = 0.02f;
                    d = Mathf.Sqrt(((ball.velocity.x + f) * (ball.velocity.x + f) + ball.velocity.y * ball.velocity.y) / (ball.velocity.x * ball.velocity.x + ball.velocity.y * ball.velocity.y));
                    nX = (ball.velocity.x + f) / d;
                    nY = ball.velocity.y / d;
                    newObject = Instantiate(bal, ball.transform.position, ball.transform.rotation);
                    newObject.transform.parent = _obj.transform;
                    newObject.GetComponent<Ball>().velocity.x = nX;
                    newObject.GetComponent<Ball>().velocity.y = nY;
                    newObject.GetComponent<Ball>().isCreat = true;
                }
            }
    }
    public void c3ball()
    {
        cr = FindObjectOfType<Crossbar>();
        float x = cr.getX();

        GameObject newObject = Instantiate(bal, new Vector3(x, -3.92f, 0), Quaternion.identity);
        newObject.transform.parent = _obj.transform;
        newObject.GetComponent<Ball>().velocity = new Vector2(0, Mathf.Sqrt(speed * speed * 2));
        newObject.GetComponent<Ball>().isCreat = true;

        newObject = Instantiate(bal, new Vector3(x - 0.25f, -3.92f, 0), Quaternion.identity);
        newObject.transform.parent = _obj.transform;
        newObject.GetComponent<Ball>().velocity = new Vector2(-speed, speed);
        newObject.GetComponent<Ball>().isCreat = true;

        newObject = Instantiate(bal, new Vector3(x + 0.25f, -3.92f, 0), Quaternion.identity);
        newObject.transform.parent = _obj.transform;
        newObject.GetComponent<Ball>().velocity = new Vector2(speed, speed);
        newObject.GetComponent<Ball>().isCreat = true;
    }
}

