var Language = "KO";

window.onload = function()
{
	RefreshText();
}

function RefreshText()
{
	let JsonData = JSON.parse(JSON.stringify(KOJson));
	if(Language == "EN")
	{
		JsonData = JSON.parse(JSON.stringify(ENJson));
	}
	
	var Keys = Object.keys(JsonData)
	for(var i = 0; i < Keys.length; i++)
	{
		var key = Keys[i];
		var objects = document.getElementsByClassName(key.toString());
		for(var x = 0; x < objects.length; x++)
		{
			objects[x].innerHTML = JsonData[key];
		}
	}
}

function ToKO()
{
	Language = "KO";
	RefreshText();
}

function ToEN()
{
	Language = "EN";
	RefreshText();
}