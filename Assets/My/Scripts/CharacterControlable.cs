using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlable : Controlable
{
    public Transform charBody;
    public Transform cameraArmSocket;
    public Transform cameraArm;

    Animator animator;
    Rigidbody rigidbody;

    public float jumpForce = 5f;

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public override void Move(Vector2 input)
    {
        animator.SetFloat("MoveSpeed", input.magnitude);
        Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
        Vector3 moveDir = lookForward * input.y + lookRight * input.x;

        if(input.magnitude != 0)
        {
            charBody.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * 5f;
        }
    }

    public override void Rotate(Vector2 input)
    {
        if(cameraArm != null)
        {
            Vector3 camAngle = cameraArm.rotation.eulerAngles;
            float x = camAngle.x - input.y;

            if(x < 180f)
            {
                x = Mathf.Clamp(x, -1f, 70f);
            }
            else
            {
                x = Mathf.Clamp(x, 335f, 361f);
            }

            cameraArm.rotation = Quaternion.Euler(x, camAngle.y + input.x, camAngle.z);
        }
    }

    void Start()
    {
        animator = charBody.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
}
