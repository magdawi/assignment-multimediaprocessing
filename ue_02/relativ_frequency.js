function frequency(){
	document.getElementById("frequency_list").innerHTML = "";
	var text = document.getElementById("text").value;
	var array = String(text).split('');
	var textLength = array.length;
	var collection = [];
	var ascii;
	var counter = 0;
	var asciis = [];

	var arrayForEntropy = [];

	for (var i = 0; i < array.length; i++) {
		ascii = array[i].charCodeAt(0);
		if(collection[ascii] == null){
			collection[ascii] = 1;
			asciis[counter] = ascii;
			counter++;			
		}
		else{
			collection[ascii] = collection[ascii]+1;
		}
	};

	for (var i = 0; i < asciis.length; i++) {
		collection[asciis[i]] = collection[asciis[i]] / textLength * 100;
		arrayForEntropy[i] = collection[asciis[i]];
		printFrequency(collection, asciis[i]);
	};
	entropy(arrayForEntropy);
		
}

function printFrequency(c, a){
	var firstli = document.createElement("LI"); 
	var text = document.createTextNode(a + " -> " + c[a] + " %");
	firstli.appendChild(text);
	document.getElementById("frequency_list").appendChild(firstli);
}