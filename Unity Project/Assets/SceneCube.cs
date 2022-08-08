using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCube : MonoBehaviour
{
    public GameObject currentGameObject;
    private ArrayList smallObjects = new ArrayList(); // arraylist to store spawning objects
    private ArrayList motionVectors = new ArrayList();// arraylist to store the motion vectors of the spawning objects

    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
        currentGameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.5f); // give random color to the cube and set alpha channel to 0.5

    }

    // Update is called once per frame
    void Update()
    {
        currentGameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse"); //use transparent/diffuse shader to make the cube transparent
        int type = Random.Range(0, 3);
        int counter = 0;
        if(Input.GetKeyDown(KeyCode.Space)) // create objects when space is pressed
        {
            if(type == 0)
            {
                GameObject smallSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); // create sphere
                int radius = Random.Range(1, 11);
                Vector3 movement = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f)); // get random motion vector
                smallSphere.transform.position = new Vector3(0, 0, 0); // set their initial position to (0,0,0)
                smallSphere.transform.localScale = new Vector3(radius, radius, radius);// scale it 
                smallSphere.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)); //give them random color
                smallSphere.GetComponent<Collider>().enabled = true; // enable collider
                smallSphere.AddComponent<Rigidbody>();// add rigidbody
                smallSphere.GetComponent<Rigidbody>().useGravity = false; // disable gravity
                smallSphere.GetComponent<Rigidbody>().mass = 0.5f; // set mass to 0.5
                smallObjects.Add(smallSphere); // add the object to the arraylist
                motionVectors.Add(movement);// add the motion vector to the arraylist
            }else if(type == 1)
            {
                GameObject smallCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                int radius = Random.Range(1, 11);
                Vector3 movement = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f));
                smallCube.transform.position = new Vector3(0, 0, 0);
                smallCube.transform.localScale = new Vector3(radius, radius, radius);
                smallCube.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                smallCube.GetComponent<Collider>().enabled = true;
                smallCube.AddComponent<Rigidbody>();
                smallCube.GetComponent<Rigidbody>().useGravity = false;
                smallCube.GetComponent<Rigidbody>().mass = 0.5f;
                smallObjects.Add(smallCube);
                motionVectors.Add(movement);
            }else if(type == 2)
            {
                GameObject smallCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                int radius = Random.Range(1, 11);
                Vector3 movement = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f));
                smallCylinder.transform.position = new Vector3(0, 0, 0);
                smallCylinder.transform.localScale = new Vector3(radius, radius, radius);
                smallCylinder.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                smallCylinder.GetComponent<Collider>().enabled = true;
                smallCylinder.AddComponent<Rigidbody>();
                smallCylinder.GetComponent<Rigidbody>().useGravity = false;
                smallCylinder.GetComponent<Rigidbody>().mass = 0.5f;
                smallObjects.Add(smallCylinder);
                motionVectors.Add(movement);
            }
        }
        foreach(GameObject obj in smallObjects) // update the objects position
        {
            for(int i = 0;i<motionVectors.Count;i++)
            {
                if(counter == i)
                {
                    Vector3 position = obj.transform.position; // get the current position
                    Vector3 motion = (Vector3)motionVectors[i]; // get the motion vector
                    position.x += motion.x; // add the motion vector to the current position
                    position.y += motion.y;
                    position.z += motion.z;
                    obj.transform.position = position;
                    counter++;
                    break;
                }

            }
        }
    }
}
