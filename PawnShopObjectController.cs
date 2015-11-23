using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;
using System.Collections.Generic;
using System.IO;

public class PawnShopObjectController : MonoBehaviour 
{
	//Enum of Objects to be searched
	enum PawnShopObjects
	{
		SNOWMAN,
		EYEBALL,
		LUNARLANDER,
		FISHINGBOAT,
		
		MAGICLAMP,
		SNOWFLAKE,
		STAR,
		REDDRAGON,
		
		CANDYCANE,
		SPORTSCAR,
		SANTACAP,
		GIFTBOX
	};

	//Wiimote Name
	public string WiimoteName = "RightWiimote";	

	//File to write data
	StreamWriter Writer;
	
	//Correct Audio Source
	AudioSource correctAudio;
	
	//Error Audio
	AudioSource errorAudio;
	
	
	//Lights
	public GameObject Lights;
	
	
	//The Objects in the Scene
	public GameObject Snowman;
	public GameObject EyeBall;
	public GameObject LunarLander;
	public GameObject FishingBoat;
	
	public GameObject MagicLamp;
	public GameObject Snowflake;
	public GameObject Star;
	public GameObject RedDragon;
	
	public GameObject CandyCane;
	public GameObject SportsCar;
	public GameObject SantaCap;
	public GameObject GiftBox;
	
	//The Sphere Surrounding in the Scene
	public GameObject SphereSnowman;
	public GameObject SphereEyeBall;
	public GameObject SphereLunarLander;
	public GameObject SphereFishingBoat;
	
	public GameObject SphereMagicLamp;
	public GameObject SphereSnowflake;
	public GameObject SphereStar;
	public GameObject SphereRedDragon;
	
	public GameObject SphereCandyCane;
	public GameObject SphereSportsCar;
	public GameObject SphereSantaCap;
	public GameObject SphereGiftBox;
	
	//Vectors for all the game object from the User
	Vector3 VecSphereSnowman;
	Vector3 VecSphereEyeBall;
	Vector3 VecSphereLunarLander;
	Vector3 VecSphereFishingBoat;
	
	Vector3 VecSphereMagicLamp;
	Vector3 VecSphereSnowflake;
	Vector3 VecSphereStar;
	Vector3 VecSphereRedDragon;
	
	Vector3 VecSphereCandyCane;
	Vector3 VecSphereSportsCar;
	Vector3 VecSphereSantaCap;
	Vector3 VecSphereGiftBox;
	
	//Angle for all the game objects in the scene with the forward vector of the User
	double AngleSphereSnowman;
	double AngleSphereEyeBall;
	double AngleSphereLunarLander;
	double AngleSphereFishingBoat;
	
	double AngleSphereMagicLamp;
	double AngleSphereSnowflake;
	double AngleSphereStar;
	double AngleSphereRedDragon;
	
	double AngleSphereCandyCane;
	double AngleSphereSportsCar;
	double AngleSphereSantaCap;
	double AngleSphereGiftBox;
	
	//Active Status of desired objects
	bool IsSphereSnowmanActive = false;
	bool IsSphereEyeBallActive = false;
	bool IsSphereLunarLanderActive = false;
	bool IsSphereFishingBoatActive = false;
	
	bool IsSphereMagicLampActive = false;
	bool IsSphereSnowflakeActive = false;
	bool IsSphereStarActive = false;
	bool IsSphereRedDragonActive = false;
	
	bool IsSphereCandyCaneActive = false;
	bool IsSphereSportsCarActive = false;
	bool IsSphereSantaCapActive = false;
	bool IsSphereGiftBoxActive = false;
	
	//Status of setting desired objects
	bool SetSnowmanActive = false;
	bool SetEyeBallActive = false;
	bool SetLunarLanderActive = false;
	bool SetFishingBoatActive = false;
	
	bool SetMagicLampActive = false;
	bool SetSnowflakeActive = false;
	bool SetStarActive = false;
	bool SetRedDragonActive = false;
	
	bool SetCandyCaneActive = false;
	bool SetSportsCarActive = false;
	bool SetSantaCapActive = false;
	bool SetGiftBoxActive = false;
	
	//The Halo attached to the cubes
	Component HaloSnowman;
	Component HaloEyeBall;
	Component HaloLunarLander;
	Component HaloFishingBoat;
	
	Component HaloMagicLamp;
	Component HaloSnowflake;
	Component HaloStar;
	Component HaloRedDragon;
	
	Component HaloCandyCane;
	Component HaloSportsCar;
	Component HaloSantaCap;
	Component HaloGiftBox;
	
	//Stop Watch for the entire session
	Stopwatch StopwatchSession;
	
	//Stop Watch for the objects
	Stopwatch StopwatchSnowman;
	Stopwatch StopwatchEyeBall;
	Stopwatch StopwatchLunarLander;
	Stopwatch StopwatchFishingBoat;
	
	Stopwatch StopwatchMagicLamp;
	Stopwatch StopwatchSnowflake;
	Stopwatch StopwatchStar;
	Stopwatch StopwatchRedDragon;
	
	Stopwatch StopwatchCandyCane;
	Stopwatch StopwatchSportsCar;
	Stopwatch StopwatchSantaCap;
	Stopwatch StopwatchGiftBox;
	
	//The Ray Cast from the Camera to check if the object is not occluded
	RaycastHit HitSphereSnowman;
	RaycastHit HitSphereEyeBall;
	RaycastHit HitSphereLunarLander;
	RaycastHit HitSphereFishingBoat;
	
	RaycastHit HitSphereMagicLamp;
	RaycastHit HitSphereSnowflake;
	RaycastHit HitSphereStar;
	RaycastHit HitSphereRedDragon;
	
	RaycastHit HitSphereCandyCane;
	RaycastHit HitSphereSportsCar;
	RaycastHit HitSphereSantaCap;
	RaycastHit HitSphereGiftBox;
	
	//List of Objects
	List<PawnShopObjects> listPawnShopObjects;
	
	//Dictionary for mapping the the object to search enum and the corresponding set status
	Dictionary<PawnShopObjects,bool> ObjectSetDictionary;
	
	//Index
	int listindex = 0;
	
	//Error Count
	int TotalErrorCount = 0;
	
	//Error in each individual game object
	int ErrorCountSnowman = 0;
	int ErrorCountEyeBall = 0;
	int ErrorCountLunarLander = 0;
	int ErrorCountFishingBoat = 0;
	
	int ErrorCountMagicLamp = 0;
	int ErrorCountSnowflake = 0;
	int ErrorCountStar = 0;
	int ErrorCountRedDragon = 0;
	
	int ErrorCountCandyCane = 0;
	int ErrorCountSportsCar = 0;
	int ErrorCountSantaCap = 0;
	int ErrorCountGiftBox = 0;
	
	//Object to Search
	PawnShopObjects ObjecttoSearch;
	
	// Use this for initialization
	void Start () 
	{
		
		//File Name
		String FileName = "HeadBasedRenderingStudy_6DA_" + System.DateTime.Now.ToString ("MM_dd_yyyy") + "_" + System.DateTime.Now.ToString ("hh_mm_ss")+".txt";

		//Initialize the Stremwriter
		Writer = new StreamWriter(FileName);
		
		//Get all the audio sources attached to the gameobject
		AudioSource[] audios = GetComponents<AudioSource>();
		
		//Play the first audio source
		errorAudio = audios[1];
		
		//Play the second audio source
		correctAudio = audios[0];
		
		//Initialize the list
		listPawnShopObjects = new List<PawnShopObjects>();
		
		//Initialize the Dictionary
		ObjectSetDictionary = new Dictionary<PawnShopObjects,bool>();
		
		//Add the dictionary
		ObjectSetDictionary.Add(PawnShopObjects.CANDYCANE,SetCandyCaneActive);
		ObjectSetDictionary.Add(PawnShopObjects.EYEBALL,SetEyeBallActive);
		ObjectSetDictionary.Add(PawnShopObjects.FISHINGBOAT,SetFishingBoatActive);
		ObjectSetDictionary.Add(PawnShopObjects.LUNARLANDER,SetLunarLanderActive);
		
		ObjectSetDictionary.Add(PawnShopObjects.MAGICLAMP,SetMagicLampActive);
		ObjectSetDictionary.Add(PawnShopObjects.GIFTBOX,SetGiftBoxActive);
		ObjectSetDictionary.Add(PawnShopObjects.REDDRAGON,SetRedDragonActive);
		ObjectSetDictionary.Add(PawnShopObjects.SANTACAP,SetSantaCapActive);
		
		ObjectSetDictionary.Add(PawnShopObjects.SNOWFLAKE,SetSnowflakeActive);
		ObjectSetDictionary.Add(PawnShopObjects.SNOWMAN,SetSnowmanActive);
		ObjectSetDictionary.Add(PawnShopObjects.SPORTSCAR,SetSportsCarActive);
		ObjectSetDictionary.Add(PawnShopObjects.STAR,SetStarActive);
		
		
		//Add items in to the list Sequence A
		listPawnShopObjects.Add (PawnShopObjects.FISHINGBOAT);
		listPawnShopObjects.Add (PawnShopObjects.STAR);
		listPawnShopObjects.Add (PawnShopObjects.SPORTSCAR);
		listPawnShopObjects.Add (PawnShopObjects.EYEBALL);

		listPawnShopObjects.Add (PawnShopObjects.LUNARLANDER);
		listPawnShopObjects.Add (PawnShopObjects.CANDYCANE);
		listPawnShopObjects.Add (PawnShopObjects.SNOWFLAKE);
		listPawnShopObjects.Add (PawnShopObjects.SNOWMAN);

		listPawnShopObjects.Add (PawnShopObjects.GIFTBOX);
		listPawnShopObjects.Add (PawnShopObjects.REDDRAGON);
		listPawnShopObjects.Add (PawnShopObjects.SANTACAP);
		listPawnShopObjects.Add (PawnShopObjects.MAGICLAMP);



		


		
		//Get the Halo Component from the object in the pawn shop environment
		HaloSnowman = Snowman.GetComponent ("Halo");
		HaloEyeBall = EyeBall.GetComponent ("Halo");
		HaloLunarLander = LunarLander.GetComponent ("Halo");
		HaloFishingBoat = FishingBoat.GetComponent ("Halo");
		
		HaloMagicLamp = MagicLamp.GetComponent ("Halo");
		HaloSnowflake = Snowflake.GetComponent ("Halo");
		HaloStar = Star.GetComponent ("Halo");
		HaloRedDragon = RedDragon.GetComponent ("Halo");
		
		HaloCandyCane = CandyCane.GetComponent ("Halo");
		HaloSportsCar = SportsCar.GetComponent ("Halo");
		HaloSantaCap = SantaCap.GetComponent ("Halo");
		HaloGiftBox = GiftBox.GetComponent ("Halo");
		
		//Initialize Stop Watch for the entire sesssion and the objects
		StopwatchSession = new Stopwatch();
		StopwatchSnowman = new Stopwatch();
		StopwatchEyeBall = new Stopwatch();
		StopwatchLunarLander = new Stopwatch();
		StopwatchFishingBoat = new Stopwatch();
		
		StopwatchMagicLamp = new Stopwatch();
		StopwatchSnowflake = new Stopwatch();
		StopwatchStar = new Stopwatch();
		StopwatchRedDragon = new Stopwatch();
		
		StopwatchCandyCane = new Stopwatch();
		StopwatchSportsCar = new Stopwatch();
		StopwatchSantaCap = new Stopwatch();
		StopwatchGiftBox = new Stopwatch();
		
	}

	//Bool to start the Experiment
	bool StartApplication = false;

	// Update is called once per frame
	void Update () 
	{
		//Start the study once the user presses the A button
		if(!StartApplication)
		{
			if(InputBroker.GetKeyPress(WiimoteName + ":A"))
			{
				StartApplication = true;
			}
			if(InputBroker.GetKeyPress(WiimoteName + ":B")){}
		}

		//Wait till StartApplication is true
		if(StartApplication)
		{
			//Select Object for searching
			SelectObject ();
			
			//Set the Object to Active or inactive state
			SetObjectState();
			
			//Calculate the Angle between the HMD forward vector and the Gameobjects
			CalculateAngle();
			
			//Check the Objects in the Field of View
			CheckObjectsinFOV();
		}

	}
	
	void OnDestroy()
	{
		//Log Error Count
		Writer.WriteLine("TotalErrorCount  " + TotalErrorCount.ToString());
		
		//Log Error in each individual game object
		Writer.WriteLine("ErrorCountSnowman  " + ErrorCountSnowman.ToString());
		Writer.WriteLine("ErrorCountEyeBall  " + ErrorCountEyeBall.ToString());
		Writer.WriteLine("ErrorCountLunarLander  " + ErrorCountLunarLander.ToString());
		Writer.WriteLine("ErrorCountFishingBoat  " + ErrorCountFishingBoat.ToString());
		
		Writer.WriteLine("ErrorCountMagicLamp  " + ErrorCountMagicLamp.ToString());
		Writer.WriteLine("ErrorCountSnowflake  " + ErrorCountSnowflake.ToString());
		Writer.WriteLine("ErrorCountStar  " + ErrorCountStar.ToString());
		Writer.WriteLine("ErrorCountRedDragon  " + ErrorCountRedDragon.ToString());
		
		Writer.WriteLine("ErrorCountCandyCane  " + ErrorCountCandyCane.ToString());
		Writer.WriteLine("ErrorCountSportsCar  " + ErrorCountSportsCar.ToString());
		Writer.WriteLine("ErrorCountSantaCap  " + ErrorCountSantaCap.ToString());
		Writer.WriteLine("ErrorCountGiftBox  " + ErrorCountGiftBox.ToString());
		
		//Close the File Writer
		Writer.Close ();
		
	}
	
	//Set the Object to Active or inactive state
	void SetObjectState()
	{
		//Create Halo and Emit Particles for Snowman and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.SNOWMAN])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = true;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, true, null);
			//Snowman.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchSnowman.Start();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for LunarLander and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.LUNARLANDER])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = true;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, true, null);
			//LunarLander.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchLunarLander.Start();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for EyeBall and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.EYEBALL])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = true;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, true, null);
			//EyeBall.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchEyeBall.Start();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for FishingBoat and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.FISHINGBOAT])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = true;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, true, null);
			//FishingBoat.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchFishingBoat.Start();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for MagicLamp and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.MAGICLAMP])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = true;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, true, null);
			//MagicLamp.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchMagicLamp.Start();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for Snowflake and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.SNOWFLAKE])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = true;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, true, null);
			//Snowflake.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchSnowflake.Start();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for CandyCane and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.CANDYCANE])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = true;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, true, null);
			//CandyCane.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchCandyCane.Start();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for Star and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.STAR])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = true;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, true, null);
			//Star.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchStar.Start();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for SportsCar and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.SPORTSCAR])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = true;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, true, null);
			//SportsCar.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchSportsCar.Start();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for RedDragon and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.REDDRAGON])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = true;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, true, null);
			//RedDragon.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchRedDragon.Start();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for SantaCap and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.SANTACAP])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = true;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, true, null);
			//SantaCap.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchSantaCap.Start();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
		}
		
		//Create Halo and Emit Particles for GiftBox and remove for all other objects
		if(ObjectSetDictionary[PawnShopObjects.GIFTBOX])
		{
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = true;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, true, null);
			//GiftBox.GetComponent<ParticleSystem>().Play();
			
			//If the list index is first then start the Session Watch
			if(1 == listindex)
			{
				//Start the Stop watch
				StopwatchSession.Start();
			}
			
			//Start the Stop Watch
			StopwatchGiftBox.Start();
		}
		
		//Remove highlight for all objects
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(StopwatchSnowman.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchSnowman.Stop();
				//Reset the Stopwatch
				StopwatchSnowman.Reset();
			}
			if(StopwatchEyeBall.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchEyeBall.Stop();
				//Reset the Stopwatch
				StopwatchEyeBall.Reset();
			}
			if(StopwatchLunarLander.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchLunarLander.Stop();
				//Reset the Stopwatch
				StopwatchLunarLander.Reset();
			}
			if(StopwatchFishingBoat.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchFishingBoat.Stop();
				//Reset the Stopwatch
				StopwatchFishingBoat.Reset();
			}
			
			if(StopwatchMagicLamp.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchMagicLamp.Stop();
				//Reset the Stopwatch
				StopwatchMagicLamp.Reset();
			}
			if(StopwatchSnowflake.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchSnowflake.Stop();
				//Reset the Stopwatch
				StopwatchSnowflake.Reset();
			}
			if(StopwatchStar.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchStar.Stop();
				//Reset the Stopwatch
				StopwatchStar.Reset();
			}
			if(StopwatchRedDragon.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchRedDragon.Stop();
				//Reset the Stopwatch
				StopwatchRedDragon.Reset();
			}
			
			if(StopwatchCandyCane.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchCandyCane.Stop();
				//Reset the Stopwatch
				StopwatchCandyCane.Reset();
			}
			if(StopwatchSportsCar.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchSportsCar.Stop();
				//Reset the Stopwatch
				StopwatchSportsCar.Reset();
			}
			if(StopwatchSantaCap.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchSantaCap.Stop();
				//Reset the Stopwatch
				StopwatchSantaCap.Reset();
			}
			if(StopwatchGiftBox.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchGiftBox.Stop();
				//Reset the Stopwatch
				StopwatchGiftBox.Reset();
			}
			if(StopwatchSession.IsRunning)
			{
				//Stop the Stop Watch 
				StopwatchSession.Stop();
				//Reset the Stopwatch
				StopwatchSession.Reset();
			}
			
			//Log Error Count
			Writer.WriteLine("TotalErrorCount  " + TotalErrorCount.ToString());
			
			//Log Error in each individual game object
			Writer.WriteLine("ErrorCountSnowman  " + ErrorCountSnowman.ToString());
			Writer.WriteLine("ErrorCountEyeBall  " + ErrorCountEyeBall.ToString());
			Writer.WriteLine("ErrorCountLunarLander  " + ErrorCountLunarLander.ToString());
			Writer.WriteLine("ErrorCountFishingBoat  " + ErrorCountFishingBoat.ToString());
			
			Writer.WriteLine("ErrorCountMagicLamp  " + ErrorCountMagicLamp.ToString());
			Writer.WriteLine("ErrorCountSnowflake  " + ErrorCountSnowflake.ToString());
			Writer.WriteLine("ErrorCountStar  " + ErrorCountStar.ToString());
			Writer.WriteLine("ErrorCountRedDragon  " + ErrorCountRedDragon.ToString());
			
			Writer.WriteLine("ErrorCountCandyCane  " + ErrorCountCandyCane.ToString());
			Writer.WriteLine("ErrorCountSportsCar  " + ErrorCountSportsCar.ToString());
			Writer.WriteLine("ErrorCountSantaCap  " + ErrorCountSantaCap.ToString());
			Writer.WriteLine("ErrorCountGiftBox  " + ErrorCountGiftBox.ToString());
			
			Writer.WriteLine("\n\n\n Next Session Data\n\n");
			
			//Reset Error in each individual game object
			ErrorCountSnowman = 0;
			ErrorCountEyeBall = 0;
			ErrorCountLunarLander = 0;
			ErrorCountFishingBoat = 0;
			
			ErrorCountMagicLamp = 0;
			ErrorCountSnowflake = 0;
			ErrorCountStar = 0;
			ErrorCountRedDragon = 0;
			
			ErrorCountCandyCane = 0;
			ErrorCountSportsCar = 0;
			ErrorCountSantaCap = 0;
			ErrorCountGiftBox = 0;
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.CANDYCANE] = false;
			ObjectSetDictionary[PawnShopObjects.EYEBALL] = false;
			ObjectSetDictionary[PawnShopObjects.FISHINGBOAT] = false;
			ObjectSetDictionary[PawnShopObjects.LUNARLANDER] = false;
			
			ObjectSetDictionary[PawnShopObjects.MAGICLAMP] = false;
			ObjectSetDictionary[PawnShopObjects.GIFTBOX] = false;
			ObjectSetDictionary[PawnShopObjects.REDDRAGON] = false;
			ObjectSetDictionary[PawnShopObjects.SANTACAP] = false;
			
			ObjectSetDictionary[PawnShopObjects.SNOWFLAKE] = false;
			ObjectSetDictionary[PawnShopObjects.SNOWMAN] = false;
			ObjectSetDictionary[PawnShopObjects.SPORTSCAR] = false;
			ObjectSetDictionary[PawnShopObjects.STAR] = false;
			
			//Reset the list
			listindex = 0;
			
			//Set the error count to 0
			TotalErrorCount = 0;
			
			//Set Status of desired objects
			IsSphereSnowmanActive = false;
			IsSphereEyeBallActive = false;
			IsSphereLunarLanderActive = false;
			IsSphereFishingBoatActive = false;
			
			IsSphereMagicLampActive = false;
			IsSphereSnowflakeActive = false;
			IsSphereStarActive = false;
			IsSphereRedDragonActive = false;
			
			IsSphereCandyCaneActive = false;
			IsSphereSportsCarActive = false;
			IsSphereSantaCapActive = false;
			IsSphereGiftBoxActive = false;
			
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
			
			
		}
	}
	
	//Function to Calculate the Angle between the HMD forward vector and the Gameobjects
	void CalculateAngle()
	{
		//Get the Vector from the individual object and the User position
		VecSphereSnowman = SphereSnowman.transform.position - transform.position;
		VecSphereEyeBall = SphereEyeBall.transform.position - transform.position;
		VecSphereLunarLander = SphereLunarLander.transform.position - transform.position;
		VecSphereFishingBoat = SphereFishingBoat.transform.position - transform.position;
		
		VecSphereMagicLamp = SphereMagicLamp.transform.position - transform.position;
		VecSphereSnowflake = SphereSnowflake.transform.position - transform.position;
		VecSphereStar = SphereStar.transform.position - transform.position;
		VecSphereRedDragon = SphereRedDragon.transform.position - transform.position;
		
		VecSphereCandyCane = SphereCandyCane.transform.position - transform.position;
		VecSphereSportsCar = SphereSportsCar.transform.position - transform.position;
		VecSphereSantaCap = SphereSantaCap.transform.position - transform.position;
		VecSphereGiftBox = SphereGiftBox.transform.position - transform.position;
		
		
		
		//Calculate the angle between the forward vector of user and individual objects
		AngleSphereSnowman = Vector3.Angle (transform.forward, VecSphereSnowman);
		AngleSphereEyeBall = Vector3.Angle (transform.forward, VecSphereEyeBall);
		AngleSphereLunarLander = Vector3.Angle (transform.forward, VecSphereLunarLander);
		AngleSphereFishingBoat = Vector3.Angle (transform.forward, VecSphereFishingBoat);
		
		AngleSphereMagicLamp = Vector3.Angle (transform.forward, VecSphereMagicLamp);
		AngleSphereSnowflake = Vector3.Angle (transform.forward, VecSphereSnowflake);
		AngleSphereStar = Vector3.Angle (transform.forward, VecSphereStar);
		AngleSphereRedDragon = Vector3.Angle (transform.forward, VecSphereRedDragon);
		
		AngleSphereCandyCane = Vector3.Angle (transform.forward, VecSphereCandyCane);
		AngleSphereSportsCar = Vector3.Angle (transform.forward, VecSphereSportsCar);
		AngleSphereSantaCap = Vector3.Angle (transform.forward, VecSphereSantaCap);
		AngleSphereGiftBox = Vector3.Angle (transform.forward, VecSphereGiftBox);
		
		//RayCast from the Camera to get the RaycastHit
		Physics.Raycast (transform.position, VecSphereSnowman, out HitSphereSnowman);
		Physics.Raycast (transform.position, VecSphereEyeBall, out HitSphereEyeBall);
		Physics.Raycast (transform.position, VecSphereLunarLander, out HitSphereLunarLander);
		Physics.Raycast (transform.position, VecSphereFishingBoat, out HitSphereFishingBoat);
		
		Physics.Raycast (transform.position, VecSphereMagicLamp, out HitSphereMagicLamp);
		Physics.Raycast (transform.position, VecSphereSnowflake, out HitSphereSnowflake);
		Physics.Raycast (transform.position, VecSphereStar, out HitSphereStar);
		Physics.Raycast (transform.position, VecSphereRedDragon, out HitSphereRedDragon);
		
		Physics.Raycast (transform.position, VecSphereCandyCane, out HitSphereCandyCane);
		Physics.Raycast (transform.position, VecSphereSportsCar, out HitSphereSportsCar);
		Physics.Raycast (transform.position, VecSphereSantaCap, out HitSphereSantaCap);
		Physics.Raycast (transform.position, VecSphereGiftBox, out HitSphereGiftBox);
	}
	
	//Check the Objects in the Field of View
	void CheckObjectsinFOV()
	{
		if( AngleSphereSnowman <= 45 && IsSphereSnowmanActive &&
		   HitSphereSnowman.transform.gameObject.Equals(SphereSnowman)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchSnowman.Stop();
			
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchSnowman.Elapsed;
			long tsms = StopwatchSnowman.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found Snowman");
			Writer.WriteLine("Found Snowman");
			Writer.WriteLine("RunTime " + elapsedTime);
			HaloSnowman.GetType().GetProperty("enabled").SetValue(HaloSnowman, false, null);
			//Snowman.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchSnowman.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.SNOWMAN] = false;
			
			//Set the Snowman active as false
			IsSphereSnowmanActive = false;
		}
		else if(AngleSphereSnowman > 45 && IsSphereSnowmanActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;

			//Increment individual error count
			ErrorCountSnowman += 1;
		}
		else if( AngleSphereSnowman <= 45 && IsSphereSnowmanActive &&
		        !(HitSphereSnowman.transform.gameObject.Equals(SphereSnowman))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSnowman += 1;
		}


		if( AngleSphereEyeBall <= 45 && IsSphereEyeBallActive &&
		   HitSphereEyeBall.transform.gameObject.Equals(SphereEyeBall)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchEyeBall.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchEyeBall.Elapsed;
			long tsms = StopwatchEyeBall.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found EyeBall");
			
			Writer.WriteLine("Found EyeBall");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloEyeBall.GetType().GetProperty("enabled").SetValue(HaloEyeBall, false, null);
			//EyeBall.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchEyeBall.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.EYEBALL] = false;
			
			//Set the Snowman active as false
			IsSphereEyeBallActive = false;
		}
		else if(AngleSphereEyeBall > 45 && IsSphereEyeBallActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountEyeBall += 1;
		}
		else if( AngleSphereEyeBall <= 45 && IsSphereEyeBallActive &&
		        !(HitSphereEyeBall.transform.gameObject.Equals(SphereEyeBall))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountEyeBall += 1;
		}
		
		if( AngleSphereLunarLander <= 45 && IsSphereLunarLanderActive &&
		   HitSphereLunarLander.transform.gameObject.Equals(SphereLunarLander)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchLunarLander.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchLunarLander.Elapsed;
			long tsms = StopwatchLunarLander.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found LunarLander");	
			
			Writer.WriteLine("Found LunarLander");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloLunarLander.GetType().GetProperty("enabled").SetValue(HaloLunarLander, false, null);
			//LunarLander.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchLunarLander.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.LUNARLANDER] = false;
			
			//Set the Snowman active as false
			IsSphereLunarLanderActive = false;
		}
		else if(AngleSphereLunarLander > 45 && IsSphereLunarLanderActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountLunarLander += 1;
		}
		else if( AngleSphereLunarLander <= 45 && IsSphereLunarLanderActive &&
		        !(HitSphereLunarLander.transform.gameObject.Equals(SphereLunarLander))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountLunarLander += 1;
		}
		
		if( AngleSphereFishingBoat <= 45 && IsSphereFishingBoatActive &&
		   HitSphereFishingBoat.transform.gameObject.Equals(SphereFishingBoat)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchFishingBoat.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchFishingBoat.Elapsed;
			long tsms = StopwatchFishingBoat.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found FishingBoat");	
			
			Writer.WriteLine("Found FishingBoat");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloFishingBoat.GetType().GetProperty("enabled").SetValue(HaloFishingBoat, false, null);
			//FishingBoat.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchFishingBoat.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.FISHINGBOAT] = false;
			
			//Set the Snowman active as false
			IsSphereFishingBoatActive = false;
		}
		else if(AngleSphereFishingBoat > 45 && IsSphereFishingBoatActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountFishingBoat += 1;
		}
		else if( AngleSphereFishingBoat <= 45 && IsSphereFishingBoatActive &&
		        !(HitSphereFishingBoat.transform.gameObject.Equals(SphereFishingBoat))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountFishingBoat += 1;
		}
		
		if( AngleSphereMagicLamp <= 45 && IsSphereMagicLampActive &&
		   HitSphereMagicLamp.transform.gameObject.Equals(SphereMagicLamp)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchMagicLamp.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchMagicLamp.Elapsed;
			long tsms = StopwatchMagicLamp.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found MagicLamp");	
			
			Writer.WriteLine("Found MagicLamp");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloMagicLamp.GetType().GetProperty("enabled").SetValue(HaloMagicLamp, false, null);
			//MagicLamp.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchMagicLamp.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.MAGICLAMP] = false;
			
			//Set the Snowman active as false
			IsSphereMagicLampActive = false;
		}
		else if(AngleSphereMagicLamp > 45 && IsSphereMagicLampActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountMagicLamp += 1;
		}
		else if( AngleSphereMagicLamp <= 45 && IsSphereMagicLampActive &&
		        !(HitSphereMagicLamp.transform.gameObject.Equals(SphereMagicLamp))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountMagicLamp += 1;
		}
		
		if( AngleSphereSnowflake <= 45 && IsSphereSnowflakeActive &&
		   HitSphereSnowflake.transform.gameObject.Equals(SphereSnowflake)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchSnowflake.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchSnowflake.Elapsed;
			long tsms = StopwatchSnowflake.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found SnowFlake");	
			
			Writer.WriteLine("Found SnowFlake");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloSnowflake.GetType().GetProperty("enabled").SetValue(HaloSnowflake, false, null);
			//Snowflake.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchSnowflake.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.SNOWFLAKE] = false;
			
			//Set the Snowman active as false
			IsSphereSnowflakeActive = false;
		}
		else if(AngleSphereSnowflake > 45 && IsSphereSnowflakeActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSnowflake += 1;
		}
		else if( AngleSphereSnowflake <= 45 && IsSphereSnowflakeActive &&
		        !(HitSphereSnowflake.transform.gameObject.Equals(SphereSnowflake))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSnowflake += 1;
		}
		
		
		if( AngleSphereStar <= 45 && IsSphereStarActive &&
		   HitSphereStar.transform.gameObject.Equals(SphereStar)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchStar.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchStar.Elapsed;
			long tsms = StopwatchStar.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found Star");	
			
			Writer.WriteLine("Found Star");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloStar.GetType().GetProperty("enabled").SetValue(HaloStar, false, null);
			//Star.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchStar.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.STAR] = false;
			
			//Set the Snowman active as false
			IsSphereStarActive = false;
		}
		else if(AngleSphereStar > 45 && IsSphereStarActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountStar += 1;
		}
		else if( AngleSphereStar <= 45 && IsSphereStarActive &&
		        !(HitSphereStar.transform.gameObject.Equals(SphereStar))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountStar += 1;
		}
		
		if( AngleSphereRedDragon <= 45 && IsSphereRedDragonActive &&
		   HitSphereRedDragon.transform.gameObject.Equals(SphereRedDragon)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchRedDragon.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchRedDragon.Elapsed;
			long tsms = StopwatchRedDragon.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found RedDragon");	
			
			Writer.WriteLine("Found RedDragon");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloRedDragon.GetType().GetProperty("enabled").SetValue(HaloRedDragon, false, null);
			//RedDragon.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchRedDragon.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.REDDRAGON] = false;
			
			//Set the Snowman active as false
			IsSphereRedDragonActive = false;
		}
		else if(AngleSphereRedDragon > 45 && IsSphereRedDragonActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountRedDragon += 1;
		}
		else if( AngleSphereRedDragon <= 45 && IsSphereRedDragonActive &&
		        !(HitSphereRedDragon.transform.gameObject.Equals(SphereRedDragon))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountRedDragon += 1;
		}
		
		if( AngleSphereCandyCane <= 45 && IsSphereCandyCaneActive &&
		   HitSphereCandyCane.transform.gameObject.Equals(SphereCandyCane)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchCandyCane.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchCandyCane.Elapsed;
			long tsms = StopwatchCandyCane.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found CandyCane");	
			
			Writer.WriteLine("Found CandyCane");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloCandyCane.GetType().GetProperty("enabled").SetValue(HaloCandyCane, false, null);
			//CandyCane.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchCandyCane.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.CANDYCANE] = false;
			
			//Set the Snowman active as false
			IsSphereCandyCaneActive = false;
		}
		else if(AngleSphereCandyCane > 45 && IsSphereCandyCaneActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountCandyCane += 1;
		}
		else if( AngleSphereCandyCane <= 45 && IsSphereCandyCaneActive &&
		        !(HitSphereCandyCane.transform.gameObject.Equals(SphereCandyCane))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountCandyCane += 1;
		}
		
		if( AngleSphereSportsCar <= 45 && IsSphereSportsCarActive &&
		   HitSphereSportsCar.transform.gameObject.Equals(SphereSportsCar)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchSportsCar.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchSportsCar.Elapsed;
			long tsms = StopwatchSportsCar.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found SportsCar");	
			
			Writer.WriteLine("Found SportsCar");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloSportsCar.GetType().GetProperty("enabled").SetValue(HaloSportsCar, false, null);
			//SportsCar.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchSportsCar.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.SPORTSCAR] = false;
			
			//Set the Snowman active as false
			IsSphereSportsCarActive = false;
		}
		else if(AngleSphereSportsCar > 45 && IsSphereSportsCarActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSportsCar += 1;
		}
		else if( AngleSphereSportsCar <= 45 && IsSphereSportsCarActive &&
		        !(HitSphereSportsCar.transform.gameObject.Equals(SphereSportsCar))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSportsCar += 1;
		}
		
		
		if( AngleSphereSantaCap <= 45 && IsSphereSantaCapActive &&
		   HitSphereSantaCap.transform.gameObject.Equals(SphereSantaCap)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchSantaCap.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchSantaCap.Elapsed;
			long tsms = StopwatchSantaCap.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found SantaCap");	
			
			Writer.WriteLine("Found SantaCap");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloSantaCap.GetType().GetProperty("enabled").SetValue(HaloSantaCap, false, null);
			//SantaCap.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchSantaCap.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.SANTACAP] = false;
			
			//Set the Snowman active as false
			IsSphereSantaCapActive = false;
		}
		else if(AngleSphereSantaCap > 45 && IsSphereSantaCapActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSantaCap += 1;
		}
		else if( AngleSphereSantaCap <= 45 && IsSphereSantaCapActive &&
		        !(HitSphereSantaCap.transform.gameObject.Equals(SphereSantaCap))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountSantaCap += 1;
		}
		
		if( AngleSphereGiftBox <= 45 && IsSphereGiftBoxActive &&
		   HitSphereGiftBox.transform.gameObject.Equals(SphereGiftBox)
		   && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the audio cue to the user
			correctAudio.Play();
			
			//Stop the Stop Watch
			StopwatchGiftBox.Stop();
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = StopwatchGiftBox.Elapsed;
			long tsms = StopwatchGiftBox.ElapsedMilliseconds;
			// Format and display the TimeSpan value. 
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			                                   ts.Hours, ts.Minutes, ts.Seconds,
			                                   ts.Milliseconds / 10);
			print("RunTime " + elapsedTime);
			print ("Found GiftBox");	
			
			Writer.WriteLine("Found GiftBox");
			Writer.WriteLine("RunTime " + elapsedTime);
			
			HaloGiftBox.GetType().GetProperty("enabled").SetValue(HaloGiftBox, false, null);
			//GiftBox.GetComponent<ParticleSystem>().Stop();
			
			//If the list index is first then start the Session Watch
			if(listPawnShopObjects.Count == listindex)
			{
				//Lights OFF
				Lights.SetActive(false);
				//Stop the Stop watch
				StopwatchSession.Stop();
				
				// Get the elapsed time as a TimeSpan value.
				TimeSpan SessionTime = StopwatchSession.Elapsed;
				long SessionTimems = StopwatchSession.ElapsedMilliseconds;
				// Format and display the TimeSpan value. 
				string elapsedSessionTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				                                          SessionTime.Hours, SessionTime.Minutes, SessionTime.Seconds,
				                                          SessionTime.Milliseconds / 10);
				print("Total Session RunTime " + elapsedSessionTime);
				Writer.WriteLine("Total Session RunTime " + elapsedSessionTime);
				
				//Reset the Stop Watch
				StopwatchSession.Reset();
			}
			
			//Reset the Stop Watch
			StopwatchGiftBox.Reset();
			
			//Set the SetObject in the dictionary as false
			ObjectSetDictionary[PawnShopObjects.GIFTBOX] = false;
			
			//Set the Snowman active as false
			IsSphereGiftBoxActive = false;
		}
		else if(AngleSphereGiftBox > 45 && IsSphereGiftBoxActive && InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountGiftBox += 1;
		}
		else if( AngleSphereGiftBox <= 45 && IsSphereGiftBoxActive &&
		        !(HitSphereGiftBox.transform.gameObject.Equals(SphereGiftBox))
				&& InputBroker.GetKeyPress(WiimoteName + ":B"))
		{
			//Play the error audio cue to the user
			errorAudio.Play();
			
			//Increment the total error count
			TotalErrorCount += 1;
			
			//Increment individual error count
			ErrorCountGiftBox += 1;
		}
	}    	
	
	//Select Object for searching
	void SelectObject ()
	{
		//Select Objects if index is less than total count and none of the objects is active
		if(listindex < listPawnShopObjects.Count
		   && !IsSphereSnowmanActive
		   && !IsSphereEyeBallActive
		   && !IsSphereLunarLanderActive
		   && !IsSphereFishingBoatActive
		   && !IsSphereMagicLampActive
		   && !IsSphereSnowflakeActive
		   && !IsSphereStarActive
		   && !IsSphereRedDragonActive
		   && !IsSphereCandyCaneActive
		   && !IsSphereSportsCarActive
		   && !IsSphereSantaCapActive
		   && !IsSphereGiftBoxActive)
		{
			//Get the list value
			ObjecttoSearch = listPawnShopObjects[listindex];
			
			//Set the obeject to be set active for the first time
			ObjectSetDictionary[ObjecttoSearch] = true;
			
			//increment the list index
			listindex++;
		}
		else if(listindex > listPawnShopObjects.Count)
		{
			
		}				
	}	
}
