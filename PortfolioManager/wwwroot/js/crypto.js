﻿
   let btc = document.getElementById("bitcoin");
   let lit = document.getElementById("lithium");



    let livepriceBTC = {
        "async" : true,
        "scroosDomain" : true,
        "url" : "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin%2Ccosmos%2Cmatic-network%2Clithium-ventures&vs_currencies=usd",
        "method" : "GET",
        "headers" :{}
}

    
    $.ajax(livepriceBTC).done(function (response) {   
        console.log(response);
        btc.textContent = response.bitcoin.usd +" USD";
        lit.textContent = response['lithium-ventures'].usd +" USD"; 
    })

  