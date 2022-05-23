using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    private Vector3 newPosition;
    private Camera cam;

    public float smoothSpeed = 1f;

    public Button leftButton;
    public Button rightButton;

    int position = 1;

    void Start()
    {
        cam = GetComponent<Camera>();
        newPosition = transform.position;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instnance already exists, destryoing object!");
            Destroy(this);
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        switch(position)
        {
            case 0:
                leftButton.interactable = false;
                break;
            case 1:
                leftButton.interactable = true;
                rightButton.interactable = true;
                break;
            case 2:
                rightButton.interactable = false;
                break;
        }
    }

    public void Left()
    {
        if(position == 2)
            newPosition = new Vector3(0, 0, -10);
        else
            newPosition = new Vector3(-25, 0, -10);
        position--;
    }
    
    public void Right()
    {
        if (position == 0)
            newPosition = new Vector3(0, 0, -10);
        else
            newPosition = new Vector3(25, 0, -10);
        position++;
    }
}
