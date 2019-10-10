using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.PostProcessing;

public class JuiceWindow : EditorWindow
{
    // Shake
    // ParticlesHit
    // ParticlesTrail
    // ParticlesBackground
    // ParticlesDeath
    // PPPcolorGrading
    // PPPbloom
    // Music
    // Audio
    Bloom bloomLayer;
    ColorGrading gradingLayer;
    bool isActiveShake;
    bool isActiveHit;
    bool isActiveTrail;
    bool isActiveBackground;
    bool isActiveDeath;
    bool isActiveGrading;
    bool isActiveBloom;
    bool isActiveMusic;
    bool isActiveAudio;
    GameObject shake;
    GameObject hit;
    GameObject trail;
    GameObject background;
    GameObject death;
    GameObject grading;
    GameObject bloom;
    GameObject music;
    GameObject audio;

    [MenuItem("Window/Juice")]
    public static void ShowWindow()
    {
        GetWindow<JuiceWindow>();
    }

    void OnGUI()
    {                                                                              
        GUILayout.Space(10);
        GUILayout.Label("PARTICLES", EditorStyles.boldLabel);

        isActiveHit = EditorGUILayout.Toggle("Hit", isActiveHit);
        isActiveTrail = EditorGUILayout.Toggle("Trail", isActiveTrail);
        isActiveBackground = EditorGUILayout.Toggle("Background", isActiveBackground);
        isActiveDeath = EditorGUILayout.Toggle("Death", isActiveDeath);

        GUILayout.Space(10);
        GUILayout.Label("MUSIC", EditorStyles.boldLabel);

        isActiveMusic = EditorGUILayout.Toggle("Music", isActiveMusic);
        isActiveAudio = EditorGUILayout.Toggle("Audio", isActiveAudio);

        GUILayout.Space(10);
        GUILayout.Label("OTHER", EditorStyles.boldLabel);
        
        isActiveShake = EditorGUILayout.Toggle("Shake", isActiveShake);
        isActiveGrading = EditorGUILayout.Toggle("Grading", isActiveGrading);
        isActiveBloom = EditorGUILayout.Toggle("Bloom", isActiveBloom);
                                                                   
        object[] obj = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach(object o in obj)
        {
            GameObject g = (GameObject)o;  
            if(g.name == "HitParticles")
                g.SetActive(isActiveHit);  
            if(g.name == "TailParticles")
                g.SetActive(isActiveTrail);
            if(g.name == "BackgroundParticles")
                g.SetActive(isActiveBackground);
            if(g.name == "AudioManager")
                g.SetActive(isActiveAudio);
            if(g.name == "MusicManager")
                g.SetActive(isActiveMusic);
            if(g.name == "Post-process Volume")
            {
                PostProcessVolume ppv = g.GetComponent<PostProcessVolume>();
                ppv.profile.TryGetSettings(out bloomLayer);
                ppv.profile.TryGetSettings(out gradingLayer);

                bloomLayer.active = isActiveBloom;
                gradingLayer.active = isActiveGrading;
            }
            if(g.name == "Main Camera")
            {
                g.GetComponent<CameraShake>().enabled = isActiveShake;
                Debug.Log(g.GetComponent<CameraShake>().enabled);
            }
            if(g.name == "DeathParticle")
            {
                g.SetActive(isActiveDeath);
            }

        }                                    
    }
}
