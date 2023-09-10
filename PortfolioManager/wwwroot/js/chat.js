
let messageBoard = document.getElementById("conversation");
let textInput = document.getElementById("text-input");
let button = document.getElementsByTagName("input");
let logo = document.getElementById("chat-image-div");

button[0].addEventListener("click", () => {

    let questionText = textInput.value;
    logo.classList.add("d-none");
    textInput.value = "";

    button[0].setAttribute(`disabled`, "");
    createQuestion(questionText);

    fetch("/Chat/GetAnswer", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(questionText),
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

    textBubble.textContent = text;
    messageBoard.appendChild(textBubble);
    window.scrollBy(0, 250);

    

}
function createAnswer(text) {


     let textBubble = document.createElement("div");
    textBubble.className = " message my-3 p-3 text-wrap even-color margin-start";

 
    textBubble.textContent = text;
    messageBoard.appendChild(textBubble);
    window.scrollBy(0, 250);
    button[0].removeAttribute(`disabled`);

}




