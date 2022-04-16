using UnityEngine;
using Random = UnityEngine.Random;

public class BonusMovement : MonoBehaviour
{
    public float moveSpeed;

    private void Start()
    {
        var rotationAngle = Random.Range(0, 360);
        transform.Rotate(0, rotationAngle, 0);
        
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Death"))
            {
                GameObject.Find("Scripts").GetComponent<GameManager>().PlayerDeath();
            }
            else
            {
                if (gameObject.CompareTag("Coin"))
                {
                    GameObject.Find("Scripts").GetComponent<GameManager>().IncreaseCoins();
                }
                
                Destroy(gameObject);
            }
        }
    }
}
