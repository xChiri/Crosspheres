#pragma strict

var cubeThing : Transform; 
var lastMousePosition : Vector3;

function Update(){

 if(Input.GetMouseButton(0)){
     if(Input.GetMouseButtonDown(0)){
         //reset
         lastMousePosition = Input.mousePosition;    
     }
     else if(Input.mousePosition.y && lastMousePosition.y){
         cubeThing.Rotate(Vector3.up*(Input.mousePosition.y - lastMousePosition.y));
     }
     lastMousePosition = Input.mousePosition;
 }
 }