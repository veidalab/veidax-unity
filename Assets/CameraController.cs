using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public void Move(string direction)
    {
            if (direction == "Forward")
                transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
            else if (direction == "Backward")
                transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
            else if (direction == "Right")
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
            else if (direction == "Left")
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
            else if (direction == "Up")
                transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            else if (direction == "Down")
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            else if (direction == "Forward and Right")
                transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime);
            else if (direction == "Forward and Left")
                transform.Translate(new Vector3(-1, 0, 1) * Time.deltaTime);
            else if (direction == "Backward and Right")
                transform.Translate(new Vector3(1, 0, -1) * Time.deltaTime);
            else if (direction == "Backward and Left")
                transform.Translate(new Vector3(-1, 0, -1) * Time.deltaTime);
            else if (direction == "Forward and Up")
                transform.Translate(new Vector3(0, 1, 1) * Time.deltaTime);
            else if (direction == "Forward and Down")
                transform.Translate(new Vector3(0, -1, 1) * Time.deltaTime);
            else if (direction == "Backward and Up")
                transform.Translate(new Vector3(0, 1, -1) * Time.deltaTime);
            else if (direction == "Backward and Down")
                transform.Translate(new Vector3(0, -1, -1) * Time.deltaTime);
            else if (direction == "Right and Up")
                transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime);
            else if (direction == "Right and Down")
                transform.Translate(new Vector3(1, -1, 0) * Time.deltaTime);
            else if (direction == "Left and Up")
                transform.Translate(new Vector3(-1, 1, 0) * Time.deltaTime);
            else if (direction == "Left and Down")
                transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime);
            else if (direction == "Forward, Right, and Up")
                transform.Translate(new Vector3(1, 1, 1) * Time.deltaTime);
            else if (direction == "Forward, Right, and Down")
                transform.Translate(new Vector3(1, -1, 1) * Time.deltaTime);
            else if (direction == "Forward, Left, and Up")
                transform.Translate(new Vector3(-1, 1, 1) * Time.deltaTime);
            else if (direction == "Forward, Left, and Down")
                transform.Translate(new Vector3(-1, -1, 1) * Time.deltaTime);
            else if (direction == "Backward, Right, and Up")
                transform.Translate(new Vector3(1, 1, -1) * Time.deltaTime);
            else if (direction == "Backward, Right, and Down")
                transform.Translate(new Vector3(1, -1, -1) * Time.deltaTime);
            else if (direction == "Backward, Left, and Up")
                transform.Translate(new Vector3(-1, 1, -1) * Time.deltaTime);
            else if (direction == "Backward, Left, and Down")
                transform.Translate(new Vector3(-1, -1, -1) * Time.deltaTime);

        }

    }
