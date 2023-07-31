using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    GameController gameController;
    public int infor;
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
        
    }
    // từ 1->n: lever
    // 0: start     -1: continue    -2: try     -3: back    -4: main    -5: play    -6: pause   -7: increaseSpeed   -8: decreaseSpeed
    // -9: setting      -10: on music   -11: off music  -12: on sound   -13: off sound
    void OnMouseDown()
    {
        if (gameController.isSound)
            aus.PlayOneShot(sound);
        if (infor>0)
            gameController.setLever(infor);
        else if (infor == 0)
            gameController.setStart();
        else if (infor == -1)
            gameController.chooseContinue();
        else if (infor == -2)
            gameController.playAgain();
        else if (infor == -3)
            gameController.setBackAgain();
        else if (infor == -4)
            gameController.setScene();
        else if (infor == -5)
            gameController.setStatus(false);
        else if (infor == -6)
            gameController.setStatus(true);
        else if (infor == -7)
            gameController.increaseSpeed(0.005f);
        else if (infor == -8)
            gameController.increaseSpeed(-0.005f);
        else if (infor==-9)
            gameController.getSetting();
        else if (infor == -10)
            gameController.setMusic(false);
        else if (infor == -11)
            gameController.setMusic(true);
        else if (infor == -12)
            gameController.setSound(false);
        else if (infor == -13)
            gameController.setSound(true);
    }
}
