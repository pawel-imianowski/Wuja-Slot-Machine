//const uri = 'https://wujasapi.azure-api.net/spin'
let bet = 1.00;

$('#amountIndicatorValue').fitText(0.5);

$('#spinButton').click(function(){
    spin(document.getElementById('amountIndicatorValue').textContent)
});

function spin(costValue) {
    postData(location.href + "?handler=Spin", costValue)
        .then(data => {
            for(var col = 0; col < data.TileMatrix.length; col++){
                for(var row = 0; row < data.TileMatrix[col].length; row++){
                    $('#tile'+col+row+' > img').attr("src","/assets/wujasanator/symbols/"+getPictureNameById(data.TileMatrix[col][row]));
                }
            }
            if (data.Bonuses != ""){alert('BONUSY: ' + data.Bonuses);}
            alert('WYGRAŁEŚ: '+ data.Reward + 'PLN');
        })
        .catch(console.error);
}

async function postData(url = '', data = {}){
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
    amount.textContent = bet.toFixed(2);
}

function decreaseBet() {
    if(bet > 0.25 ) {
        bet -= 0.25;
        var amount = document.getElementById("amountIndicatorValue");
        amount.textContent = bet.toFixed(2);
    }
}

function getPictureNameById(id){
    let pictureName = "";
    switch(id){
        case 0:
            pictureName = "apple.svg";
            break;
        case 1:
            pictureName = "bow.svg";
            break;
        case 2:
            pictureName = "coat.svg";
            break;
        case 3:
            pictureName = "dinosaur.svg";
            break;
        case 4:
            pictureName = "fish.svg";
            break;
        case 5:
            pictureName = "girl.svg";
            break;
        case 6:
            pictureName = "heart.svg";
            break;
        case 7:
            pictureName = "midas.svg";
            break;
        case 8:
            pictureName = "pants.svg";
            break;
        default:
            alert("coś poszło nie tak");
            break;
    }
    
    return pictureName;
}