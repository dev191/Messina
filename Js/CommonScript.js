// Nel evento keypress non permette di digitare numeri
function SoloNumeri()
{
	if (event.keyCode < 48	|| event.keyCode > 57){
		event.keyCode = 0;
	}	
}




