using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public int indexColumn;
    public float moveSpeed;
    public float minY;
    public float maxY;
    private float oldPosition;
    private GameObject obj;
    float currentX;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 5;
        moveSpeed = 10;
        minY = -1;
        maxY = 1;

    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
        currentX = transform.position.x;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Wall "+ oldPosition);
        if(other.gameObject.tag.Equals("ResetWall"))
        obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        else
        {
           
        }
    }
}
