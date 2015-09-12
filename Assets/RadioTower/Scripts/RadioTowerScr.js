var BlinkSpeed : float = 1.0;
var LightOnIntensity : float = 1.0;
var LightOffIntensity : float = 0.0;
private var SecondsPassed : float = 0.0;

function Start(){light.intensity = LightOnIntensity;}
function Update() 
{
	SecondsPassed += Time.deltaTime;
	if(light.intensity == LightOnIntensity && SecondsPassed >= BlinkSpeed)
	{
		light.intensity = LightOffIntensity;
		SecondsPassed = 0.0;
	}
	
	else if(light.intensity == LightOffIntensity && SecondsPassed >= BlinkSpeed)
	{
		light.intensity = LightOnIntensity;
		SecondsPassed = 0.0;
	}
}

