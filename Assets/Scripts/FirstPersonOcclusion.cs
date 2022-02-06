using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using FMOD.Studio;

public class FirstPersonOcclusion : MonoBehaviour
{
    [Header("FMOD Event")]
    [SerializeField]


    public EventReference EventReference;
    [Obsolete("Use the EventReference field instead")]
    private string SelectAudio = "";
    //copy of emitter
   

    private EventInstance Audio;
    private EventDescription AudioDes;
    private StudioListener Listener;
    private PLAYBACK_STATE pb;

    [Header("Occlusion Options")]
    [SerializeField]
    [Range(0f, 10f)]
    private float SoundOcclusionWidening = 0.5f;
    [SerializeField]
    [Range(0f, 10f)]
    private float PlayerOcclusionWidening = 0.8f;
    [SerializeField]
    private LayerMask OcclusionLayer;

    private bool AudioIsVirtual;
    private float MaxDistance;
    private float MinDistance;
    private float ListenerDistance;
    private float lineCastHitCount = 0f;
    private Color colour;

    

    protected FMOD.Studio.EventInstance instance;

 

    private void Start()
    {
        SelectAudio = EventReference.Path;
        
        Audio = RuntimeManager.CreateInstance(SelectAudio);
        RuntimeManager.AttachInstanceToGameObject(Audio, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Audio.start();
        
        
        
        Audio.release();

        AudioDes = RuntimeManager.GetEventDescription(SelectAudio);
        AudioDes.getMinMaxDistance(out MinDistance, out MaxDistance);

        Listener = FindObjectOfType<StudioListener>();
    }

    private void FixedUpdate()
    {
        Audio.isVirtual(out AudioIsVirtual);
        Audio.getPlaybackState(out pb);
        ListenerDistance = Vector3.Distance(transform.position, Listener.transform.position);

        if (!AudioIsVirtual && pb == PLAYBACK_STATE.PLAYING && ListenerDistance <= MaxDistance)
            OccludeBetween(transform.position, Listener.transform.position);

        lineCastHitCount = 0f;
    }

    private void OccludeBetween(Vector3 sound, Vector3 listener)
    {
        Vector3 SoundLeft = CalculatePoint(sound, listener, SoundOcclusionWidening, true);
        Vector3 SoundRight = CalculatePoint(sound, listener, SoundOcclusionWidening, false);

        Vector3 SoundAbove = new Vector3(sound.x, sound.y + SoundOcclusionWidening, sound.z);
        Vector3 SoundBelow = new Vector3(sound.x, sound.y - SoundOcclusionWidening, sound.z);

        Vector3 ListenerLeft = CalculatePoint(listener, sound, PlayerOcclusionWidening, true);
        Vector3 ListenerRight = CalculatePoint(listener, sound, PlayerOcclusionWidening, false);

        Vector3 ListenerAbove = new Vector3(listener.x, listener.y + PlayerOcclusionWidening * 0.5f, listener.z);
        Vector3 ListenerBelow = new Vector3(listener.x, listener.y - PlayerOcclusionWidening * 0.5f, listener.z);

        CastLine(SoundLeft, ListenerLeft, false);
        CastLine(SoundLeft, listener, false);
        CastLine(SoundLeft, ListenerRight, false);

        CastLine(sound, ListenerLeft, true);
        CastLine(sound, listener, true);
        CastLine(sound, ListenerRight, true);

        CastLine(SoundRight, ListenerLeft, false);
        CastLine(SoundRight, listener, false);
        CastLine(SoundRight, ListenerRight, false);

        CastLine(SoundAbove, ListenerAbove, true);
        CastLine(SoundBelow, ListenerBelow, true);

        if (PlayerOcclusionWidening == 0f || SoundOcclusionWidening == 0f)
        {
            colour = Color.blue;
        }
        else
        {
            colour = Color.green;
        }

        SetParameter();
    }

    private Vector3 CalculatePoint(Vector3 a, Vector3 b, float m, bool posOrneg)
    {
        float x;
        float z;
        float n = Vector3.Distance(new Vector3(a.x, 0f, a.z), new Vector3(b.x, 0f, b.z));
        float mn = (m / n);
        if (posOrneg)
        {
            x = a.x + (mn * (a.z - b.z));
            z = a.z - (mn * (a.x - b.x));
        }
        else
        {
            x = a.x - (mn * (a.z - b.z));
            z = a.z + (mn * (a.x - b.x));
        }
        return new Vector3(x, a.y, z);
    }

    private void CastLine(Vector3 Start, Vector3 End, bool center)
    {
        RaycastHit hit;
        Physics.Linecast(Start, End, out hit, OcclusionLayer);

        if (hit.collider)
        {
            
            Debug.DrawLine(Start, End, Color.red);
            if (center == true)
            {
                lineCastHitCount++;
            }
            else lineCastHitCount = lineCastHitCount + 1.6f;
        }
        else
        {
            if (center == true)
            {
                lineCastHitCount = lineCastHitCount - 1.2f;
            }
            else lineCastHitCount = lineCastHitCount - 2f;
            Debug.DrawLine(Start, End, colour);
        }
            
    }
    private void SetParameter()
    {
        Debug.Log("hitocclusion = " + lineCastHitCount);
        if (lineCastHitCount <= 0) lineCastHitCount = 0;
        Audio.setParameterByName("Occlusion", lineCastHitCount / 12);

    }

    private void OnDestroy()
    {
        Audio.stop(true ? FMOD.Studio.STOP_MODE.ALLOWFADEOUT : FMOD.Studio.STOP_MODE.IMMEDIATE);
        Audio.release();
    }

}