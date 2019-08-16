using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    //Value variables
    public bool positionMove, translateMove, forceMove, velocityMove, cCMove;

    //Reference variables
    public Rigidbody rb;
    public CharacterController charC;
    public Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        if(cCMove)
        {
            //Add a CharacterController (of type CharacterController) to this game object, so the property exists
            //Assign charC as a reference to the CharacterController, for ease of use
            charC = this.gameObject.AddComponent(typeof(CharacterController))as CharacterController;
        }

        else if (forceMove || velocityMove)
        {
            //Add a Rigidbody (of type Rigidbody) to this game object, so the property exists
            //Assign rb as a reference to Rigidbody, for ease of use
            rb = this.gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))

            //On pressing W run the movement functions
        {
            TransformMovement();
            RigidbodyMovement();
            CharacterControllerMovement();
        }

        else if(Input.GetKey(KeyCode.S))

            //On pressing S run the move back functions
        {
            TransformMovementBack();
            RigidbodyMovementBack();
            CharacterControllerMovementBack();
        }

    }

    void TransformMovement()
    {
        //If position move is indicated add moveDir to position modified to allow for realtime
        if(positionMove)
        {
            this.transform.position += moveDir * Time.deltaTime;
        }

        //If translate move is indicated translate position by moveDir modified to allow for realtime
        else if (translateMove)
        {
            transform.Translate(moveDir * Time.deltaTime);
        }
    }

    void RigidbodyMovement()
    {
        if(forceMove)
        {
            rb.AddForce(moveDir);
        }

        else if(velocityMove)
        {
            rb.velocity = moveDir;
        }
    }

    void CharacterControllerMovement()
    {
        if(cCMove)
        {
            charC.Move(moveDir * Time.deltaTime);
        }
    }

    void TransformMovementBack()
    {
        //If position move is indicated subtract moveDir to position modified to allow for realtime
        if (positionMove)
        {
            this.transform.position -= moveDir * Time.deltaTime;
        }

        //If translate move is indicated translate position by -moveDir modified to allow for realtime
        else if (translateMove)
        {
            transform.Translate(-moveDir * Time.deltaTime);
        }
    }

    void RigidbodyMovementBack()
    {
        if (forceMove)
        {
            rb.AddForce(-moveDir);
        }

        else if (velocityMove)
        {
            rb.velocity = -moveDir;
        }
    }

    void CharacterControllerMovementBack()
    {
        if (cCMove)
        {
            charC.Move(-moveDir * Time.deltaTime);
        }
    }

}
