function decode(){
	var output = "";
	var access = true;
	var inp = document.getElementById("string").value;
	var input = String(inp).split('');
	var subcode = "";
	for (var i = 0; i < input.length; i++) {
		subcode += input[i];
		switch(subcode){
            case "00":
                output += "T";
                subcode = "";
                break;
            case "10":
                output += "F";
                subcode = "";
                break;
            case "11":
                output += "O";
                subcode = "";
                break;
            case "0110":
                output += "R";
                subcode = "";
                break;
            case "0101":
                output += "N"; //N - D
                subcode = "";
                break;
            case "0111":
                output += "M";
                subcode = "";
                break;
            case "01000":
                output += "I"; //I - G
                subcode = "";
                break;
			case "01001":
                output += "A";
                subcode = "";
                break;
            default:
                break;
        }
        //0111 01001 01000 0101 01001
        if(subcode.length > 6)
        {
            console.log("Input fails!");
            access = false;
            break;
        }
	};
	printDecode(output);
}

function printDecode(output){
	if(output != ""){
		document.getElementById("decode_result").innerHTML = output;
	}
	else{
		document.getElementById("decode_result").innerHTML = "...";
	}
}