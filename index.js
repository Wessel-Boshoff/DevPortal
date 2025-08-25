document.getElementById("demoForm").addEventListener("submit", e => {
    e.preventDefault();
    document.getElementById("formMsg").textContent = "Form submitted!";
});

const ctx = document.getElementById("myCanvas").getContext("2d");
ctx.fillStyle = "#0077cc";
ctx.fillRect(20, 20, 100, 50);
ctx.strokeStyle = "#ff6600";
ctx.strokeRect(50, 80, 150, 50);

async function loadData() {
    const res = await fetch("https://jsonplaceholder.typicode.com/posts?_limit=3");
    const data = await res.json();
    const list = document.getElementById("dataList");
    list.innerHTML = "";
    data.forEach(item => {
        const li = document.createElement("li");
        li.textContent = item.title;
        list.appendChild(li);
    });
}

function toggleTheme() {
    document.body.classList.toggle("dark");
    localStorage.setItem("theme", document.body.classList.contains("dark") ? "dark" : "light");
}
if (localStorage.getItem("theme") === "dark") document.body.classList.add("dark");

const darkStyle = document.createElement("style");
darkStyle.innerHTML = `
            .dark { background:#222; color:#eee; }
            .dark section { background:#333; }
        `;
document.head.appendChild(darkStyle);

function updateClock() {
    document.getElementById("clock").textContent = new Date().toLocaleTimeString();
}
setInterval(updateClock, 1000); updateClock();