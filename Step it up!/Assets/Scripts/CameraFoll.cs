using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFoll : MonoBehaviour {

    private Transform player;

    private float damping = 2f;
    private float height = 10f;

    private Vector3 startPos;

    private bool camFol;
    
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
        camFol = true;
    }

    void Update(){
        Follow();
    }

    void Follow() {
        if(camFol) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + 10f, player.transform.position.y + height, player.position.z - 10f), Time.deltaTime * damping);
        }
    }

    public bool CamFollow {
        get {
            return camFol;
        } set {
            camFol = value;
        }
    }
}