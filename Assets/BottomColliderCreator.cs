using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomColliderCreator : MonoBehaviour
{
    GameObject bottom;

    void Awake()
    {

        bottom = new GameObject("Bottom");
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
        BoxCollider2D bottomCollider = bottom.AddComponent<BoxCollider2D>();
        bottomCollider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        bottomCollider.offset = new Vector2(bottomCollider.size.x / 2f, bottomCollider.size.y / 2f);


        float bottomColliderY = (bottomLeftScreenPoint.y - bottomCollider.size.y) - 1f; //-1.5fmake it a little bit below the screen
        float bottomColliderX = (bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f;


        //** Bottom needs to account for collider size
        bottom.transform.position = new Vector3(bottomColliderX, bottomColliderY, 0f);

        bottom.AddComponent<DestroyWord>();


        Debug.Log(bottomColliderY);
    }


    //-6.5f
}
