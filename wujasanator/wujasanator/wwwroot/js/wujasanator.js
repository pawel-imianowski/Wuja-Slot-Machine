//const uri = 'https://wujasapi.azure-api.net/spin'
let bet = 1;
let outcome = [];

$('#spinButton').click(function(){
    spin($('#amountIndicatorValue').textContent)
});

function spin(costValue) {
    postData(location.href + "?handler=Spin", 12.32)
        .then(data => {
            for(var col = 0; col < data.TileMatrix.length; col++){
                alert(data.TileMatrix[col]);
            }
            if (data.Bonuses != ""){alert('BONUSY: ' + data.Bonuses);}
            alert('WYGRAŁEŚ: '+ data.Reward + 'PLN');
        })
        .catch(console.error);
}

async function postData(url = '', data = {}){
    
    alert(JSON.stringify(data));
    // Default options are marked with *
    const response = await fetch(url, {
        method: 'POST',
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        headers: {
        'RequestVerificationToken': document.getElementsByName("__RequestVerificationToken")[0].value,
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    return response.json(); // parses JSON response into native JavaScript objects
}

function increaseBet() {
    bet += 0.25;
    var amount = document.getElementById("amountIndicatorValue");
    amount.textContent = bet;
}

function decreaseBet() {
    if(bet > 0.25 ) {
        bet -= 0.25;
        var amount = document.getElementById("amountIndicatorValue");
        amount.textContent = bet;
    }
}