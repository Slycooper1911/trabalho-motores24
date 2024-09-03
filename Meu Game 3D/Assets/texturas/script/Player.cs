using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class Player : MonoBehaviour
{
    public int velocidade = 10;

    public Rigidbody rb;
    public float forcaPulo = 5;
    public bool noChao = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chão")
        {
            noChao = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)&& noChao == true)
        {
            
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
            
        }    
        UnityEngine.Vector3 direcao = new UnityEngine.Vector3(h, 0, v);
        rb.AddForce(direcao * (velocidade * Time.deltaTime), ForceMode.Impulse);
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}