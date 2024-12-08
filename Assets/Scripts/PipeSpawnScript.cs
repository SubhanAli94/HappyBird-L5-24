using System.Threading;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipePrefab; //Pipe Prefab
    public static int interval = 2; //Inerval is used for timer 
    private static float timer = 2; //Timer is used to keep track of last spawn time
    private int heightOffset = 4; //It is used to create variance of y-axis value from center.
    private float lowestPoint = 0; //Lowest point on y-axis for spawn
    private float highestPoint = 0; //Highest point on y-axis for spawn


    private void Awake()
    {
        /*
         * Lowest and Highest points along y-axis are used to
         * create a random position to spawn a pipe.
         */
        lowestPoint = transform.position.y - heightOffset; //Lowest point
        highestPoint = transform.position.y + heightOffset; //Highest Point
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsGameOver()) { //Check if the Game is Over or not.

            //Check if the timer has reached the 
            if (timer < interval)
            {
                timer += Time.deltaTime; //Increase the timer value.
            }
            else
            {
                SpawnPipe(); //Otherwise, spawn a pipe.
                timer = 0; //Reset the timer.
            }
        }
    }

    //This function helps to spawn Pipes at random vertical positions.
    private void SpawnPipe()
    {
        //Instantiate the Pipe Prefab at random position along y-axis.
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    /* Function: Reset the timer.
     * We call this function when the game starts to
     * imemdiately start spawning the Pipes.
     */
    public static void ResetSpawnTimer() {
        timer = interval;
    }
}
