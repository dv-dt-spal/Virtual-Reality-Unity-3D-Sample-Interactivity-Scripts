using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AmbiDextrousArm : MonoBehaviour {
	
	
	//Structure to store the sub-arm movements
	public struct ArmstoMove
	{
		public bool bArm1;
		public bool bArm2;
		public bool bArm3;
		public bool bArm4;
		public bool bArm5;
		public bool bArm6;
		public bool bArm7;
		public bool bArm8;
		
		public bool bRestrictedArm1;
		public bool bRestrictedArm2;
		public bool bRestrictedArm3;
		public bool bRestrictedArm4;
		public bool bRestrictedArm5;
		public bool bRestrictedArm6;
		public bool bRestrictedArm7;
		public bool bRestrictedArm8;
	}
	
	//Enum for the arm grabbing and movement
	enum eArmDirection{
		eDefault,
		eArm1MovingX,
		eArm1MovingY,
		eArm1MovingZ,
		eArm1MovingXY,
		eArm1MovingYZ,
		eArm1MovingZX,
		
		eArm2MovingX,
		eArm2MovingY,
		eArm2MovingZ,
		eArm2MovingXY,
		eArm2MovingYZ,
		eArm2MovingZX,
		
		eArm3MovingX,
		eArm3MovingY,
		eArm3MovingZ,
		eArm3MovingXY,
		eArm3MovingYZ,
		eArm3MovingZX,
		
		eArm4MovingX,
		eArm4MovingY,
		eArm4MovingZ,
		eArm4MovingXY,
		eArm4MovingYZ,
		eArm4MovingZX,
		
		eArm5MovingX,
		eArm5MovingY,
		eArm5MovingZ,
		eArm5MovingXY,
		eArm5MovingYZ,
		eArm5MovingZX,
		
		eArm6MovingX,
		eArm6MovingY,
		eArm6MovingZ,
		eArm6MovingXY,
		eArm6MovingYZ,
		eArm6MovingZX,
		
		eArm7MovingX,
		eArm7MovingY,
		eArm7MovingZ,
		eArm7MovingXY,
		eArm7MovingYZ,
		eArm7MovingZX,
		
		eArm8MovingX,
		eArm8MovingY,
		eArm8MovingZ,
		eArm8MovingXY,
		eArm8MovingYZ,
		eArm8MovingZX,
		
	}
	
	//Dictionary for mapping the direction and the sub-arm movement details
	Dictionary<eArmDirection,ArmstoMove> mapArmMovement;
	
	//Use this instead of constructor
	void Awake(){
		print("Awake");
		//Initialize the list of GameObjects of parent and child
		lstGameObjectsParents = new List<GameObject> ();
		
		
		//Initialize the list of GameObjects of parent and child
		lstGameObjectsChild = new List<GameObject> ();
		
		//Initialize the map
		mapArmMovement = new Dictionary<eArmDirection,ArmstoMove>();
		
		//Initialize the Structures for the Arm Movements
		
		//---------------------------- Sub Arm 1-----------------------------------------------
		
		//Arm 1 Moving X
		ArmstoMove stArm1MovingX = new ArmstoMove ();
		stArm1MovingX.bArm1 = false;
		stArm1MovingX.bArm2 = false;
		stArm1MovingX.bArm3 = false;
		stArm1MovingX.bArm4 = false;
		stArm1MovingX.bArm5 = false;
		stArm1MovingX.bArm6 = false;
		stArm1MovingX.bArm7 = false;
		stArm1MovingX.bArm8 = false;
		
		stArm1MovingX.bRestrictedArm1 = true;
		stArm1MovingX.bRestrictedArm2 = true;
		stArm1MovingX.bRestrictedArm3 = true;
		stArm1MovingX.bRestrictedArm4 = false;
		stArm1MovingX.bRestrictedArm5 = false;
		stArm1MovingX.bRestrictedArm6 = false;
		stArm1MovingX.bRestrictedArm7 = false;
		stArm1MovingX.bRestrictedArm8 = false;
		
		
		//Arm 1 Moving Y
		ArmstoMove stArm1MovingY = new ArmstoMove ();
		stArm1MovingY.bArm1 = true;
		stArm1MovingY.bArm2 = false;
		stArm1MovingY.bArm3 = false;
		stArm1MovingY.bArm4 = false;
		stArm1MovingY.bArm5 = false;
		stArm1MovingY.bArm6 = false;
		stArm1MovingY.bArm7 = false;
		stArm1MovingY.bArm8 = false;
		
		stArm1MovingY.bRestrictedArm1 = false;
		stArm1MovingY.bRestrictedArm2 = true;
		stArm1MovingY.bRestrictedArm3 = true;
		stArm1MovingY.bRestrictedArm4 = false;
		stArm1MovingY.bRestrictedArm5 = false;
		stArm1MovingY.bRestrictedArm6 = false;
		stArm1MovingY.bRestrictedArm7 = false;
		stArm1MovingY.bRestrictedArm8 = false;
		
		//Arm 1 Moving Z
		ArmstoMove stArm1MovingZ = new ArmstoMove ();
		stArm1MovingZ.bArm1 = false;
		stArm1MovingZ.bArm2 = false;
		stArm1MovingZ.bArm3 = false;
		stArm1MovingZ.bArm4 = false;
		stArm1MovingZ.bArm5 = false;
		stArm1MovingZ.bArm6 = true;
		stArm1MovingZ.bArm7 = false;
		stArm1MovingZ.bArm8 = false;
		
		stArm1MovingZ.bRestrictedArm1 = false;
		stArm1MovingZ.bRestrictedArm2 = false;
		stArm1MovingZ.bRestrictedArm3 = false;
		stArm1MovingZ.bRestrictedArm4 = true;
		stArm1MovingZ.bRestrictedArm5 = true;
		stArm1MovingZ.bRestrictedArm6 = false;
		stArm1MovingZ.bRestrictedArm7 = false;
		stArm1MovingZ.bRestrictedArm8 = false;
		
		//Arm 1 Moving XY
		ArmstoMove stArm1MovingXY = new ArmstoMove ();
		stArm1MovingXY.bArm1 = false;
		stArm1MovingXY.bArm2 = false;
		stArm1MovingXY.bArm3 = false;
		stArm1MovingXY.bArm4 = false;
		stArm1MovingXY.bArm5 = false;
		stArm1MovingXY.bArm6 = false;
		stArm1MovingXY.bArm7 = false;
		stArm1MovingXY.bArm8 = false;
		
		stArm1MovingXY.bRestrictedArm1 = true;
		stArm1MovingXY.bRestrictedArm2 = true;
		stArm1MovingXY.bRestrictedArm3 = true;
		stArm1MovingXY.bRestrictedArm4 = false;
		stArm1MovingXY.bRestrictedArm5 = false;
		stArm1MovingXY.bRestrictedArm6 = false;
		stArm1MovingXY.bRestrictedArm7 = false;
		stArm1MovingXY.bRestrictedArm8 = false;
		
		//Arm 1 Moving YZ
		ArmstoMove stArm1MovingYZ = new ArmstoMove ();
		stArm1MovingYZ.bArm1 = false;
		stArm1MovingYZ.bArm2 = false;
		stArm1MovingYZ.bArm3 = false;
		stArm1MovingYZ.bArm4 = false;
		stArm1MovingYZ.bArm5 = false;
		stArm1MovingYZ.bArm6 = false;
		stArm1MovingYZ.bArm7 = false;
		stArm1MovingYZ.bArm8 = false;
		
		stArm1MovingYZ.bRestrictedArm1 = true;
		stArm1MovingYZ.bRestrictedArm2 = true;
		stArm1MovingYZ.bRestrictedArm3 = true;
		stArm1MovingYZ.bRestrictedArm4 = true;
		stArm1MovingYZ.bRestrictedArm5 = true;
		stArm1MovingYZ.bRestrictedArm6 = true;
		stArm1MovingYZ.bRestrictedArm7 = false;
		stArm1MovingYZ.bRestrictedArm8 = false;
		
		//Arm 1 Moving ZX
		ArmstoMove stArm1MovingZX = new ArmstoMove ();
		stArm1MovingZX.bArm1 = false;
		stArm1MovingZX.bArm2 = false;
		stArm1MovingZX.bArm3 = false;
		stArm1MovingZX.bArm4 = false;
		stArm1MovingZX.bArm5 = true;
		stArm1MovingZX.bArm6 = false;
		stArm1MovingZX.bArm7 = false;
		stArm1MovingZX.bArm8 = false;
		
		stArm1MovingZX.bRestrictedArm1 = false;
		stArm1MovingZX.bRestrictedArm2 = false;
		stArm1MovingZX.bRestrictedArm3 = false;
		stArm1MovingZX.bRestrictedArm4 = false;
		stArm1MovingZX.bRestrictedArm5 = true;
		stArm1MovingZX.bRestrictedArm6 = true;
		stArm1MovingZX.bRestrictedArm7 = false;
		stArm1MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm1MovingX,stArm1MovingX);
		mapArmMovement.Add(eArmDirection.eArm1MovingY,stArm1MovingY);
		mapArmMovement.Add(eArmDirection.eArm1MovingZ,stArm1MovingZ);
		mapArmMovement.Add(eArmDirection.eArm1MovingXY,stArm1MovingXY);
		mapArmMovement.Add(eArmDirection.eArm1MovingYZ,stArm1MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm1MovingZX,stArm1MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		//---------------------------- Sub Arm 2-----------------------------------------------
		
		//Arm 2 Moving X
		ArmstoMove stArm2MovingX = new ArmstoMove ();
		stArm2MovingX.bArm1 = false;
		stArm2MovingX.bArm2 = false;
		stArm2MovingX.bArm3 = false;
		stArm2MovingX.bArm4 = false;
		stArm2MovingX.bArm5 = false;
		stArm2MovingX.bArm6 = false;
		stArm2MovingX.bArm7 = false;
		stArm2MovingX.bArm8 = false;
		
		stArm2MovingX.bRestrictedArm1 = false;
		stArm2MovingX.bRestrictedArm2 = true;
		stArm2MovingX.bRestrictedArm3 = true;
		stArm2MovingX.bRestrictedArm4 = false;
		stArm2MovingX.bRestrictedArm5 = false;
		stArm2MovingX.bRestrictedArm6 = false;
		stArm2MovingX.bRestrictedArm7 = false;
		stArm2MovingX.bRestrictedArm8 = false;
		
		
		//Arm 2 Moving Y
		ArmstoMove stArm2MovingY = new ArmstoMove ();
		stArm2MovingY.bArm1 = false;
		stArm2MovingY.bArm2 = true;
		stArm2MovingY.bArm3 = false;
		stArm2MovingY.bArm4 = false;
		stArm2MovingY.bArm5 = false;
		stArm2MovingY.bArm6 = false;
		stArm2MovingY.bArm7 = false;
		stArm2MovingY.bArm8 = false;
		
		stArm2MovingY.bRestrictedArm1 = false;
		stArm2MovingY.bRestrictedArm2 = false;
		stArm2MovingY.bRestrictedArm3 = true;
		stArm2MovingY.bRestrictedArm4 = false;
		stArm2MovingY.bRestrictedArm5 = false;
		stArm2MovingY.bRestrictedArm6 = false;
		stArm2MovingY.bRestrictedArm7 = false;
		stArm2MovingY.bRestrictedArm8 = false;
		
		//Arm 2 Moving Z
		ArmstoMove stArm2MovingZ = new ArmstoMove ();
		stArm2MovingZ.bArm1 = false;
		stArm2MovingZ.bArm2 = false;
		stArm2MovingZ.bArm3 = false;
		stArm2MovingZ.bArm4 = false;
		stArm2MovingZ.bArm5 = false;
		stArm2MovingZ.bArm6 = true;
		stArm2MovingZ.bArm7 = false;
		stArm2MovingZ.bArm8 = false;
		
		stArm2MovingZ.bRestrictedArm1 = false;
		stArm2MovingZ.bRestrictedArm2 = false;
		stArm2MovingZ.bRestrictedArm3 = false;
		stArm2MovingZ.bRestrictedArm4 = true;
		stArm2MovingZ.bRestrictedArm5 = true;
		stArm2MovingZ.bRestrictedArm6 = false;
		stArm2MovingZ.bRestrictedArm7 = false;
		stArm2MovingZ.bRestrictedArm8 = false;
		
		//Arm 2 Moving XY
		ArmstoMove stArm2MovingXY = new ArmstoMove ();
		stArm2MovingXY.bArm1 = false;
		stArm2MovingXY.bArm2 = false;
		stArm2MovingXY.bArm3 = false;
		stArm2MovingXY.bArm4 = false;
		stArm2MovingXY.bArm5 = false;
		stArm2MovingXY.bArm6 = false;
		stArm2MovingXY.bArm7 = false;
		stArm2MovingXY.bArm8 = false;
		
		stArm2MovingXY.bRestrictedArm1 = false;
		stArm2MovingXY.bRestrictedArm2 = true;
		stArm2MovingXY.bRestrictedArm3 = true;
		stArm2MovingXY.bRestrictedArm4 = false;
		stArm2MovingXY.bRestrictedArm5 = false;
		stArm2MovingXY.bRestrictedArm6 = false;
		stArm2MovingXY.bRestrictedArm7 = false;
		stArm2MovingXY.bRestrictedArm8 = false;
		
		//Arm 2 Moving YZ
		ArmstoMove stArm2MovingYZ = new ArmstoMove ();
		stArm2MovingYZ.bArm1 = false;
		stArm2MovingYZ.bArm2 = false;
		stArm2MovingYZ.bArm3 = false;
		stArm2MovingYZ.bArm4 = false;
		stArm2MovingYZ.bArm5 = false;
		stArm2MovingYZ.bArm6 = false;
		stArm2MovingYZ.bArm7 = false;
		stArm2MovingYZ.bArm8 = false;
		
		stArm2MovingYZ.bRestrictedArm1 = false;
		stArm2MovingYZ.bRestrictedArm2 = true;
		stArm2MovingYZ.bRestrictedArm3 = true;
		stArm2MovingYZ.bRestrictedArm4 = true;
		stArm2MovingYZ.bRestrictedArm5 = true;
		stArm2MovingYZ.bRestrictedArm6 = true;
		stArm2MovingYZ.bRestrictedArm7 = false;
		stArm2MovingYZ.bRestrictedArm8 = false;
		
		//Arm 2 Moving ZX
		ArmstoMove stArm2MovingZX = new ArmstoMove ();
		stArm2MovingZX.bArm1 = false;
		stArm2MovingZX.bArm2 = false;
		stArm2MovingZX.bArm3 = false;
		stArm2MovingZX.bArm4 = false;
		stArm2MovingZX.bArm5 = true;
		stArm2MovingZX.bArm6 = false;
		stArm2MovingZX.bArm7 = false;
		stArm2MovingZX.bArm8 = false;
		
		stArm2MovingZX.bRestrictedArm1 = false;
		stArm2MovingZX.bRestrictedArm2 = false;
		stArm2MovingZX.bRestrictedArm3 = false;
		stArm2MovingZX.bRestrictedArm4 = false;
		stArm2MovingZX.bRestrictedArm5 = true;
		stArm2MovingZX.bRestrictedArm6 = true;
		stArm2MovingZX.bRestrictedArm7 = false;
		stArm2MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm2MovingX,stArm2MovingX);
		mapArmMovement.Add(eArmDirection.eArm2MovingY,stArm2MovingY);
		mapArmMovement.Add(eArmDirection.eArm2MovingZ,stArm2MovingZ);
		mapArmMovement.Add(eArmDirection.eArm2MovingXY,stArm2MovingXY);
		mapArmMovement.Add(eArmDirection.eArm2MovingYZ,stArm2MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm2MovingZX,stArm2MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		
		
		
		//---------------------------- Sub Arm 3-----------------------------------------------
		
		//Arm 3 Moving X
		ArmstoMove stArm3MovingX = new ArmstoMove ();
		stArm3MovingX.bArm1 = false;
		stArm3MovingX.bArm2 = false;
		stArm3MovingX.bArm3 = false;
		stArm3MovingX.bArm4 = false;
		stArm3MovingX.bArm5 = false;
		stArm3MovingX.bArm6 = false;
		stArm3MovingX.bArm7 = false;
		stArm3MovingX.bArm8 = false;
		
		stArm3MovingX.bRestrictedArm1 = false;
		stArm3MovingX.bRestrictedArm2 = false;
		stArm3MovingX.bRestrictedArm3 = true;
		stArm3MovingX.bRestrictedArm4 = false;
		stArm3MovingX.bRestrictedArm5 = false;
		stArm3MovingX.bRestrictedArm6 = false;
		stArm3MovingX.bRestrictedArm7 = false;
		stArm3MovingX.bRestrictedArm8 = false;
		
		
		//Arm 3 Moving Y
		ArmstoMove stArm3MovingY = new ArmstoMove ();
		stArm3MovingY.bArm1 = false;
		stArm3MovingY.bArm2 = false;
		stArm3MovingY.bArm3 = true;
		stArm3MovingY.bArm4 = false;
		stArm3MovingY.bArm5 = false;
		stArm3MovingY.bArm6 = false;
		stArm3MovingY.bArm7 = false;
		stArm3MovingY.bArm8 = false;
		
		stArm3MovingY.bRestrictedArm1 = false;
		stArm3MovingY.bRestrictedArm2 = false;
		stArm3MovingY.bRestrictedArm3 = false;
		stArm3MovingY.bRestrictedArm4 = false;
		stArm3MovingY.bRestrictedArm5 = false;
		stArm3MovingY.bRestrictedArm6 = false;
		stArm3MovingY.bRestrictedArm7 = false;
		stArm3MovingY.bRestrictedArm8 = false;
		
		//Arm 3 Moving Z
		ArmstoMove stArm3MovingZ = new ArmstoMove ();
		stArm3MovingZ.bArm1 = false;
		stArm3MovingZ.bArm2 = false;
		stArm3MovingZ.bArm3 = false;
		stArm3MovingZ.bArm4 = false;
		stArm3MovingZ.bArm5 = false;
		stArm3MovingZ.bArm6 = true;
		stArm3MovingZ.bArm7 = false;
		stArm3MovingZ.bArm8 = false;
		
		stArm3MovingZ.bRestrictedArm1 = false;
		stArm3MovingZ.bRestrictedArm2 = false;
		stArm3MovingZ.bRestrictedArm3 = false;
		stArm3MovingZ.bRestrictedArm4 = true;
		stArm3MovingZ.bRestrictedArm5 = true;
		stArm3MovingZ.bRestrictedArm6 = false;
		stArm3MovingZ.bRestrictedArm7 = false;
		stArm3MovingZ.bRestrictedArm8 = false;
		
		//Arm 3 Moving XY
		ArmstoMove stArm3MovingXY = new ArmstoMove ();
		stArm3MovingXY.bArm1 = false;
		stArm3MovingXY.bArm2 = false;
		stArm3MovingXY.bArm3 = false;
		stArm3MovingXY.bArm4 = false;
		stArm3MovingXY.bArm5 = false;
		stArm3MovingXY.bArm6 = false;
		stArm3MovingXY.bArm7 = false;
		stArm3MovingXY.bArm8 = false;
		
		stArm3MovingXY.bRestrictedArm1 = false;
		stArm3MovingXY.bRestrictedArm2 = false;
		stArm3MovingXY.bRestrictedArm3 = true;
		stArm3MovingXY.bRestrictedArm4 = false;
		stArm3MovingXY.bRestrictedArm5 = false;
		stArm3MovingXY.bRestrictedArm6 = false;
		stArm3MovingXY.bRestrictedArm7 = false;
		stArm3MovingXY.bRestrictedArm8 = false;
		
		//Arm 3 Moving YZ
		ArmstoMove stArm3MovingYZ = new ArmstoMove ();
		stArm3MovingYZ.bArm1 = false;
		stArm3MovingYZ.bArm2 = false;
		stArm3MovingYZ.bArm3 = false;
		stArm3MovingYZ.bArm4 = false;
		stArm3MovingYZ.bArm5 = false;
		stArm3MovingYZ.bArm6 = false;
		stArm3MovingYZ.bArm7 = false;
		stArm3MovingYZ.bArm8 = false;
		
		stArm3MovingYZ.bRestrictedArm1 = false;
		stArm3MovingYZ.bRestrictedArm2 = false;
		stArm3MovingYZ.bRestrictedArm3 = true;
		stArm3MovingYZ.bRestrictedArm4 = true;
		stArm3MovingYZ.bRestrictedArm5 = true;
		stArm3MovingYZ.bRestrictedArm6 = true;
		stArm3MovingYZ.bRestrictedArm7 = false;
		stArm3MovingYZ.bRestrictedArm8 = false;
		
		//Arm 3 Moving ZX
		ArmstoMove stArm3MovingZX = new ArmstoMove ();
		stArm3MovingZX.bArm1 = false;
		stArm3MovingZX.bArm2 = false;
		stArm3MovingZX.bArm3 = false;
		stArm3MovingZX.bArm4 = false;
		stArm3MovingZX.bArm5 = true;
		stArm3MovingZX.bArm6 = false;
		stArm3MovingZX.bArm7 = false;
		stArm3MovingZX.bArm8 = false;
		
		stArm3MovingZX.bRestrictedArm1 = false;
		stArm3MovingZX.bRestrictedArm2 = false;
		stArm3MovingZX.bRestrictedArm3 = false;
		stArm3MovingZX.bRestrictedArm4 = false;
		stArm3MovingZX.bRestrictedArm5 = true;
		stArm3MovingZX.bRestrictedArm6 = true;
		stArm3MovingZX.bRestrictedArm7 = false;
		stArm3MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm3MovingX,stArm3MovingX);
		mapArmMovement.Add(eArmDirection.eArm3MovingY,stArm3MovingY);
		mapArmMovement.Add(eArmDirection.eArm3MovingZ,stArm3MovingZ);
		mapArmMovement.Add(eArmDirection.eArm3MovingXY,stArm3MovingXY);
		mapArmMovement.Add(eArmDirection.eArm3MovingYZ,stArm3MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm3MovingZX,stArm3MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		
		
		//---------------------------- Sub Arm 4-----------------------------------------------
		
		//Arm 4 Moving X
		ArmstoMove stArm4MovingX = new ArmstoMove ();
		stArm4MovingX.bArm1 = false;
		stArm4MovingX.bArm2 = false;
		stArm4MovingX.bArm3 = false;
		stArm4MovingX.bArm4 = false;
		stArm4MovingX.bArm5 = false;
		stArm4MovingX.bArm6 = false;
		stArm4MovingX.bArm7 = false;
		stArm4MovingX.bArm8 = false;
		
		stArm4MovingX.bRestrictedArm1 = false;
		stArm4MovingX.bRestrictedArm2 = false;
		stArm4MovingX.bRestrictedArm3 = false;
		stArm4MovingX.bRestrictedArm4 = false;
		stArm4MovingX.bRestrictedArm5 = false;
		stArm4MovingX.bRestrictedArm6 = false;
		stArm4MovingX.bRestrictedArm7 = false;
		stArm4MovingX.bRestrictedArm8 = false;
		
		
		//Arm 4 Moving Y
		ArmstoMove stArm4MovingY = new ArmstoMove ();
		stArm4MovingY.bArm1 = false;
		stArm4MovingY.bArm2 = false;
		stArm4MovingY.bArm3 = false;
		stArm4MovingY.bArm4 = false;
		stArm4MovingY.bArm5 = false;
		stArm4MovingY.bArm6 = false;
		stArm4MovingY.bArm7 = false;
		stArm4MovingY.bArm8 = false;
		
		stArm4MovingY.bRestrictedArm1 = false;
		stArm4MovingY.bRestrictedArm2 = false;
		stArm4MovingY.bRestrictedArm3 = false;
		stArm4MovingY.bRestrictedArm4 = false;
		stArm4MovingY.bRestrictedArm5 = false;
		stArm4MovingY.bRestrictedArm6 = false;
		stArm4MovingY.bRestrictedArm7 = false;
		stArm4MovingY.bRestrictedArm8 = false;
		
		//Arm 4 Moving Z
		ArmstoMove stArm4MovingZ = new ArmstoMove ();
		stArm4MovingZ.bArm1 = false;
		stArm4MovingZ.bArm2 = false;
		stArm4MovingZ.bArm3 = false;
		stArm4MovingZ.bArm4 = true;
		stArm4MovingZ.bArm5 = false;
		stArm4MovingZ.bArm6 = false;
		stArm4MovingZ.bArm7 = false;
		stArm4MovingZ.bArm8 = false;
		
		stArm4MovingZ.bRestrictedArm1 = false;
		stArm4MovingZ.bRestrictedArm2 = false;
		stArm4MovingZ.bRestrictedArm4 = false;
		stArm4MovingZ.bRestrictedArm4 = false;
		stArm4MovingZ.bRestrictedArm5 = true;
		stArm4MovingZ.bRestrictedArm6 = true;
		stArm4MovingZ.bRestrictedArm7 = false;
		stArm4MovingZ.bRestrictedArm8 = false;
		
		//Arm 4 Moving XY
		ArmstoMove stArm4MovingXY = new ArmstoMove ();
		stArm4MovingXY.bArm1 = false;
		stArm4MovingXY.bArm2 = false;
		stArm4MovingXY.bArm3 = false;
		stArm4MovingXY.bArm4 = false;
		stArm4MovingXY.bArm5 = false;
		stArm4MovingXY.bArm6 = false;
		stArm4MovingXY.bArm7 = false;
		stArm4MovingXY.bArm8 = false;
		
		stArm4MovingXY.bRestrictedArm1 = false;
		stArm4MovingXY.bRestrictedArm2 = false;
		stArm4MovingXY.bRestrictedArm3 = false;
		stArm4MovingXY.bRestrictedArm4 = false;
		stArm4MovingXY.bRestrictedArm5 = false;
		stArm4MovingXY.bRestrictedArm6 = false;
		stArm4MovingXY.bRestrictedArm7 = false;
		stArm4MovingXY.bRestrictedArm8 = false;
		
		//Arm 4 Moving YZ
		ArmstoMove stArm4MovingYZ = new ArmstoMove ();
		stArm4MovingYZ.bArm1 = false;
		stArm4MovingYZ.bArm2 = false;
		stArm4MovingYZ.bArm3 = false;
		stArm4MovingYZ.bArm4 = true;
		stArm4MovingYZ.bArm5 = false;
		stArm4MovingYZ.bArm6 = false;
		stArm4MovingYZ.bArm7 = false;
		stArm4MovingYZ.bArm8 = false;
		
		stArm4MovingYZ.bRestrictedArm1 = false;
		stArm4MovingYZ.bRestrictedArm2 = false;
		stArm4MovingYZ.bRestrictedArm3 = false;
		stArm4MovingYZ.bRestrictedArm4 = false;
		stArm4MovingYZ.bRestrictedArm5 = true;
		stArm4MovingYZ.bRestrictedArm6 = true;
		stArm4MovingYZ.bRestrictedArm7 = false;
		stArm4MovingYZ.bRestrictedArm8 = false;
		
		//Arm 4 Moving ZX
		ArmstoMove stArm4MovingZX = new ArmstoMove ();
		stArm4MovingZX.bArm1 = false;
		stArm4MovingZX.bArm2 = false;
		stArm4MovingZX.bArm3 = false;
		stArm4MovingZX.bArm4 = false;
		stArm4MovingZX.bArm5 = false;
		stArm4MovingZX.bArm6 = true;
		stArm4MovingZX.bArm7 = false;
		stArm4MovingZX.bArm8 = false;
		
		stArm4MovingZX.bRestrictedArm1 = false;
		stArm4MovingZX.bRestrictedArm2 = false;
		stArm4MovingZX.bRestrictedArm3 = false;
		stArm4MovingZX.bRestrictedArm4 = true;
		stArm4MovingZX.bRestrictedArm5 = true;
		stArm4MovingZX.bRestrictedArm6 = false;
		stArm4MovingZX.bRestrictedArm7 = false;
		stArm4MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm4MovingX,stArm4MovingX);
		mapArmMovement.Add(eArmDirection.eArm4MovingY,stArm4MovingY);
		mapArmMovement.Add(eArmDirection.eArm4MovingZ,stArm4MovingZ);
		mapArmMovement.Add(eArmDirection.eArm4MovingXY,stArm4MovingXY);
		mapArmMovement.Add(eArmDirection.eArm4MovingYZ,stArm4MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm4MovingZX,stArm4MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		
		
		
		
		//---------------------------- Sub Arm 5-----------------------------------------------
		
		//Arm 5 Moving X
		ArmstoMove stArm5MovingX = new ArmstoMove ();
		stArm5MovingX.bArm1 = false;
		stArm5MovingX.bArm2 = false;
		stArm5MovingX.bArm3 = false;
		stArm5MovingX.bArm4 = false;
		stArm5MovingX.bArm5 = false;
		stArm5MovingX.bArm6 = false;
		stArm5MovingX.bArm7 = false;
		stArm5MovingX.bArm8 = false;
		
		stArm5MovingX.bRestrictedArm1 = false;
		stArm5MovingX.bRestrictedArm2 = false;
		stArm5MovingX.bRestrictedArm3 = false;
		stArm5MovingX.bRestrictedArm4 = false;
		stArm5MovingX.bRestrictedArm5 = false;
		stArm5MovingX.bRestrictedArm6 = false;
		stArm5MovingX.bRestrictedArm7 = false;
		stArm5MovingX.bRestrictedArm8 = false;
		
		
		//Arm 5 Moving Y
		ArmstoMove stArm5MovingY = new ArmstoMove ();
		stArm5MovingY.bArm1 = false;
		stArm5MovingY.bArm2 = false;
		stArm5MovingY.bArm3 = false;
		stArm5MovingY.bArm4 = false;
		stArm5MovingY.bArm5 = false;
		stArm5MovingY.bArm6 = false;
		stArm5MovingY.bArm7 = false;
		stArm5MovingY.bArm8 = false;
		
		stArm5MovingY.bRestrictedArm1 = false;
		stArm5MovingY.bRestrictedArm2 = false;
		stArm5MovingY.bRestrictedArm3 = false;
		stArm5MovingY.bRestrictedArm4 = false;
		stArm5MovingY.bRestrictedArm5 = false;
		stArm5MovingY.bRestrictedArm6 = false;
		stArm5MovingY.bRestrictedArm7 = false;
		stArm5MovingY.bRestrictedArm8 = false;
		
		//Arm 5 Moving Z
		ArmstoMove stArm5MovingZ = new ArmstoMove ();
		stArm5MovingZ.bArm1 = false;
		stArm5MovingZ.bArm2 = false;
		stArm5MovingZ.bArm3 = false;
		stArm5MovingZ.bArm4 = false;
		stArm5MovingZ.bArm5 = true;
		stArm5MovingZ.bArm6 = false;
		stArm5MovingZ.bArm7 = false;
		stArm5MovingZ.bArm8 = false;
		
		stArm5MovingZ.bRestrictedArm1 = false;
		stArm5MovingZ.bRestrictedArm2 = false;
		stArm5MovingZ.bRestrictedArm4 = false;
		stArm5MovingZ.bRestrictedArm4 = false;
		stArm5MovingZ.bRestrictedArm5 = false;
		stArm5MovingZ.bRestrictedArm6 = true;
		stArm5MovingZ.bRestrictedArm7 = false;
		stArm5MovingZ.bRestrictedArm8 = false;
		
		//Arm 5 Moving XY
		ArmstoMove stArm5MovingXY = new ArmstoMove ();
		stArm5MovingXY.bArm1 = false;
		stArm5MovingXY.bArm2 = false;
		stArm5MovingXY.bArm3 = false;
		stArm5MovingXY.bArm4 = false;
		stArm5MovingXY.bArm5 = false;
		stArm5MovingXY.bArm6 = false;
		stArm5MovingXY.bArm7 = false;
		stArm5MovingXY.bArm8 = false;
		
		stArm5MovingXY.bRestrictedArm1 = false;
		stArm5MovingXY.bRestrictedArm2 = false;
		stArm5MovingXY.bRestrictedArm3 = false;
		stArm5MovingXY.bRestrictedArm4 = false;
		stArm5MovingXY.bRestrictedArm5 = false;
		stArm5MovingXY.bRestrictedArm6 = false;
		stArm5MovingXY.bRestrictedArm7 = false;
		stArm5MovingXY.bRestrictedArm8 = false;
		
		//Arm 5 Moving YZ
		ArmstoMove stArm5MovingYZ = new ArmstoMove ();
		stArm5MovingYZ.bArm1 = false;
		stArm5MovingYZ.bArm2 = false;
		stArm5MovingYZ.bArm3 = false;
		stArm5MovingYZ.bArm4 = false;
		stArm5MovingYZ.bArm5 = true;
		stArm5MovingYZ.bArm6 = false;
		stArm5MovingYZ.bArm7 = false;
		stArm5MovingYZ.bArm8 = false;
		
		stArm5MovingYZ.bRestrictedArm1 = false;
		stArm5MovingYZ.bRestrictedArm2 = false;
		stArm5MovingYZ.bRestrictedArm3 = false;
		stArm5MovingYZ.bRestrictedArm4 = false;
		stArm5MovingYZ.bRestrictedArm5 = false;
		stArm5MovingYZ.bRestrictedArm6 = true;
		stArm5MovingYZ.bRestrictedArm7 = false;
		stArm5MovingYZ.bRestrictedArm8 = false;
		
		//Arm 5 Moving ZX
		ArmstoMove stArm5MovingZX = new ArmstoMove ();
		stArm5MovingZX.bArm1 = false;
		stArm5MovingZX.bArm2 = false;
		stArm5MovingZX.bArm3 = false;
		stArm5MovingZX.bArm4 = false;
		stArm5MovingZX.bArm5 = false;
		stArm5MovingZX.bArm6 = true;
		stArm5MovingZX.bArm7 = false;
		stArm5MovingZX.bArm8 = false;
		
		stArm5MovingZX.bRestrictedArm1 = false;
		stArm5MovingZX.bRestrictedArm2 = false;
		stArm5MovingZX.bRestrictedArm3 = false;
		stArm5MovingZX.bRestrictedArm4 = false;
		stArm5MovingZX.bRestrictedArm5 = true;
		stArm5MovingZX.bRestrictedArm6 = false;
		stArm5MovingZX.bRestrictedArm7 = false;
		stArm5MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm5MovingX,stArm5MovingX);
		mapArmMovement.Add(eArmDirection.eArm5MovingY,stArm5MovingY);
		mapArmMovement.Add(eArmDirection.eArm5MovingZ,stArm5MovingZ);
		mapArmMovement.Add(eArmDirection.eArm5MovingXY,stArm5MovingXY);
		mapArmMovement.Add(eArmDirection.eArm5MovingYZ,stArm5MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm5MovingZX,stArm5MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		
		
		//---------------------------- Sub Arm 6-----------------------------------------------
		
		//Arm 6 Moving X
		ArmstoMove stArm6MovingX = new ArmstoMove ();
		stArm6MovingX.bArm1 = false;
		stArm6MovingX.bArm2 = false;
		stArm6MovingX.bArm3 = false;
		stArm6MovingX.bArm4 = false;
		stArm6MovingX.bArm5 = false;
		stArm6MovingX.bArm6 = false;
		stArm6MovingX.bArm7 = false;
		stArm6MovingX.bArm8 = false;
		
		stArm6MovingX.bRestrictedArm1 = false;
		stArm6MovingX.bRestrictedArm2 = false;
		stArm6MovingX.bRestrictedArm3 = false;
		stArm6MovingX.bRestrictedArm4 = false;
		stArm6MovingX.bRestrictedArm5 = false;
		stArm6MovingX.bRestrictedArm6 = false;
		stArm6MovingX.bRestrictedArm7 = false;
		stArm6MovingX.bRestrictedArm8 = false;
		
		
		//Arm 6 Moving Y
		ArmstoMove stArm6MovingY = new ArmstoMove ();
		stArm6MovingY.bArm1 = false;
		stArm6MovingY.bArm2 = false;
		stArm6MovingY.bArm3 = false;
		stArm6MovingY.bArm4 = false;
		stArm6MovingY.bArm5 = false;
		stArm6MovingY.bArm6 = false;
		stArm6MovingY.bArm7 = false;
		stArm6MovingY.bArm8 = false;
		
		stArm6MovingY.bRestrictedArm1 = false;
		stArm6MovingY.bRestrictedArm2 = false;
		stArm6MovingY.bRestrictedArm3 = false;
		stArm6MovingY.bRestrictedArm4 = false;
		stArm6MovingY.bRestrictedArm5 = false;
		stArm6MovingY.bRestrictedArm6 = false;
		stArm6MovingY.bRestrictedArm7 = false;
		stArm6MovingY.bRestrictedArm8 = false;
		
		//Arm 6 Moving Z
		ArmstoMove stArm6MovingZ = new ArmstoMove ();
		stArm6MovingZ.bArm1 = false;
		stArm6MovingZ.bArm2 = false;
		stArm6MovingZ.bArm3 = false;
		stArm6MovingZ.bArm4 = false;
		stArm6MovingZ.bArm5 = false;
		stArm6MovingZ.bArm6 = true;
		stArm6MovingZ.bArm7 = false;
		stArm6MovingZ.bArm8 = false;
		
		stArm6MovingZ.bRestrictedArm1 = false;
		stArm6MovingZ.bRestrictedArm2 = false;
		stArm6MovingZ.bRestrictedArm3 = false;
		stArm6MovingZ.bRestrictedArm4 = false;
		stArm6MovingZ.bRestrictedArm5 = false;
		stArm6MovingZ.bRestrictedArm6 = false;
		stArm6MovingZ.bRestrictedArm7 = false;
		stArm6MovingZ.bRestrictedArm8 = false;
		
		//Arm 6 Moving XY
		ArmstoMove stArm6MovingXY = new ArmstoMove ();
		stArm6MovingXY.bArm1 = false;
		stArm6MovingXY.bArm2 = false;
		stArm6MovingXY.bArm3 = false;
		stArm6MovingXY.bArm4 = false;
		stArm6MovingXY.bArm5 = false;
		stArm6MovingXY.bArm6 = false;
		stArm6MovingXY.bArm7 = false;
		stArm6MovingXY.bArm8 = false;
		
		stArm6MovingXY.bRestrictedArm1 = false;
		stArm6MovingXY.bRestrictedArm2 = false;
		stArm6MovingXY.bRestrictedArm3 = false;
		stArm6MovingXY.bRestrictedArm4 = false;
		stArm6MovingXY.bRestrictedArm5 = false;
		stArm6MovingXY.bRestrictedArm6 = false;
		stArm6MovingXY.bRestrictedArm7 = false;
		stArm6MovingXY.bRestrictedArm8 = false;
		
		//Arm 6 Moving YZ
		ArmstoMove stArm6MovingYZ = new ArmstoMove ();
		stArm6MovingYZ.bArm1 = false;
		stArm6MovingYZ.bArm2 = false;
		stArm6MovingYZ.bArm3 = false;
		stArm6MovingYZ.bArm4 = false;
		stArm6MovingYZ.bArm5 = false;
		stArm6MovingYZ.bArm6 = false;
		stArm6MovingYZ.bArm7 = false;
		stArm6MovingYZ.bArm8 = false;
		
		stArm6MovingYZ.bRestrictedArm1 = false;
		stArm6MovingYZ.bRestrictedArm2 = false;
		stArm6MovingYZ.bRestrictedArm3 = false;
		stArm6MovingYZ.bRestrictedArm4 = false;
		stArm6MovingYZ.bRestrictedArm5 = false;
		stArm6MovingYZ.bRestrictedArm6 = true;
		stArm6MovingYZ.bRestrictedArm7 = false;
		stArm6MovingYZ.bRestrictedArm8 = false;
		
		//Arm 6 Moving ZX
		ArmstoMove stArm6MovingZX = new ArmstoMove ();
		stArm6MovingZX.bArm1 = false;
		stArm6MovingZX.bArm2 = false;
		stArm6MovingZX.bArm3 = false;
		stArm6MovingZX.bArm4 = false;
		stArm6MovingZX.bArm5 = false;
		stArm6MovingZX.bArm6 = true;
		stArm6MovingZX.bArm7 = false;
		stArm6MovingZX.bArm8 = false;
		
		stArm6MovingZX.bRestrictedArm1 = false;
		stArm6MovingZX.bRestrictedArm2 = false;
		stArm6MovingZX.bRestrictedArm3 = false;
		stArm6MovingZX.bRestrictedArm4 = false;
		stArm6MovingZX.bRestrictedArm5 = false;
		stArm6MovingZX.bRestrictedArm6 = false;
		stArm6MovingZX.bRestrictedArm7 = false;
		stArm6MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm6MovingX,stArm6MovingX);
		mapArmMovement.Add(eArmDirection.eArm6MovingY,stArm6MovingY);
		mapArmMovement.Add(eArmDirection.eArm6MovingZ,stArm6MovingZ);
		mapArmMovement.Add(eArmDirection.eArm6MovingXY,stArm6MovingXY);
		mapArmMovement.Add(eArmDirection.eArm6MovingYZ,stArm6MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm6MovingZX,stArm6MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		
		
		//---------------------------- Sub Arm 7-----------------------------------------------
		
		//Arm 7 Moving X
		ArmstoMove stArm7MovingX = new ArmstoMove ();
		stArm7MovingX.bArm1 = false;
		stArm7MovingX.bArm2 = false;
		stArm7MovingX.bArm3 = false;
		stArm7MovingX.bArm4 = false;
		stArm7MovingX.bArm5 = false;
		stArm7MovingX.bArm6 = false;
		stArm7MovingX.bArm7 = false;
		stArm7MovingX.bArm8 = false;
		
		stArm7MovingX.bRestrictedArm1 = false;
		stArm7MovingX.bRestrictedArm2 = false;
		stArm7MovingX.bRestrictedArm3 = false;
		stArm7MovingX.bRestrictedArm4 = false;
		stArm7MovingX.bRestrictedArm5 = false;
		stArm7MovingX.bRestrictedArm6 = false;
		stArm7MovingX.bRestrictedArm7 = false;
		stArm7MovingX.bRestrictedArm8 = false;
		
		
		//Arm 7 Moving Y
		ArmstoMove stArm7MovingY = new ArmstoMove ();
		stArm7MovingY.bArm1 = false;
		stArm7MovingY.bArm2 = false;
		stArm7MovingY.bArm3 = false;
		stArm7MovingY.bArm4 = false;
		stArm7MovingY.bArm5 = false;
		stArm7MovingY.bArm6 = false;
		stArm7MovingY.bArm7 = false;
		stArm7MovingY.bArm8 = false;
		
		stArm7MovingY.bRestrictedArm1 = false;
		stArm7MovingY.bRestrictedArm2 = false;
		stArm7MovingY.bRestrictedArm3 = false;
		stArm7MovingY.bRestrictedArm4 = false;
		stArm7MovingY.bRestrictedArm5 = false;
		stArm7MovingY.bRestrictedArm6 = false;
		stArm7MovingY.bRestrictedArm7 = false;
		stArm7MovingY.bRestrictedArm8 = false;
		
		//Arm 7 Moving Z
		ArmstoMove stArm7MovingZ = new ArmstoMove ();
		stArm7MovingZ.bArm1 = false;
		stArm7MovingZ.bArm2 = false;
		stArm7MovingZ.bArm3 = false;
		stArm7MovingZ.bArm4 = false;
		stArm7MovingZ.bArm5 = false;
		stArm7MovingZ.bArm6 = false;
		stArm7MovingZ.bArm7 = false;
		stArm7MovingZ.bArm8 = false;
		
		stArm7MovingZ.bRestrictedArm1 = false;
		stArm7MovingZ.bRestrictedArm2 = false;
		stArm7MovingZ.bRestrictedArm3 = false;
		stArm7MovingZ.bRestrictedArm4 = false;
		stArm7MovingZ.bRestrictedArm5 = false;
		stArm7MovingZ.bRestrictedArm6 = false;
		stArm7MovingZ.bRestrictedArm7 = false;
		stArm7MovingZ.bRestrictedArm8 = false;
		
		//Arm 7 Moving XY
		ArmstoMove stArm7MovingXY = new ArmstoMove ();
		stArm7MovingXY.bArm1 = false;
		stArm7MovingXY.bArm2 = false;
		stArm7MovingXY.bArm3 = false;
		stArm7MovingXY.bArm4 = false;
		stArm7MovingXY.bArm5 = false;
		stArm7MovingXY.bArm6 = false;
		stArm7MovingXY.bArm7 = false;
		stArm7MovingXY.bArm8 = false;
		
		stArm7MovingXY.bRestrictedArm1 = false;
		stArm7MovingXY.bRestrictedArm2 = false;
		stArm7MovingXY.bRestrictedArm3 = false;
		stArm7MovingXY.bRestrictedArm4 = false;
		stArm7MovingXY.bRestrictedArm5 = false;
		stArm7MovingXY.bRestrictedArm6 = false;
		stArm7MovingXY.bRestrictedArm7 = false;
		stArm7MovingXY.bRestrictedArm8 = false;
		
		//Arm 7 Moving YZ
		ArmstoMove stArm7MovingYZ = new ArmstoMove ();
		stArm7MovingYZ.bArm1 = false;
		stArm7MovingYZ.bArm2 = false;
		stArm7MovingYZ.bArm3 = false;
		stArm7MovingYZ.bArm4 = false;
		stArm7MovingYZ.bArm5 = false;
		stArm7MovingYZ.bArm6 = false;
		stArm7MovingYZ.bArm7 = false;
		stArm7MovingYZ.bArm8 = false;
		
		stArm7MovingYZ.bRestrictedArm1 = false;
		stArm7MovingYZ.bRestrictedArm2 = false;
		stArm7MovingYZ.bRestrictedArm3 = false;
		stArm7MovingYZ.bRestrictedArm4 = false;
		stArm7MovingYZ.bRestrictedArm5 = false;
		stArm7MovingYZ.bRestrictedArm6 = false;
		stArm7MovingYZ.bRestrictedArm7 = false;
		stArm7MovingYZ.bRestrictedArm8 = false;
		
		//Arm 7 Moving ZX
		ArmstoMove stArm7MovingZX = new ArmstoMove ();
		stArm7MovingZX.bArm1 = false;
		stArm7MovingZX.bArm2 = false;
		stArm7MovingZX.bArm3 = false;
		stArm7MovingZX.bArm4 = false;
		stArm7MovingZX.bArm5 = false;
		stArm7MovingZX.bArm6 = false;
		stArm7MovingZX.bArm7 = false;
		stArm7MovingZX.bArm8 = false;
		
		stArm7MovingZX.bRestrictedArm1 = false;
		stArm7MovingZX.bRestrictedArm2 = false;
		stArm7MovingZX.bRestrictedArm3 = false;
		stArm7MovingZX.bRestrictedArm4 = false;
		stArm7MovingZX.bRestrictedArm5 = false;
		stArm7MovingZX.bRestrictedArm6 = false;
		stArm7MovingZX.bRestrictedArm7 = false;
		stArm7MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm7MovingX,stArm7MovingX);
		mapArmMovement.Add(eArmDirection.eArm7MovingY,stArm7MovingY);
		mapArmMovement.Add(eArmDirection.eArm7MovingZ,stArm7MovingZ);
		mapArmMovement.Add(eArmDirection.eArm7MovingXY,stArm7MovingXY);
		mapArmMovement.Add(eArmDirection.eArm7MovingYZ,stArm7MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm7MovingZX,stArm7MovingZX);
		
		//-------------------------------------------------------------------------------------
		
		
		
		//---------------------------- Sub Arm 8-----------------------------------------------
		
		//Arm 8 Moving X
		ArmstoMove stArm8MovingX = new ArmstoMove ();
		stArm8MovingX.bArm1 = false;
		stArm8MovingX.bArm2 = false;
		stArm8MovingX.bArm3 = false;
		stArm8MovingX.bArm4 = false;
		stArm8MovingX.bArm5 = false;
		stArm8MovingX.bArm6 = false;
		stArm8MovingX.bArm7 = false;
		stArm8MovingX.bArm8 = true;
		
		stArm8MovingX.bRestrictedArm1 = false;
		stArm8MovingX.bRestrictedArm2 = false;
		stArm8MovingX.bRestrictedArm3 = false;
		stArm8MovingX.bRestrictedArm4 = false;
		stArm8MovingX.bRestrictedArm5 = false;
		stArm8MovingX.bRestrictedArm6 = false;
		stArm8MovingX.bRestrictedArm7 = false;
		stArm8MovingX.bRestrictedArm8 = false;
		
		
		//Arm 8 Moving Y
		ArmstoMove stArm8MovingY = new ArmstoMove ();
		stArm8MovingY.bArm1 = false;
		stArm8MovingY.bArm2 = false;
		stArm8MovingY.bArm3 = false;
		stArm8MovingY.bArm4 = false;
		stArm8MovingY.bArm5 = false;
		stArm8MovingY.bArm6 = false;
		stArm8MovingY.bArm7 = false;
		stArm8MovingY.bArm8 = false;
		
		stArm8MovingY.bRestrictedArm1 = false;
		stArm8MovingY.bRestrictedArm2 = false;
		stArm8MovingY.bRestrictedArm3 = false;
		stArm8MovingY.bRestrictedArm4 = false;
		stArm8MovingY.bRestrictedArm5 = false;
		stArm8MovingY.bRestrictedArm6 = false;
		stArm8MovingY.bRestrictedArm7 = false;
		stArm8MovingY.bRestrictedArm8 = false;
		
		//Arm 8 Moving Z
		ArmstoMove stArm8MovingZ = new ArmstoMove ();
		stArm8MovingZ.bArm1 = false;
		stArm8MovingZ.bArm2 = false;
		stArm8MovingZ.bArm3 = false;
		stArm8MovingZ.bArm4 = false;
		stArm8MovingZ.bArm5 = false;
		stArm8MovingZ.bArm6 = false;
		stArm8MovingZ.bArm7 = false;
		stArm8MovingZ.bArm8 = false;
		
		stArm8MovingZ.bRestrictedArm1 = false;
		stArm8MovingZ.bRestrictedArm2 = false;
		stArm8MovingZ.bRestrictedArm3 = false;
		stArm8MovingZ.bRestrictedArm4 = false;
		stArm8MovingZ.bRestrictedArm5 = false;
		stArm8MovingZ.bRestrictedArm6 = false;
		stArm8MovingZ.bRestrictedArm7 = false;
		stArm8MovingZ.bRestrictedArm8 = false;
		
		//Arm 8 Moving XY
		ArmstoMove stArm8MovingXY = new ArmstoMove ();
		stArm8MovingXY.bArm1 = false;
		stArm8MovingXY.bArm2 = false;
		stArm8MovingXY.bArm3 = false;
		stArm8MovingXY.bArm4 = false;
		stArm8MovingXY.bArm5 = false;
		stArm8MovingXY.bArm6 = false;
		stArm8MovingXY.bArm7 = false;
		stArm8MovingXY.bArm8 = false;
		
		stArm8MovingXY.bRestrictedArm1 = false;
		stArm8MovingXY.bRestrictedArm2 = false;
		stArm8MovingXY.bRestrictedArm3 = false;
		stArm8MovingXY.bRestrictedArm4 = false;
		stArm8MovingXY.bRestrictedArm5 = false;
		stArm8MovingXY.bRestrictedArm6 = false;
		stArm8MovingXY.bRestrictedArm7 = false;
		stArm8MovingXY.bRestrictedArm8 = false;
		
		//Arm 8 Moving YZ
		ArmstoMove stArm8MovingYZ = new ArmstoMove ();
		stArm8MovingYZ.bArm1 = false;
		stArm8MovingYZ.bArm2 = false;
		stArm8MovingYZ.bArm3 = false;
		stArm8MovingYZ.bArm4 = false;
		stArm8MovingYZ.bArm5 = false;
		stArm8MovingYZ.bArm6 = false;
		stArm8MovingYZ.bArm7 = false;
		stArm8MovingYZ.bArm8 = false;
		
		stArm8MovingYZ.bRestrictedArm1 = false;
		stArm8MovingYZ.bRestrictedArm2 = false;
		stArm8MovingYZ.bRestrictedArm3 = false;
		stArm8MovingYZ.bRestrictedArm4 = false;
		stArm8MovingYZ.bRestrictedArm5 = false;
		stArm8MovingYZ.bRestrictedArm6 = false;
		stArm8MovingYZ.bRestrictedArm7 = false;
		stArm8MovingYZ.bRestrictedArm8 = false;
		
		//Arm 8 Moving ZX
		ArmstoMove stArm8MovingZX = new ArmstoMove ();
		stArm8MovingZX.bArm1 = false;
		stArm8MovingZX.bArm2 = false;
		stArm8MovingZX.bArm3 = false;
		stArm8MovingZX.bArm4 = false;
		stArm8MovingZX.bArm5 = false;
		stArm8MovingZX.bArm6 = false;
		stArm8MovingZX.bArm7 = false;
		stArm8MovingZX.bArm8 = true;
		
		stArm8MovingZX.bRestrictedArm1 = false;
		stArm8MovingZX.bRestrictedArm2 = false;
		stArm8MovingZX.bRestrictedArm3 = false;
		stArm8MovingZX.bRestrictedArm4 = false;
		stArm8MovingZX.bRestrictedArm5 = false;
		stArm8MovingZX.bRestrictedArm6 = false;
		stArm8MovingZX.bRestrictedArm7 = false;
		stArm8MovingZX.bRestrictedArm8 = false;
		
		//Prepare the dictionary
		mapArmMovement.Add(eArmDirection.eArm8MovingX,stArm8MovingX);
		mapArmMovement.Add(eArmDirection.eArm8MovingY,stArm8MovingY);
		mapArmMovement.Add(eArmDirection.eArm8MovingZ,stArm8MovingZ);
		mapArmMovement.Add(eArmDirection.eArm8MovingXY,stArm8MovingXY);
		mapArmMovement.Add(eArmDirection.eArm8MovingYZ,stArm8MovingYZ);
		mapArmMovement.Add(eArmDirection.eArm8MovingZX,stArm8MovingZX);
		
		//-------------------------------------------------------------------------------------
		
	}
	
	public string WiimoteName = "RightWiimote";	
	private GameObject collidedObject = null;
	private GameObject grabbedObject = null;
	List<GameObject> lstGameObjectsParents;
	List<GameObject> lstGameObjectsChild;
	private Transform parentObject = null;
	private Vector3 refPosition1 = new Vector3(0.0f,0.0f,0.0f);
	Vector3 DiffX;
	Vector3 DiffY;
	Vector3 DiffZ; 
	
	// Use this for initialization
	void Start () {
		print("Start");
		// We assume the attached GameObject has a collider so ensure the collider is trigger-based
		collider.isTrigger = true;
		
		// Turn off the object's physics by making it kinematic
		rigidbody.isKinematic = true;	
		
	}
	
	//Traverse for Child Objects
	void Traverse(GameObject obj) { 
		
		foreach (Transform child in obj.transform) 
		{ 
			Traverse(child.gameObject); 
			print("Child is " + child.gameObject.name);
			lstGameObjectsChild.Add(child.gameObject);
		}
	}
	
	//Grabbed object - setting the member variable if any object is grabbed
	void GrabbedObject(){
		
		// Check if no object is being collided and if no object is grabbed
		if (collidedObject == null && grabbedObject == null) 
		{
			// If A and B are pressed, treat the virtual hand as a fist by turning off the collider's trigger
			if (InputBroker.GetKeyDown (WiimoteName + ":A")) 
			{
				collider.isTrigger = false;
			}
			// Otherwise, ensure the collider is treated as a trigger
			else 
			{
				collider.isTrigger = true;
			}
		}
		// Check if an object is being collided (but no object is grabbed yet)
		else if (collidedObject != null && grabbedObject == null) 
		{
			// If A is pressed, grab the object
			if (InputBroker.GetKeyDown (WiimoteName + ":A")) 
			{
				//Set the grabbed object as the collided object
				grabbedObject = collidedObject;
				
				// Get All the parent object 
				parentObject = grabbedObject.transform;
				while(parentObject.transform.parent != null) {
					parentObject = parentObject.transform.parent;
					lstGameObjectsParents.Add(parentObject.gameObject);
					print ("parent is " +  parentObject.gameObject.name);
				}
				print("Parent :: Number of items in the list " + lstGameObjectsParents.Count);
				
				//Get all the child object
				Traverse(grabbedObject);			
				
				
				//set the present reference position
				refPosition1 = transform.position;
			}
		}
		// Check if an object is grabbed
		else if(grabbedObject != null) 
		{		
			// If A and B are NOT pressed, turn the object's physics back on and release it
			if(!InputBroker.GetKeyDown(WiimoteName + ":A") ) {
				grabbedObject = null;
			}
		}
	}
	float RobotArmRate = 0.0f;
	int directionControl = 1;
	
	//MoveArm1
	void MoveArm1(){
		eArmDirection findArmDirection = eArmDirection.eDefault;
		
		//Check if moving in X
		if(DiffX.x > 0.015 || DiffX.x < -0.015){
			print("Change in X");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm1MovingX;
			
			//Check if moving in Y
			if(DiffY.y > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm1MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in ZX");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm1MovingZX;
			}
			//if moving in negative x
			if(DiffX.x < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Y
		else if(DiffY.y > 0.015 || DiffY.y < -0.015){
			print ("DiffY.y " + DiffY.y);
			print("Change in Y");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm1MovingY;
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm1MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm1MovingYZ;
			}			
			
			//if moving in negative y
			if(DiffY.y < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Z
		else if(DiffZ.z > 0.015 || DiffZ.z < -0.015){
			print("Change in Z");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm1MovingZ;			
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm1MovingZX;
			}
			//Check if moving in y
			else if(DiffY.y > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm1MovingYZ;
			}
			
			//if moving in negative z
			if(DiffZ.z < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		else
		{
			return;
		}
		
		ArmstoMove value;
		//Get the structure to see the allowed motion
		mapArmMovement.TryGetValue (findArmDirection, out value);
		
		//Check all the movements allowed and its type
		if(value.bArm1){
			print("Arm 1 Allowed");
			RobotArmRate = 30.0f;
			if(currturnAngle1!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary1=false;
			}
			if( !reachedBoundary1 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary1=true;
				print ("CurrentAngle" + currturnAngle1);
			}

			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.x>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.x;
			
			currturnAngle1=-1*directionControl*RobotArmRate;
		}
		
		if(value.bArm2){
			print("Arm 2 Allowed");
			RobotArmRate = 240.0f;
			GameObject goarm2 = lstGameObjectsParents[0];
			//goarm2.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle2!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary2=false;
			}
			if( !reachedBoundary2 && ( -1*directionControl*RobotArmRate<80 || -1*directionControl*RobotArmRate>330))
			{
				goarm2.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary2=true;
				print ("CurrentAngle" + currturnAngle2);
			}

			if((GameObject.Find(goarm2.name).transform.localEulerAngles.x<80)||
			   (GameObject.Find(goarm2.name).transform.localEulerAngles.x>330))
			{
				goarm2.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm2.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(goarm2.name).transform.localEulerAngles.x;
			
			currturnAngle2=-1*directionControl*RobotArmRate;
		}
		
		if(value.bArm3){
			print("Arm 3 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm3 = lstGameObjectsParents[1];
			//goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle3!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary3=false;
			}
			if( !reachedBoundary3 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary3=true;
				print ("CurrentAngle" + currturnAngle3);
			}

			if((GameObject.Find(goarm3.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(goarm3.name).transform.localEulerAngles.x>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm3.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(goarm3.name).transform.localEulerAngles.x;
			
			currturnAngle3=-1*directionControl*RobotArmRate;
		}
		
		if(value.bArm4){
			print("Arm 4 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm4 = lstGameObjectsParents[2];
			//goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}

			if((GameObject.Find(goarm4.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm4.name).transform.localEulerAngles.z>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm4.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm4.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bArm5){
			print("Arm 5 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[3];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}

			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bArm6){
			print("Arm 6 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[4];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}

			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm1){
			print("Arm 1 Allowed With Restriction");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle1!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary1=false;
			}
			if( !reachedBoundary1 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary1=true;
				print ("CurrentAngle" + currturnAngle1);
			}

			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.x>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.x;
			
			currturnAngle1=-1*directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm2){
			print("Arm 2 Allowed With Restriction");
			RobotArmRate = 240.0f;
			GameObject goarm2 = lstGameObjectsParents[0];
			//goarm2.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle2!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary2=false;
			}
			if( !reachedBoundary2 && ( -1*directionControl*RobotArmRate<80 || -1*directionControl*RobotArmRate>330))
			{
				goarm2.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary2=true;
				print ("CurrentAngle" + currturnAngle2);
			}

			if((GameObject.Find(goarm2.name).transform.localEulerAngles.x<80)||
			   (GameObject.Find(goarm2.name).transform.localEulerAngles.x>330))
			{
				goarm2.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm2.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(goarm2.name).transform.localEulerAngles.x;
			
			currturnAngle2=-1*directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm3){
			print("Arm 3 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm3 = lstGameObjectsParents[1];
			//goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle3!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary3=false;
			}
			if( !reachedBoundary3 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary3=true;
				print ("CurrentAngle" + currturnAngle3);
			}

			if((GameObject.Find(goarm3.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(goarm3.name).transform.localEulerAngles.x>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm3.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(goarm3.name).transform.localEulerAngles.x;
			
			currturnAngle3=-1*directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm4){
			print("Arm 4 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm4 = lstGameObjectsParents[2];
			//goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}

			if((GameObject.Find(goarm4.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm4.name).transform.localEulerAngles.z>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm4.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm4.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm5){
			print("Arm 5 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[3];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}

			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm6){
			print("Arm 6 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[4];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}

			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
	}
	private bool reachedBoundary1=false;
	private bool reachedBoundary2=false;
	private bool reachedBoundary3=false;
	private bool reachedBoundary4=false;
	private bool reachedBoundary5=false;
	private bool reachedBoundary6=false;
	private float currturnAngle1=0;
	private float currturnAngle2=0;
	private float currturnAngle3=0;
	private float currturnAngle4=0;
	private float currturnAngle5=0;
	private float currturnAngle6=0;
	//MoveArm2
	void MoveArm2(){
		
		eArmDirection findArmDirection = eArmDirection.eDefault;
		
		//Check if moving in X
		if(DiffX.x > 0.015 || DiffX.x < -0.015){
			print("Change in X");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm2MovingX;
			
			//Check if moving in Y
			if(DiffY.y > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm2MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in ZX");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm2MovingZX;
			}
			//if moving in negative x
			if(DiffX.x < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Y
		else if(DiffY.y > 0.015 || DiffY.y < -0.015){
			print ("DiffY.y " + DiffY.y);
			print("Change in Y");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm2MovingY;
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm2MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm2MovingYZ;
			}			
			
			//if moving in negative y
			if(DiffY.y < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Z
		else if(DiffZ.z > 0.015 || DiffZ.z < -0.015){
			print("Change in Z");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm2MovingZ;			
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm2MovingZX;
			}
			//Check if moving in y
			else if(DiffY.y > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm2MovingYZ;
			}
			
			//if moving in negative z
			if(DiffZ.z < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		else
		{
			return;
		}
		
		ArmstoMove value;
		//Get the structure to see the allowed motion
		mapArmMovement.TryGetValue (findArmDirection, out value);
		
		//Check all the movements allowed and its type
		if(value.bArm1){
			print("Arm 1 Allowed");
			//Never Child is allowed present assumption
		}
		
		if(value.bArm2){
			print("Arm 2 Allowed");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle2!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary2=false;
			}
			if( !reachedBoundary2 && ( -1*directionControl*RobotArmRate<80 || -1*directionControl*RobotArmRate>330))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary2=true;
				print ("CurrentAngle" + currturnAngle2);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.x<80)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.x>330))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.x;
			
			currturnAngle2=-1*directionControl*RobotArmRate;
		}
		
		if(value.bArm3){
			print("Arm 3 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm3 = lstGameObjectsParents[0];
			//goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle3!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary3=false;
			}
			if( !reachedBoundary3 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary3=true;
				print ("CurrentAngle" + currturnAngle3);
			}
			
			if((GameObject.Find(goarm3.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(goarm3.name).transform.localEulerAngles.x>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm3.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(goarm3.name).transform.localEulerAngles.x;
			
			currturnAngle3=-1*directionControl*RobotArmRate;
		}
		
		if(value.bArm4){
			print("Arm 4 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm4 = lstGameObjectsParents[1];
			//goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}
			
			if((GameObject.Find(goarm4.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm4.name).transform.localEulerAngles.z>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm4.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm4.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bArm5){
			print("Arm 5 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[2];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bArm6){
			print("Arm 6 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[3];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm1){
			print("Arm 1 Allowed With Restriction");
			
		}
		
		if(value.bRestrictedArm2){
			print("Arm 2 Allowed With Restriction");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle2!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary2=false;
			}
			if( !reachedBoundary2 && ( -1*directionControl*RobotArmRate<80 || -1*directionControl*RobotArmRate>330))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary2=true;
				print ("CurrentAngle" + currturnAngle2);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.x<80)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.x>330))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.x;
			
			currturnAngle2=-1*directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm3){
			print("Arm 3 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm3 = lstGameObjectsParents[0];
			//goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle3!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary3=false;
			}
			if( !reachedBoundary3 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary3=true;
				print ("CurrentAngle" + currturnAngle3);
			}
			
			if((GameObject.Find(goarm3.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(goarm3.name).transform.localEulerAngles.x>300))
			{
				goarm3.transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm3.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(goarm3.name).transform.localEulerAngles.x;
			
			currturnAngle3=-1*directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm4){
			print("Arm 4 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm4 = lstGameObjectsParents[1];
			//goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}
			
			if((GameObject.Find(goarm4.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm4.name).transform.localEulerAngles.z>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm4.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm4.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm5){
			print("Arm 5 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[2];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm6){
			print("Arm 6 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[3];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
	}
	
	//MoveArm3
	void MoveArm3(){
		
		eArmDirection findArmDirection = eArmDirection.eDefault;
		
		//Check if moving in X
		if(DiffX.x > 0.015 || DiffX.x < -0.015){
			print("Change in X");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm3MovingX;
			
			//Check if moving in Y
			if(DiffY.y > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm3MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in ZX");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm3MovingZX;
			}
			//if moving in negative x
			if(DiffX.x < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Y
		else if(DiffY.y > 0.015 || DiffY.y < -0.015){
			print ("DiffY.y " + DiffY.y);
			print("Change in Y");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm3MovingY;
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm3MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm3MovingYZ;
			}			
			
			//if moving in negative y
			if(DiffY.y < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Z
		else if(DiffZ.z > 0.015 || DiffZ.z < -0.015){
			print("Change in Z");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm3MovingZ;			
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm3MovingZX;
			}
			//Check if moving in y
			else if(DiffY.y > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm3MovingYZ;
			}
			
			//if moving in negative z
			if(DiffZ.z < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		else
		{
			return;
		}
		
		ArmstoMove value;
		//Get the structure to see the allowed motion
		mapArmMovement.TryGetValue (findArmDirection, out value);
		
		//Check all the movements allowed and its type
		if(value.bArm1){
			print("Arm 1 Allowed");
		}
		
		if(value.bArm2){
			print("Arm 2 Allowed");
		}
		
		if(value.bArm3){
			print("Arm 3 Allowed");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle3!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary3=false;
			}
			if( !reachedBoundary3 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary3=true;
				print ("CurrentAngle" + currturnAngle3);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.x>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.x;
			
			currturnAngle3=-1*directionControl*RobotArmRate;
		}
		
		if(value.bArm4){
			print("Arm 4 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm4 = lstGameObjectsParents[0];
			//goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}
			
			if((GameObject.Find(goarm4.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm4.name).transform.localEulerAngles.z>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm4.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm4.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;

		}
		
		if(value.bArm5){
			print("Arm 5 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[1];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bArm6){
			print("Arm 6 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[2];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm1){
			print("Arm 1 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm2){
			print("Arm 2 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm3){
			print("Arm 3 Allowed With Restriction");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
			if(currturnAngle3!= -1*directionControl*RobotArmRate)
			{
				reachedBoundary3=false;
			}
			if( !reachedBoundary3 && ( -1*directionControl*RobotArmRate<70 || -1*directionControl*RobotArmRate>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				reachedBoundary3=true;
				print ("CurrentAngle" + currturnAngle3);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.x<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.x>300))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (-1*directionControl*RobotArmRate * Time.deltaTime,0, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.x);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.x;
			
			currturnAngle3=-1*directionControl*RobotArmRate;

		}
		
		if(value.bRestrictedArm4){
			print("Arm 4 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm4 = lstGameObjectsParents[0];
			//goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}
			
			if((GameObject.Find(goarm4.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm4.name).transform.localEulerAngles.z>350))
			{
				goarm4.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm4.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm4.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm5){
			print("Arm 5 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[1];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm6){
			print("Arm 6 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[2];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
	}
	
	//MoveArm4
	void MoveArm4(){
		
		eArmDirection findArmDirection = eArmDirection.eDefault;
		
		//Check if moving in X
		if(DiffX.x > 0.015 || DiffX.x < -0.015){
			print("Change in X");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm4MovingX;
			
			//Check if moving in Y
			if(DiffY.y > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm4MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in ZX");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm4MovingZX;
			}
			//if moving in negative x
			if(DiffX.x < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Y
		else if(DiffY.y > 0.015 || DiffY.y < -0.015){
			print ("DiffY.y " + DiffY.y);
			print("Change in Y");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm4MovingY;
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm4MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm4MovingYZ;
			}			
			
			//if moving in negative y
			if(DiffY.y < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Z
		else if(DiffZ.z > 0.015 || DiffZ.z < -0.015){
			print("Change in Z");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm4MovingZ;			
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm4MovingZX;
			}
			//Check if moving in y
			else if(DiffY.y > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm4MovingYZ;
			}
			
			//if moving in negative z
			if(DiffZ.z < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		else
		{
			return;
		}
		
		ArmstoMove value;
		//Get the structure to see the allowed motion
		mapArmMovement.TryGetValue (findArmDirection, out value);
		
		//Check all the movements allowed and its type
		if(value.bArm1){
			print("Arm 1 Allowed");
		}
		
		if(value.bArm2){
			print("Arm 2 Allowed");
		}
		
		if(value.bArm3){
			print("Arm 3 Allowed");
			RobotArmRate = 8.0f;
		}
		
		if(value.bArm4){
			print("Arm 4 Allowed");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.z>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bArm5){
			print("Arm 5 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[0];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bArm6){
			print("Arm 6 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[1];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm1){
			print("Arm 1 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm2){
			print("Arm 2 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm3){
			print("Arm 3 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm4){
			print("Arm 4 Allowed With Restriction");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle4!= directionControl*RobotArmRate)
			{
				reachedBoundary4=false;
			}
			if( !reachedBoundary4 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary4=true;
				print ("CurrentAngle" + currturnAngle4);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.z>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.z;			
			currturnAngle4=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm5){
			print("Arm 5 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm5 = lstGameObjectsParents[0];
			//goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(goarm5.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(goarm5.name).transform.localEulerAngles.z>350))
			{
				goarm5.transform.Rotate (0, 0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm5.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(goarm5.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm6){
			print("Arm 6 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[1];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
	}
	
	//MoveArm5
	void MoveArm5(){
		
		eArmDirection findArmDirection = eArmDirection.eDefault;
		
		//Check if moving in X
		if(DiffX.x > 0.015 || DiffX.x < -0.015){
			print("Change in X");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm5MovingX;
			
			//Check if moving in Y
			if(DiffY.y > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm5MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in ZX");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm5MovingZX;
			}
			//if moving in negative x
			if(DiffX.x < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Y
		else if(DiffY.y > 0.015 || DiffY.y < -0.015){
			print ("DiffY.y " + DiffY.y);
			print("Change in Y");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm5MovingY;
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm5MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm5MovingYZ;
			}			
			
			//if moving in negative y
			if(DiffY.y < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Z
		else if(DiffZ.z > 0.015 || DiffZ.z < -0.015){
			print("Change in Z");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm5MovingZ;			
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm5MovingZX;
			}
			//Check if moving in y
			else if(DiffY.y > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm5MovingYZ;
			}
			
			//if moving in negative z
			if(DiffZ.z < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		else
		{
			return;
		}
		
		ArmstoMove value;
		//Get the structure to see the allowed motion
		mapArmMovement.TryGetValue (findArmDirection, out value);
		
		//Check all the movements allowed and its type
		if(value.bArm1){
			print("Arm 1 Allowed");
		}
		
		if(value.bArm2){
			print("Arm 2 Allowed");
			RobotArmRate = 240.0f;
		}
		
		if(value.bArm3){
			print("Arm 3 Allowed");
		}
		
		if(value.bArm4){
			print("Arm 4 Allowed");
			RobotArmRate = 8.0f;
		}
		
		if(value.bArm5){
			print("Arm 5 Allowed");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.z>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bArm6){
			print("Arm 6 Allowed");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[0];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm1){
			print("Arm 1 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm2){
			print("Arm 2 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm3){
			print("Arm 3 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm4){
			print("Arm 4 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm5){
			print("Arm 5 Allowed With Restriction");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
			if(currturnAngle5!= directionControl*RobotArmRate)
			{
				reachedBoundary5=false;
			}
			if( !reachedBoundary5 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				reachedBoundary5=true;
				print ("CurrentAngle" + currturnAngle5);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.z<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.z>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,0,directionControl*RobotArmRate * Time.deltaTime);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.z);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.z;
			
			currturnAngle5=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm6){
			print("Arm 6 Allowed With Restriction");
			RobotArmRate = 8.0f;
			GameObject goarm6 = lstGameObjectsParents[1];
			//goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(goarm6.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(goarm6.name).transform.localEulerAngles.y>350))
			{
				goarm6.transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime, 0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(goarm6.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(goarm6.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
	}
	
	//MoveArm6
	void MoveArm6(){
		
		eArmDirection findArmDirection = eArmDirection.eDefault;
		
		//Check if moving in X
		if(DiffX.x > 0.015 || DiffX.x < -0.015){
			print("Change in X");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm6MovingX;
			
			//Check if moving in Y
			if(DiffY.y > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm6MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in ZX");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm6MovingZX;
			}
			//if moving in negative x
			if(DiffX.x < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Y
		else if(DiffY.y > 0.015 || DiffY.y < -0.015){
			print ("DiffY.y " + DiffY.y);
			print("Change in Y");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm6MovingY;
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XY");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm6MovingXY;
			}
			//Check if moving in Z
			else 
			if(DiffZ.z > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm6MovingYZ;
			}			
			
			//if moving in negative y
			if(DiffY.y < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		// Check if moving in Z
		else if(DiffZ.z > 0.015 || DiffZ.z < -0.015){
			print("Change in Z");
			//Assign the direction as observed
			findArmDirection = eArmDirection.eArm6MovingZ;			
			
			//Check if moving in X
			if(DiffX.x > 0.015){
				print("Change in XZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm6MovingZX;
			}
			//Check if moving in y
			else if(DiffY.y > 0.015){
				print("Change in YZ");
				//Assign the direction as observed
				findArmDirection = eArmDirection.eArm6MovingYZ;
			}
			
			//if moving in negative z
			if(DiffZ.z < -0.015){
				print("Direction Control Enabled");
				directionControl = -1;
			}
		}
		else
		{
			return;
		}
		
		ArmstoMove value;
		//Get the structure to see the allowed motion
		mapArmMovement.TryGetValue (findArmDirection, out value);
		
		//Check all the movements allowed and its type
		if(value.bArm1){
			print("Arm 1 Allowed");
		}
		
		if(value.bArm2){
			print("Arm 2 Allowed");
		}
		
		if(value.bArm3){
			print("Arm 3 Allowed");
		}
		
		if(value.bArm4){
			print("Arm 4 Allowed");
		}
		
		if(value.bArm5){
			print("Arm 5 Allowed");
		}
		
		if(value.bArm6){
			print("Arm 6 Allowed");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.y>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
		
		if(value.bRestrictedArm1){
			print("Arm 1 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm2){
			print("Arm 2 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm3){
			print("Arm 3 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm4){
			print("Arm 4 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm5){
			print("Arm 5 Allowed With Restriction");
		}
		
		if(value.bRestrictedArm6){
			print("Arm 6 Allowed With Restriction");
			RobotArmRate = 20.0f;
			//GameObject.Find(grabbedObject.name).transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
			if(currturnAngle6!= directionControl*RobotArmRate)
			{
				reachedBoundary6=false;
			}
			if( !reachedBoundary6 && ( directionControl*RobotArmRate<70 || directionControl*RobotArmRate>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
				reachedBoundary6=true;
				print ("CurrentAngle" + currturnAngle6);
			}
			
			if((GameObject.Find(grabbedObject.name).transform.localEulerAngles.y<70)||
			   (GameObject.Find(grabbedObject.name).transform.localEulerAngles.y>350))
			{
				GameObject.Find(grabbedObject.name).transform.Rotate (0,directionControl*RobotArmRate * Time.deltaTime,0);
				//rotated=true;
				print("Euler Angle :: " + GameObject.Find(grabbedObject.name).transform.localEulerAngles.y);
			}
			float currentAngle=GameObject.Find(grabbedObject.name).transform.localEulerAngles.y;
			
			currturnAngle6=directionControl*RobotArmRate;
		}
	}
	
	//MoveArm7
	void MoveArm7()
	{
	}
	
	//MoveArm8
	void MoveArm8(){
	}
	
	
	
	//ArmMovent
	void ArmMotionDirection(){

		//The movement will take place only if the movement is not null
		if(grabbedObject != null) {

			//Get the Details of the position of the arms
			DiffX = new Vector3 (0.0f, 0.0f, 0.0f);
			DiffY = new Vector3 (0.0f, 0.0f, 0.0f);
			DiffZ = new Vector3 (0.0f, 0.0f, 0.0f);
			DiffX.x = transform.position.x - refPosition1.x;
			DiffY.y = transform.position.y - refPosition1.y;
			DiffZ.z = transform.position.z - refPosition1.z;
			refPosition1 = transform.position;
			RobotArmRate = 0.0f;
			
			directionControl = 1;
			
			//Based on the grabbed sub arm call the corresponding arms
			//Sub Arm 1
			if(grabbedObject.name.Equals("ra11")||
			   grabbedObject.name.Equals("ra21")||
			   grabbedObject.name.Equals("ra31")||
			   grabbedObject.name.Equals("ra41"))
			{
				MoveArm1();
				//print ("Arm x " + GameObject.Find(grabbedObject.name).transform.eulerAngles.x);
				//print ("Arm y " + GameObject.Find(grabbedObject.name).transform.eulerAngles.y);
				//print ("Arm z " + GameObject.Find(grabbedObject.name).transform.eulerAngles.z);
			}
			
			//Sub Arm 2
			if(grabbedObject.name.Equals("ra12")||
			   grabbedObject.name.Equals("ra22")||
			   grabbedObject.name.Equals("ra32")||
			   grabbedObject.name.Equals("ra42"))
			{
				MoveArm2();
			}
			
			//Sub Arm 3
			if(grabbedObject.name.Equals("ra13")||
			   grabbedObject.name.Equals("ra23")||
			   grabbedObject.name.Equals("ra33")||
			   grabbedObject.name.Equals("ra43"))
			{
				MoveArm3();
			}
			
			//Sub Arm 4
			if(grabbedObject.name.Equals("ra14")||
			   grabbedObject.name.Equals("ra24")||
			   grabbedObject.name.Equals("ra34")||
			   grabbedObject.name.Equals("ra44"))
			{
				MoveArm4();
			}
			
			//Sub Arm 5
			if(grabbedObject.name.Equals("ra15")||
			   grabbedObject.name.Equals("ra25")||
			   grabbedObject.name.Equals("ra35")||
			   grabbedObject.name.Equals("ra45"))
			{
				MoveArm5();
			}
			
			//Sub Arm 6
			if(grabbedObject.name.Equals("ra16")||
			   grabbedObject.name.Equals("ra26")||
			   grabbedObject.name.Equals("ra36")||
			   grabbedObject.name.Equals("ra46"))
			{
				MoveArm6();
			}
			
			//Sub Arm 7
			if(grabbedObject.name.Equals("ra17")||
			   grabbedObject.name.Equals("ra27")||
			   grabbedObject.name.Equals("ra37")||
			   grabbedObject.name.Equals("ra47"))
			{
				MoveArm7();
			}
			
			//Sub Arm 8
			if(grabbedObject.name.Equals("ra18")||
			   grabbedObject.name.Equals("ra28")||
			   grabbedObject.name.Equals("ra38")||
			   grabbedObject.name.Equals("ra48"))
			{
				MoveArm8();
			}



		}
	}
	private bool bleftMove = false;
	private bool bdownMove = false;
	private bool bupMove = false;
	private bool brightMove = false;

	private bool bleftMoveMin = false;
	private bool bdownMoveMin = false;
	private bool bupMoveMax = false;
	private bool brightMoveMax = false;




	void setleftMoveMin ()
	{
		if(GameObject.Find("PatientCartBase").transform.position.x < 0.86f )
		{
			bleftMoveMin = true;	
		}
		else
		{
			bleftMoveMin = false;	
		}
	}
	void setdownMoveMin ()
	{
		if(GameObject.Find("PatientCartBase").transform.position.z < -1.55f )
		{
			bdownMoveMin = true;	
		}
		else
		{
			bdownMoveMin = false;	
		}
	}

	void setupMoveMax ()
	{
		if(GameObject.Find("PatientCartBase").transform.position.z > 2.05f )
		{
			bupMoveMax = true;	
		}
		else
		{
			bupMoveMax = false;	
		}
	}
	void setrightMoveMax()
	{
		if(GameObject.Find("PatientCartBase").transform.position.x > 1.55f )
		{
			brightMoveMax = true;	
		}
		else
		{
			brightMoveMax = false;	
		}
	}


	// Update is called once per frame
	void Update () {

		setleftMoveMin ();
		setdownMoveMin ();
		setupMoveMax ();
		setrightMoveMax();
		//Grabbed Object
		GrabbedObject();
		//ArmMovement
		ArmMotionDirection();

		//GrabTool
		GrabTool();

		leftMove ();
		downMove ();
		upMove ();
		rightMove();
	}

	private GameObject collidedObjectTool = null;
	private GameObject grabbedObjectTool = null;
	private Transform rootObjectTool = null;
	private Vector3 grabbedPositionTool;
	private Quaternion grabbedRotationTool;
	
	private GameObject toolObjectTool = null;
	private GameObject collidedArm = null;
	private Transform toolrootObjectTool = null;
	private bool bIsOrangeCubeAttached = false;
	private string armtobeattached;
	private string strInstrumentHolder;
	
	void GrabTool(){
		
		
		// Check if no object is being collided and if no object is grabbed
		if(collidedObjectTool == null && grabbedObjectTool == null) {
			// If A and B are pressed, treat the virtual hand as a fist by turning off the collider's trigger
			if(InputBroker.GetKeyDown(WiimoteName + ":A") && InputBroker.GetKeyDown(WiimoteName + ":B")) {
				collider.isTrigger = false;
			}
			// Otherwise, ensure the collider is treated as a trigger
			else {
				collider.isTrigger = true;
			}
		}
		
		// Check if an object is being collided (but no object is grabbed yet)
		else if(collidedObjectTool != null && grabbedObjectTool == null) {
			// If A and B are pressed, grab the object, turn off its physics, and add it to the virtual hand's empty parent
			if(InputBroker.GetKeyDown(WiimoteName + ":A") && InputBroker.GetKeyDown(WiimoteName + ":B")) {
				
				// Turn off physics by turning on kinematics
				grabbedObjectTool = collidedObjectTool;
				grabbedObjectTool.collider.isTrigger = true;
				grabbedObjectTool.rigidbody.isKinematic = true;
				
				// Find the root of the grabbed object (for hierarchical objects)
				if(!bIsOrangeCubeAttached){
					rootObjectTool = grabbedObjectTool.transform;
					/*while(rootObjectTool.transform.parent != null) {
						rootObjectTool = rootObjectTool.transform.parent;
					}*/
				}
				if(bIsOrangeCubeAttached){
					rootObjectTool = grabbedObjectTool.transform;
				}
				
				// Move the root of the grabbed object under the virtual hand's parent
				rootObjectTool.parent = transform.parent;
				
				// Determine the root's initial position and rotation relative to the virtual hand's parent				
				//grabbedPositionTool = rootObjectTool.localPosition;
				//grabbedRotationTool = rootObjectTool.localRotation;
				
				collider.isTrigger = true;
			}
		}
		// Check if an object is grabbed
		else if(grabbedObjectTool != null) {
			// Update the root's position and rotation relative to the virtual hand's parent
			//rootObjectTool.localPosition = grabbedPositionTool;
			//rootObjectTool.localRotation = grabbedRotationTool;
			print ("Tool x " + collidedObjectTool.transform.eulerAngles.x);
			print ("Tool y " + collidedObjectTool.transform.eulerAngles.y);
			print ("Tool z " + collidedObjectTool.transform.eulerAngles.z);
			// If A and B are NOT pressed, turn the object's physics back on and release it
			if(!InputBroker.GetKeyDown(WiimoteName + ":A") || !InputBroker.GetKeyDown(WiimoteName + ":B")) {
				grabbedObjectTool.collider.isTrigger = false;
				grabbedObjectTool.rigidbody.isKinematic = false;
				rootObjectTool.parent = null;
				grabbedObjectTool = null;
			}
		}
	}
	
	void AttachTool(){
		// Check if no object is being collided and if no object is grabbed
		if(grabbedObjectTool != null) {
			if((grabbedObjectTool.transform.eulerAngles.x <= 16.0 && grabbedObjectTool.transform.eulerAngles.x >= 0.0)
			   ||(grabbedObjectTool.transform.eulerAngles.x <= 360.0 && grabbedObjectTool.transform.eulerAngles.x >= 346.0)){
				toolObjectTool = grabbedObjectTool;
				toolObjectTool.rigidbody.isKinematic = true;
				toolObjectTool.collider.isTrigger = true;
				collidedObjectTool = null;
				rootObjectTool.parent = null;
				grabbedObjectTool = null;
				collider.isTrigger = true;
				print ("Tool x " + toolObjectTool.transform.eulerAngles.x);
				print ("Tool y " + toolObjectTool.transform.eulerAngles.y);
				print ("Tool z " + toolObjectTool.transform.eulerAngles.z);
				print ("Arm x " + GameObject.Find(armtobeattached).transform.eulerAngles.x);
				print ("Arm y " + GameObject.Find(armtobeattached).transform.eulerAngles.y);
				print ("Arm z " + GameObject.Find(armtobeattached).transform.eulerAngles.z);
				
				toolObjectTool.transform.rotation = Quaternion.Euler((GameObject.Find(armtobeattached).transform.eulerAngles.x)+180.0f,
				                                                     (GameObject.Find(armtobeattached).transform.eulerAngles.y),
				                                                     (GameObject.Find(armtobeattached).transform.eulerAngles.z));
				toolObjectTool.transform.position = new Vector3(GameObject.Find(strInstrumentHolder).transform.position.x,
				                                                GameObject.Find(strInstrumentHolder).transform.position.y,
				                                                GameObject.Find(strInstrumentHolder).transform.position.z);
				toolObjectTool.transform.parent = GameObject.Find(armtobeattached).transform;
				if(toolObjectTool.name.Equals("Scissor1")||
				   toolObjectTool.name.Equals("Scissor2")||
				   toolObjectTool.name.Equals("Endoscope2")||
				   toolObjectTool.name.Equals("Endoscope")||
				   toolObjectTool.name.Equals("Twizzer")||
				   toolObjectTool.name.Equals("Twizzer1")){
					print(toolObjectTool.name + " is attached");
					bIsOrangeCubeAttached = true;
				}
			}
		}
	}
	void leftMove(){
		if(bleftMove)
		{
			if(!bleftMoveMin){
				if (InputBroker.GetKeyDown (WiimoteName + ":Plus")) {
					print ("Moving Left");
					GameObject.Find("PatientCartBase").transform.Translate(-1* Time.deltaTime * 5,0,0);					
				}
			}
		}
	}

	void rightMove(){
		if(brightMove)
		{
			if(!brightMoveMax)
			{
				if (InputBroker.GetKeyDown (WiimoteName + ":Plus")) {
				print ("Moving Right");
					GameObject.Find("PatientCartBase").transform.Translate(Time.deltaTime * 5,0,0);
					//GameObject.Find("PatientCartBase").transform.position.x +=  transform.right * 5 * Time.deltaTime; 
				
				}
			}
		}		
	}

	void upMove(){
		if(bupMove)
		{
			if(!bupMoveMax)
			{
				if (InputBroker.GetKeyDown (WiimoteName + ":Plus")) {
				print ("Moving Up");
				GameObject.Find("PatientCartBase").transform.Translate(0,0,Time.deltaTime * 5);
				//GameObject.Find("PatientCartBase").transform.position.z +=  transform.forward * 5 * Time.deltaTime; 
				
				}
			}
		}
		
	}

	void downMove(){

		if(bdownMove)
		{
			if(!bdownMoveMin)
			{
				if (InputBroker.GetKeyDown (WiimoteName + ":Plus")) {
				print ("Moving down");
				GameObject.Find("PatientCartBase").transform.Translate(0,0,-1*Time.deltaTime * 5);
				//GameObject.Find("PatientCartBase").transform.position.z += -1* transform.forward * 5 * Time.deltaTime; 
			
				}
			}
		}
		
	}


	// Trigger function for collisions
	void OnTriggerEnter(Collider other) {
		// If an object is not already grabbed, check for collisions with another
		if(other.gameObject.name.Equals("left")){
			print("Collidede with left");
			bleftMove = true;
			
		}
		
		if(other.gameObject.name.Equals("right")){
			print("Collidede with right");
			brightMove = true;
			
		}
		
		if(other.gameObject.name.Equals("up")){
			print("Collidede with up");
			bupMove = true;
			
		}
		
		if(other.gameObject.name.Equals("down")){
			print("Collidede with down");
			bdownMove = true;
			
		}

		if(grabbedObject == null) {
			collidedObject = other.gameObject;
			print("Collison Occured");
			print(collidedObject.name);
		}



		// If an object is not already grabbed, check for collisions with another
		if(grabbedObjectTool == null) {
			if(other.gameObject.name.Equals("Scissor1")||
			   other.gameObject.name.Equals("Scissor2")||
			   other.gameObject.name.Equals("Endoscope2")||
			   other.gameObject.name.Equals("Endoscope")||
			   other.gameObject.name.Equals("Twizzer")||
			   other.gameObject.name.Equals("Twizzer1")
			   ){
				print("Collidede with Arm 1");
				collidedObjectTool = other.gameObject;

			}
		}else{
			
			if(other.gameObject.name.Equals("ra11")||
			   other.gameObject.name.Equals("ra21")||
			   other.gameObject.name.Equals("ra31")||
			   other.gameObject.name.Equals("ra41")){
				print("Collided with " + other.gameObject.name);
				armtobeattached = other.gameObject.name;
				if(armtobeattached.Equals("ra11")){
					strInstrumentHolder = "InstrumentHolder1";
				}
				if(armtobeattached.Equals("ra21")){
					strInstrumentHolder = "InstrumentHolder2";
				}
				if(armtobeattached.Equals("ra31")){
					strInstrumentHolder = "InstrumentHolder3";
				}
				if(armtobeattached.Equals("ra41")){
					strInstrumentHolder = "InstrumentHolder4";
				}
				AttachTool();
			}
		}
	}
	
	// Trigger function for exiting collisions
	void OnTriggerExit(Collider other) {

		bleftMove = false;
		bdownMove = false;
		bupMove = false;
		brightMove = false;

		// If an object is not grabbed, forget the collided object
		if(grabbedObject == null) {
			lstGameObjectsParents.Clear();
			lstGameObjectsChild.Clear ();
			collidedObject = null;
		}

		// If an object is not grabbed, forget the collided object
		if(grabbedObjectTool == null) {
			collidedObjectTool = null;
		}
	}
}

