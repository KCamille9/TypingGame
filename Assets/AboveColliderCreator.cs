using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveColliderCreator : MonoBehaviour
{
    GameObject top;



    void Awake()
    {
        top = new GameObject("Top");
    }


    void Start()
    {
        CreateScreenColliders();

    }


    void CreateScreenColliders()
    {

        //VECTORS ARE LINES


        Vector3 bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));


        // Create bottom collider
        BoxCollider2D topCollider = top.AddComponent<BoxCollider2D>();
        topCollider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        topCollider.offset = new Vector2(topCollider.size.x / 2f, topCollider.size.y / 2f);

        top.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, topRightScreenPoint.y, 0f);

        top.AddComponent<SetWordOnScreen>();
    }

}