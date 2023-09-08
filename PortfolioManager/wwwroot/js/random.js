
document.getElementById('getRandomPassword').addEventListener('click', function () {
    fetch('/Help/RandomPassword')
        .then(response => response.text())
        .then(data => {
            document.getElementsByClassName('randomPassword')[0].value = data;
            document.getElementsByClassName('randomPassword')[1].value = data;
            document.getElementsByClassName('randomPassword')[0].type = "text";
            document.getElementsByClassName('randomPassword')[1].type = "text";

        });
});