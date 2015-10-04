#pragma strict

public var currentMount : Transform;
public var speedFactory : float = 0.4;
public var zoomFactory = 1.0;
public var cameraComp : Camera;
public var lastPosition : Vector3;

function Start () {
 lastPosition = transform.position;
}

function Update () {
  transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactory);
  transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactory);

  /*var velocity = Vector3.Magnitude(transform.position - lastPosition);
  cameraComp.fieldOfView = 60 + velocity * zoomFactory;
  
  lastPosition = transform.position;*/
}

function setMount(newMount : Transform ){
	currentMount = newMount;
}