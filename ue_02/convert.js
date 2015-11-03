function convert(){
		var number = document.getElementById("number").value;
		var fromBase = document.getElementById("fromBase").value;
		var toBase = document.getElementById("toBase").value;

		if(number != "" && fromBase != "" && toBase != "")
		{
			var dec = convertToDec(number, fromBase);
			printConvert(convertToBase(dec, toBase));
		}
		else{
			document.getElementById("convert_result").innerHTML = "...";
		}
}

function convertToDec(n, fB){
	var d = 0;
	var sub = 0;
	var value = String(n).split('');
	for (var i = 0; i < value.length; i++) {
		sub = (Math.pow(fB, i))*value[value.length-1-i];
		d += sub;
	};
	return d;
}

function convertToBase(d, tB){
	var total = "";
	var sub = d;
	var r = "";
	while(sub != 0){
		total += sub % tB;
		sub = Math.floor(sub/tB);
	}
	var t =  String(total).split('');
	for (var i = 0; i < t.length; i++){
		r += t[t.length-1-i];
	}
	return r;
}

function printConvert(output){
		document.getElementById("convert_result").innerHTML = output;
}