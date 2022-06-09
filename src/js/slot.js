const uri = 'https://wujasapi.azure-api.net/spin'
let bet = 1;
let outcome = [];

function spin() {
    fetch(uri)
    .then(response => response.json())
    .then(console.log)
    .catch(error => console.error('Unable to get outcome.', error));
}

function increaseBet() {
    bet += 1;
    var amount = document.getElementById("amountIndicatorValue");
    amount.textContent = bet;
}

function decreaseBet() {
    if(bet >= 2 ) {
        bet -= 1;
        var amount = document.getElementById("amountIndicatorValue");
        amount.textContent = bet;
    }
}