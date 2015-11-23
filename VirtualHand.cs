using UnityEngine;
using System.Collections;
// This class provides a simple virtual hand technique
// Directions:
// 		1. Attach to the GameObject that will be used for collision detection
//		2. Ensure that GameObject is encapsulated in an empty GameObject with a clean transform
//		3. Change WiimoteName to the name of the Wiimote that will be used for input
public class VirtualHand : MonoBehaviour {
	
	public string WiimoteName;
	
	private GameObject collidedObject = null;
	private GameObject grabbedObject = null;
	private Transform rootObject = null;
	private Vector3 grabbedPosition;
	private Quaternion grabbedRotation;
	
	private GameObject rayGrabbedObject = null;
	private Transform rayRootObject = null;
	private Vector3 rayGrabbedPosition;
	private Quaternion rayGrabbedRotation;
	private float threshold = 0.6096f;
	
	
	// Use this for initialization
	void Start () {
		
		// We assume the attached GameObject has a collider so ensure the collider is trigger-based
		collider.isTrigger = true;
		// Turn off the object's physics by making it kinematic
		rigidbody.isKinematic = true;
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		//Detect whether we have passed threshold
		//Game object is global class find returns the 
		//returning reference to game object
		GameObject hmdObject = GameObject.Find("HMD");
		
		//get the transform
		//get the position of the tracker position global localposition relative to parent
		Vector3 hmdPosition = hmdObject.transform.position;
		GameObject handObject = GameObject.Find(WiimoteName);
		
		//to check outside threshold wii remote position
		//check unity get the transform lower case
		Vector3 handPosition = handObject.transform.position;
		
		Vector3 handheadDiff = new Vector3 (0.0f, 0.0f, 0.0f);
		handheadDiff.x = handPosition.x - hmdPosition.x;
		handheadDiff.z = handPosition.z - hmdPosition.z;
		
		
		
		if (handheadDiff.magnitude > threshold) 
		{	
			Debug.Log ("Ray Cast");
			Debug.Log (handheadDiff.magnitude);
			print ("Ray Cast");
			print (handheadDiff.magnitude);
			HandRayCast();
			
		}
		else
		{
			Debug.Log ("virtual hand");
			Debug.Log (handheadDiff.magnitude);
			
			print ("virtual hand");
			print (handheadDiff.magnitude);
			Hand();
			
		}
	}
	
	// Trigger function for collisions
	void OnTriggerEnter(Collider other) {
		// If an object is not already grabbed, check for collisions with another
		if(grabbedObject == null) {
			collidedObject = other.gameObject;
		}
	}
	
	// Trigger function for exiting collisions
	void OnTriggerExit(Collider other) {
		// If an object is not grabbed, forget the collided object
		if(grabbedObject == null) {
			collidedObject = null;
		}
	}
	
	void Hand(){
		
		if(rayGrabbedObject !=null){
			
			// If A and B are NOT pressed, turn the object's physics back on and release it
			if(!InputBroker.GetKeyDown(WiimoteName + ":A") || 
			   !InputBroker.GetKeyDown(WiimoteName + ":B")) {
				//rayGrabbedObject.rigidbody.isKinematic = false;
				rayRootObject.parent = null;
				rayGrabbedObject = null;
			}
		}
		
		
		// Check if no object is being collided and if no object is grabbed
		if(collidedObject == null && grabbedObject == null) {
			// If A and B are pressed, treat the virtual hand as a fist by turning off the collider's trigger
			if(InputBroker.GetKeyDown(WiimoteName + ":A") && 
			   InputBroker.GetKeyDown(WiimoteName + ":B")) {
				collider.isTrigger = false;
			}
			// Otherwise, ensure the collider is treated as a trigger
			else {
				collider.isTrigger = true;
			}
		}
		
		// Check if an object is being collided (but no object is grabbed yet)
		else if(collidedObject != null && grabbedObject == null) {
			// If A and B are pressed, grab the object, turn off its physics, and add it to the virtual hand's empty parent
			if(InputBroker.GetKeyDown(WiimoteName + ":A") && 
			   InputBroker.GetKeyDown(WiimoteName + ":B")) {
				
				// Turn off physics by turning on kinematics
				grabbedObject = collidedObject;
				grabbedObject.rigidbody.isKinematic = true;
				
				// Find the root of the grabbed object (for hierarchical objects)
				rootObject = grabbedObject.transform;
				while(rootObject.transform.parent != null) {
					rootObject = rootObject.transform.parent;
				}
				
				// Move the root of the grabbed object under the virtual hand's parent
				rootObject.parent = transform.parent;
				
				// Determine the root's initial position and rotation relative to the virtual hand's parent				
				grabbedPosition = rootObject.localPosition;
				grabbedRotation = rootObject.localRotation;
			}
		}
		
		// Check if an object is grabbed
		else if(grabbedObject != null) {
			// Update the root's position and rotation relative to the virtual hand's parent
			rootObject.localPosition = grabbedPosition;
			rootObject.localRotation = grabbedRotation;
			
			// If A and B are NOT pressed, turn the object's physics back on and release it
			if(!InputBroker.GetKeyDown(WiimoteName + ":A") 
			   || !InputBroker.GetKeyDown(WiimoteName + ":B")) {
				grabbedObject.rigidbody.isKinematic = false;
				rootObject.parent = null;
				grabbedObject = null;
			}
		}
		
	}
	
	
	void HandRayCast(){
		
		
		if (grabbedObject != null) {
			
			// If A and B are NOT pressed, turn the object's physics back on and release it
			if (!InputBroker.GetKeyDown (WiimoteName + ":A") 
			    || !InputBroker.GetKeyDown (WiimoteName + ":B")) {
				//grabbedObject.rigidbody.isKinematic = false;
				rootObject.parent = null;
				grabbedObject = null;
			}
		}
		
		RaycastHit hit;
		
		Ray landingRay = new Ray(transform.position,transform.forward);
		if(Physics.Raycast(landingRay,out hit)){
			Debug.DrawRay (transform.position, transform.forward,Color.black);
			
			
			if(rayGrabbedObject == null){
				
				if(InputBroker.GetKeyDown(WiimoteName + ":A") && 
				   InputBroker.GetKeyDown(WiimoteName + ":B")) {
					
					rayGrabbedObject = hit.transform.gameObject;
					rayGrabbedObject.rigidbody.isKinematic = true;
					
					rayRootObject = rayGrabbedObject.transform;
					while(rayRootObject.transform.parent != null) {
						rayRootObject = rayRootObject.transform.parent;
					}
					
					// Move the root of the grabbed object under the virtual hand's parent
					rayRootObject.parent = transform.parent;
					
					// Determine the root's initial position and rotation relative to the virtual hand's parent				
					rayGrabbedPosition = rayRootObject.localPosition;
					rayGrabbedRotation = rayRootObject.localRotation;
					
					
					// Update the root's position and rotation relative to the virtual hand's parent
					rayRootObject.localPosition = rayGrabbedPosition;
					rayRootObject.localRotation = rayGrabbedRotation;
					
				}				
			}
			else{
				
				// Update the root's position and rotation relative to the virtual hand's parent
				rayRootObject.localPosition = rayGrabbedPosition;
				rayRootObject.localRotation = rayGrabbedRotation;
				
				// If A and B are NOT pressed, turn the object's physics back on and release it
				if(!InputBroker.GetKeyDown(WiimoteName + ":A") || 
				   !InputBroker.GetKeyDown(WiimoteName + ":B")) {
					rayGrabbedObject.rigidbody.isKinematic = false;
					rayRootObject.parent = null;
					rayGrabbedObject = null;
				}					
			}			
		}
	}
	
}

