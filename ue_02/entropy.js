function entropy(a){
	var array = a;
	var subtotal = 0;
	var sumEntropie = 0;

	//console.log(a);

	for (var i = 0; i < array.length; i++) {
		subtotal = (array[i] / 100) * Math.log2(1 / (array[i] / 100));
        sumEntropie = sumEntropie + subtotal;
	};

	print(sumEntropie);
}

function print(output){
	document.getElementById("entropy_result").innerHTML = output;
}