
let messageBoard = document.getElementById("conversation");
let textInput = document.getElementById("text-input");
let button = document.getElementsByTagName("input");


button[0].addEventListener("click", () => {

    button[0].setAttribute(`disabled`, "");
    createQuestion(textInput.value);

    fetch("/Chat/GetAnswer", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(textInput.value),
    })
        .then(response => response.text())
        .then(data => {
            createAnswer(data);
        })
        .catch(error => {
            console.error('Chyba:', error);
        });



});


function createQuestion(text) {

    let textBubble = document.createElement("div");
    textBubble.className = "message my-3 p-3 text-wrap margin-end";

    textBubble.textContent = textInput.value;
    messageBoard.appendChild(textBubble);


    

}
function createAnswer(text) {


     let textBubble = document.createElement("div");
    textBubble.className = " message my-3 p-3 text-wrap even-color margin-start";

 
    textBubble.textContent = text;
    messageBoard.appendChild(textBubble);

    button[0].removeAttribute(`disabled`);

}





