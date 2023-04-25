using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlosinaBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;
    private Vector3 startPosition;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

        if (transform.position == endPosition)
        {
            Vector2 temp = endPosition;
            endPosition = startPosition;
            startPosition = temp;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
