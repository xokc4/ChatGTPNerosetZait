
<script>
    function sendMessage() {
            var userInput = document.getElementById("userInput").value;
    document.getElementById("userInput").value = '';

    var userMessage = document.createElement("p");
    userMessage.innerHTML = "User: " + userInput;
    document.getElementById("chatbox").appendChild(userMessage);

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
                if (this.readyState == 4 && this.status == 200) {
                    var response = JSON.parse(this.responseText);
    var botMessage = document.createElement("p");
    botMessage.innerHTML = "Bot: " + response.message;
    document.getElementById("chatbox").appendChild(botMessage);
                }
            };
    xhttp.open("POST", "https://api.openai.com/v1/engines/davinci-codex/completions", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.setRequestHeader("Authorization", "Bearer YOUR_API_KEY");
    xhttp.send(JSON.stringify({
        'prompt': userInput,
    'max_tokens': 50
            }));
        }
</script>