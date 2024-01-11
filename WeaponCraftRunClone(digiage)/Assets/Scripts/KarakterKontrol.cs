using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    [SerializeField] private float BaslangicHizi = 5.0f;
    [SerializeField] private float HizArtimi = 1.0f;

    private float amountToIncrease = 0.02f;
    private int counter = 0;
    private float secondsToIncreaseSpeed = 10.0f;
    private Rigidbody rb;
    private Vector3 HorizontalMovementVector = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HorizontalMovementControl();
        ForwardForce();
    }

    void HorizontalMovementControl()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        HorizontalMovementVector = new Vector3(HorizontalMovement * BaslangicHizi * Time.deltaTime, 0.0f, 0.0f);

        transform.position += HorizontalMovementVector;
    }

    void ForwardForce()
    {
        transform.position += Vector3.forward * HizArtimi * Time.deltaTime;

        if (counter < secondsToIncreaseSpeed)
        {
            counter++;
        }

        else
        {
            counter = 0;
            HizArtimi += amountToIncrease;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bitis"))
        {
            HizArtimi = 0f;
            amountToIncrease = 0f;
        }
    }
}
