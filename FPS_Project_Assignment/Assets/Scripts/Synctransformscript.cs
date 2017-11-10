using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkIdentity))]
public class Synctransformscript : NetworkBehaviour
{
    // Speed of lerping rotation & position
    public float lerpRate = 15;

    // Vars to be synced across the network
    [SyncVar] private Vector3 syncPosition;
    [SyncVar] private Quaternion syncRotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        SendPosition();
        LerpPosition();
        //SendRotation();
        //LerpRotation();
    }

    void LerpPosition()
    {
        if (localPlayerAuthority ? !isLocalPlayer : !isServer)
        {
            // Lerp position of all other connected clients
            transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime * lerpRate);
        }
    }
    /*
    void LerpRotation()
    {
        if (localPlayerAuthority ? !isLocalPlayer : !isServer)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, syncRotation, Time.deltaTime * lerpRate);
        }
    }
        [Command]
    void Cmd_SendRotationToServer(Quaternion rotation)
    {
        syncRotation = rotation;
    }
       [ClientCallback]
    void SendRotation()
    {
        if (localPlayerAuthority ? isLocalPlayer : isServer)
        {
            Cmd_SendRotationToServer(transform.rotation);
        }
    }
    */

    [Command]
    void Cmd_SendPositionToServer(Vector3 position)
    {
        syncPosition = position;
    }

    [ClientCallback]
    void SendPosition()
    {
        if (localPlayerAuthority ? isLocalPlayer : isServer)
        {
            Cmd_SendPositionToServer(transform.position);
        }
    }

}