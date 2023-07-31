using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbar : MonoBehaviour
{
    Vector3 offset;
    Vector3 toaDo, newPosition;
    float xChange;
    bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        toaDo = transform.position;
    }
    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    void OnMouseUp()
    {
        isDragging = false;
        xChange = 0;
    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset - toaDo;
            if (newPosition.x > 0)
                xChange = 1;
            else if (newPosition.x < 0)
                xChange = -1;
            else
                xChange = 0;
            float k = toaDo.x + newPosition.x;
            if (k < -1.81f)
                transform.position = new Vector3(-1.81f, -4.1f, 0);
            else if (k > 1.81f)
                transform.position = new Vector3(1.81f, -4.1f, 0);
            else
                transform.position = new Vector3(k, -4.1f, 0);
        }
    }
    public float getSpeed()
    {
        return xChange;
    }
    public float getX()
    {
        return transform.position.x;
    }
    public float getY()
    {
        return transform.position.y;
    }
}
