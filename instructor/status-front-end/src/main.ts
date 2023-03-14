import './style.css'

const button = document.querySelector('#btn') as HTMLButtonElement;
const currentSpan = document.getElementById('current') as HTMLSpanElement;
const decrementButton = document.getElementById('decrement') as HTMLButtonElement;
const incrementButton = document.getElementById('increment') as HTMLButtonElement;

let current = 0; // data in javascript memory

currentSpan.innerText = current.toString();

decrementButton.addEventListener('click', () => {
    updateCurrent();
    current = current - 1;
})

incrementButton.addEventListener('click', () => {
    updateCurrent()
    current = current + 1;
});

function updateCurrent() {
    console.log( {current });
    currentSpan.innerText = current.toString();
}

if(button === null) {
    console.error("Could not find the button");
} else {
    // app.MapGet("/status", () => { })
    button.addEventListener('click', () => {
        fetch('http://localhost:1337/status')
        .then(response => response.json())
        .then((status:ResponseMessage) => {
            console.log(`The status is ${status.message} as of ${status.when}`)
        });
    })
}

type ResponseMessage = {
    id: string;
    message: string;
    when: string;
}