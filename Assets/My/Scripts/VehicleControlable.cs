using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleControlable : Controlable
{
    public Transform cameraArmSocket;
    public Transform characterSeat;
    public Transform cameraArm;

    public Transform carBody;

    public CharacterControlable driveCharacter;

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector2 input)
    {
        Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
        Vector3 moveDir = lookForward * input.y + lookRight * input.x;

        if(input.magnitude != 0)
        {
            carBody.forward = lookForward;
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
}
