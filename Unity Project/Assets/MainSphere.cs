using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSphere : MonoBehaviour
{
    private GameObject currentGameObject;
    string m_path;
    bool textureEnabled = false;
    Texture tex;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        currentGameObject = gameObject;
        Material matTexture = new Material(Shader.Find("Standard")); // create material for texture
        m_path = Application.dataPath;// find the data path of the application
        string path = m_path + "/texture-sphere.jpg";// add the filename of the jpg file to be loaded as texture
        using(WWW www = new WWW(path)) // load image 
        {
            yield return www;
            matTexture.mainTexture = www.texture; // enter the image as main texture to the material
            tex = www.texture;// save texture for further use
        }
        currentGameObject.GetComponent<Renderer>().material = matTexture; // enter texture material to the sphere
    }

    // Update is called once per frame
    void Update()
    {
        Material matTexture = new Material(Shader.Find("Standard")); // create new material for texture
        matTexture.SetTexture("_MainTex", tex); // enter the texture to the material
        Material matColor = new Material(Shader.Find("Standard"));// create new material for color
        matColor.color = new Color(1.0f, 0.0f, 0.0f); // set color to red
        if (Input.GetKeyDown(KeyCode.T)) // if T is pressed
        {
            if (textureEnabled == true) // if texture is enabled set the color material to the game object 
            {
                textureEnabled = false;
                currentGameObject.GetComponent<Renderer>().material = matColor;
            }
            else if (textureEnabled == false) // if color is enabled set texture material to the game object
            {
                textureEnabled = true;
                currentGameObject.GetComponent<Renderer>().material = matTexture;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // if up arrow is pressed move upwards
        {
            Vector3 position = currentGameObject.transform.position;
            position.y+=2;
            currentGameObject.transform.position = position;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) // if down arrow is pressed move downwards
        {
            Vector3 position = currentGameObject.transform.position;
            position.y-=2;
            currentGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))// if right arrow is pressed move right
        {
            Vector3 position = currentGameObject.transform.position;
            position.x+=2;
            currentGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // if left arrow is pressed move left
        {
            Vector3 position = currentGameObject.transform.position;
            position.x-=2;
            currentGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.Equals)) // if equals is pressed move closer to the camera
        {
            Vector3 position = currentGameObject.transform.position;
            position.z+=2;
            currentGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) // if minus is pressed move farther from the camera
        {
            Vector3 position = currentGameObject.transform.position;
            position.z-=2;
            currentGameObject.transform.position = position;
        }
    }
}
