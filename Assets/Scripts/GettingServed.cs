using UnityEngine;

public class GettingServed : MonoBehaviour
{
    GameManagement gameManagement;
    private void Start()
    {
        gameManagement=FindFirstObjectByType<GameManagement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("customer"))
        {
            CustomerMovement customerMovement = other.GetComponent<CustomerMovement>();
            if(customerMovement != null && !gameManagement.isServingCustomer)
            {
                customerMovement.isServed = true;
                customerMovement.isMoving = false;
                gameManagement.isServingCustomer = true;
                gameManagement.dialogueServingCustomers.SetActive(true);
            }
        }
    }
}
