using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controller : MonoBehaviour
{
    public GameObject cross;
    public PlayerHealth playerHealth;
    public GameObject bullet;
    public AudioSource bulletVoice;
    private Vector3 mousePos;
    public float offSet;
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            transform.position.z
        ));

        cross.transform.position = new Vector3(
            mousePos.x,
            mousePos.y,
            transform.position.z
        );

        if(Input.GetMouseButtonDown(0)) {
            shot();
            bulletVoice.Play();
        }
        
    }

    void FixedUpdate()
    {
        float rotateZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offSet);
    }

    private void shot() {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
