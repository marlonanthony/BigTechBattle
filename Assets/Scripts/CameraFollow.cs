using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) return;
        tempPos = transform.position;
        float playerX = player.position.x;
        tempPos.x = Mathf.Min(Mathf.Max(playerX, minX), maxX);

        transform.position = tempPos;
    }
}
