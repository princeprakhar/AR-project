using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flatStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Add screen boundary variables
    public float topBoundary = 15f;  // Adjust based on your game
    public float bottomBoundary = -15f; // Adjust based on your game
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();



        // Calculate screen boundaries in world coordinates
        if (mainCamera != null)
        {
            float verticalSize = mainCamera.orthographicSize; // Half height of the camera view
            topBoundary = verticalSize - 0.5f; // Subtract bird's approximate radius
            bottomBoundary = -verticalSize + 0.5f; // Add bird's approximate radius

            Debug.Log($"Screen boundaries set: Top = {topBoundary}, Bottom = {bottomBoundary}");
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flatStrength;
        }


        if (transform.position.y > topBoundary || transform.position.y < bottomBoundary)
        {
            if (birdIsAlive)
            {
                logic.gameOver();
                birdIsAlive = false;
                Debug.Log("Bird flew out of bounds - Game Over!");
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
