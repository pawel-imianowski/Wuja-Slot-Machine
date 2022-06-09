let bet = 1;

function spin() {
    var slot = document.getElementById('slotArea')
    slot.setAttribute("style", "background-image: url(/src/assets/ribbentropmolotov.jpg); background-repeat: no-repeat; background-size: cover;")
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
