using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class BuildingPlacement : MonoBehaviour
{
    public float grid = 1;
    private float x = 0, y = 0;

    public GameObject building;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    private int collisions = 0;
    private bool canBeBuild = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        CanBeBuildCheck();
    }
    void Update()
    {
        // Mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    break;
                case TouchPhase.Moved:
                    mouseWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    float reciprocalGrid = 1f / grid;
                    x = Mathf.Round(mouseWorldPosition.x * reciprocalGrid) / reciprocalGrid;
                    y = Mathf.Round(mouseWorldPosition.y * reciprocalGrid) / reciprocalGrid;

                    transform.position = new Vector2(x, y);
                    break;
                case TouchPhase.Ended:
                    if(canBeBuild)
            {
                        GameObject.Find("GameManager").GetComponent<Stat>().money -= 100;
                        Instantiate(building, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }

        // Computer
        /*
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();

            float reciprocalGrid = 1f / grid;
            x = Mathf.Round(mouseWorldPosition.x * reciprocalGrid) / reciprocalGrid;
            y = Mathf.Round(mouseWorldPosition.y * reciprocalGrid) / reciprocalGrid;

            transform.position = new Vector2(x, y);
        }    
        if (Input.GetMouseButtonUp(0))
        {
            if (canBeBuild)
            {
                GameObject.Find("GameManager").GetComponent<Stat>().money -= 100;
                Instantiate(building, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        */
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collisions++;
        CanBeBuildCheck();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisions--;
        CanBeBuildCheck();
    }

    void CanBeBuildCheck()
    {
        if (collisions == 0)
        {
            canBeBuild = true;
            spriteRenderer.color = new Color(0f, 1f, 0f, 0.5f);
        }
        else
        {
            canBeBuild = false;
            spriteRenderer.color = new Color(1f, 0f, 0f, 0.5f);
        }
    }
}
