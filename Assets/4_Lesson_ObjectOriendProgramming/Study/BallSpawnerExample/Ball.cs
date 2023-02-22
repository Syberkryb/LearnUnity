using UnityEngine;

//Ball class is responsible for changing color and applying force to the ball
public class Ball : MonoBehaviour
{
    //Change the color of the ball to a random color
    public void RandomColor()
    {
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
            );
        GetComponent<Renderer>().material.color = randomColor;
    }

    //Add force to the ball in a random direction
    public void Kick(float force)
    {
        Vector3 ForceDirection = new Vector3(
            Random.Range(-2.5f, 2.5f),
            Random.Range(1f, 5f),
            Random.Range(-2.5f, 2.5f)
            );
        GetComponent<Rigidbody>().AddForce(ForceDirection * force, ForceMode.Impulse);
    }

    //Add force to the ball in the up direction
    public void Floaty(float force)
    {
        Vector3 ForceDirection = new Vector3(0f, 1f, 0f);
        GetComponent<Rigidbody>().AddForce(ForceDirection * force);
    }
}
