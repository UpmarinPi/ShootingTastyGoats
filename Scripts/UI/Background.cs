using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int delPos;
    [SerializeField] int resPos;
    int y;
    // Start is called before the first frame update
    void Start()
    {
        y = (int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(delPos >= y)
        {
            y = resPos;
        }
        y -= speed;
    }
	private void FixedUpdate()
	{
        transform.position = new Vector2(0, y);
	}
}
