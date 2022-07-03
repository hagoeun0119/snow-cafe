using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    bool isDraggable;
    bool isDragging;
    public Vector3 colliderPos;

    Collider2D objectCollider;


    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        // Collider의 초기 위치를 가져옴
        colliderPos = this.objectCollider.transform.position;
        isDraggable = false;
        isDragging = false;
    }


    void Update()
    {
        DragAndDrop();
    }

    void DragAndDrop()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (objectCollider == Physics2D.OverlapPoint(mousePosition))
            {
                isDraggable = true;
            }
            else
            {
                isDraggable = false;
            }

            if (isDraggable)
            {
                isDragging = true;
            }
        }
        if (isDragging)
        {
            this.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDraggable = false;
            isDragging = false;
            transform.position = colliderPos;
        }
    }
}
