using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Lander : MonoBehaviour
{
    [SerializeField]
    float velocidade = 150f;

    [SerializeField]
    float combustivel = 500f;

    [SerializeField]
    float torque = 10f;

    float ang = 10f;

    [SerializeField]
    TextMeshProUGUI fueltxt;

    float maxrel = 2f;


    void Update()
    {
        if(combustivel > 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent <Rigidbody2D>().AddForce(transform.up * velocidade * Time.deltaTime);
                combustivel -= 10f * Time.deltaTime;
            }
           if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque (Time.deltaTime * torque);
                combustivel -= 5f * Time.deltaTime;
            }
           if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>(). AddTorque(-Time.deltaTime * torque);
                combustivel -= 5f * Time.deltaTime;
            }
        }
          fueltxt.text = "Combustivel = " + System.Convert.ToInt32(combustivel). ToString();

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Base" && Mathf.Abs(transform. localEulerAngles.z)<= ang && collision.relativeVelocity.magnitude > maxrel) 
        {
            
            Debug.Log (transform.localEulerAngles.z);

            Debug.Log ("Aterrei..");
        }
         else
        {
            Debug.Log(transform.localEulerAngles.z);

            Debug.Log("Rebentei!!");
        }
    }
}
