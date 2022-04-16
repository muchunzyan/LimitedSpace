using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    private void Update()
    {
        var xInput = Input.GetAxis("Horizontal");
        
        transform.Rotate(0, xInput * rotationSpeed, 0);
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            GameObject.Find("Scripts").GetComponent<GameManager>().PlayerDeath();
        }
    }
}
